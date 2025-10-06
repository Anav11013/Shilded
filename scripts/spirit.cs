using UnityEngine;

public class spirit : MonoBehaviour
{
    public GameObject[] tomb;
    public float dist;
    public float speed;
    public GameObject player;
    public int s;

    private void Start()
    {
        player = FindObjectOfType<player_controler>().gameObject;
    }
    private void Update()
    {
        if (tomb[s].GetComponent<tombstone>().whisp.following != true)
        {
            if (Vector2.Distance(transform.position, player.transform.position) < dist)
            {
                transform.position = Vector2.MoveTowards(transform.position, tomb[s].transform.position, speed * Time.deltaTime);
            }
            else transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        else
        {
            s = 0;
            while (tomb[s].GetComponent<tombstone>().whisp.following == true)
            {
                s++;
            }
        }
    }
}
