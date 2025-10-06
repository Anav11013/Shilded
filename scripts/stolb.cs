using UnityEngine;

public class stolb : MonoBehaviour
{
    public GameObject player;
    public SpriteRenderer self;
    private void Start()
    {
        self = gameObject.GetComponent<SpriteRenderer>();
        player = FindObjectOfType<player_controler>().gameObject;
    }
    private void Update()
    {
        if(player.transform.position.y > transform.position.y)
        {
            self.sortingOrder = 1;
        }
        else self.sortingOrder = -1;
    }
}
