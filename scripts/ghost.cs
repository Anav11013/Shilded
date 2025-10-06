using System.Collections;
using UnityEngine;

public class ghost : MonoBehaviour
{
    public float lifetime;
    public float speed;
    public Vector2 target_pos;
    public GameObject player;
    private bool can_move = true;
    private float t;
    private void Start()
    {
        player = FindObjectOfType<player_controler>().gameObject;
    }
    void Update()
    {
        if (can_move)
        {
            target_pos = player.GetComponent<player_controler>().ghost_move_pos;
            if (transform.position.x < target_pos.x) gameObject.GetComponent<SpriteRenderer>().flipX = true;
            else if (transform.position.x > target_pos.x) gameObject.GetComponent<SpriteRenderer>().flipX = false;
            if (Vector2.Distance(transform.position, target_pos) > 1f) transform.position = Vector2.MoveTowards(transform.position, target_pos, speed * Time.deltaTime);
        }
        else if (!can_move && t < 0f)
        {
            StartCoroutine(att());
        }
        if(lifetime < 0f) Destroy(gameObject);
        if(Vector2.Distance(transform.position, player.transform.position) < 3f && t < 0) can_move = false;
        lifetime -= Time.deltaTime;
        t -= Time.deltaTime;

    }
    private IEnumerator att()
    {
        if (transform.position.x < player.transform.position.x) gameObject.GetComponent<SpriteRenderer>().flipX = true;
        else if (transform.position.x > player.transform.position.x) gameObject.GetComponent<SpriteRenderer>().flipX = false;
        Vector2 direct = player.transform.position - transform.position;
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<Rigidbody2D>().velocity = direct * 2.5f;
        can_move = true;
        t = 2;
        yield return null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Health>() != null)
        {
            collision.gameObject.GetComponent<Health>().TakeDamage();
        }
    }

}
