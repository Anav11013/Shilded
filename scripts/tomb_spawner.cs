using UnityEngine;
public class tomb_spawner : MonoBehaviour
{
    public GameObject[] tombs;
    public int amount;

    private void Start()
    {
        while ( amount >= 1)
        {
            int e = Random.Range(1, tombs.Length);
            Vector3 aspawn = new Vector3(Random.Range(-50f, 50f), Random.Range(-50f, 50f));
            GameObject tomb = Instantiate(tombs[e], aspawn, Quaternion.identity);
            if (Vector3.Distance(transform.position, aspawn) < 20f) { Destroy(tomb); amount++; }
            amount--;
        }
    }

}
