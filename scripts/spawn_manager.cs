using System.Collections;
using UnityEngine;
public class spawn_manager : MonoBehaviour
{
    public GameObject[] enemies;
    public float[] cost;
    public float points;
    private int point_mult = 1;
    public float cycle_lengh;
    private void Start()
    {
        StartCoroutine(cycler());
    }
    private IEnumerator cycler()
    {
        while (true)
        {
            StartCoroutine(spawn());
            yield return new WaitForSeconds(cycle_lengh);
        }
    }
    private IEnumerator spawn()
    {
        while (points > 1) {
            int e = Random.Range(1, enemies.Length);
            if (cost[e] > points) { StartCoroutine(spawn()); yield break; }
            Vector3 aspawn = new Vector3(Random.Range(-10f + transform.position.x, 10f + transform.position.x), Random.Range(-10f + transform.position.y, 10f + transform.position.y));
            if (Vector3.Distance(transform.position, aspawn) < 3f) { StartCoroutine(spawn()); yield break; }
            Instantiate(enemies[0], aspawn, Quaternion.identity);
            yield return new WaitForSeconds(0.6f);
            Instantiate(enemies[e], aspawn, Quaternion.identity);
            points -= cost[e];
        }
        points += point_mult * (points + 1);
        point_mult++;
    }
}
