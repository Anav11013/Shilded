using UnityEngine;

public class bomb : MonoBehaviour
{
    public GameObject projectile;
    public float timer;
    public float speed;
    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            for (int i = 0; i < 8; i++)
            {
                float angle = i * 45f;
                Vector3 direction = Quaternion.Euler(0, 0, angle) * Vector3.right;
                GameObject bullet = Instantiate(projectile, transform.position, Quaternion.Euler(0,0,angle));
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.velocity = direction * speed; 
            }
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<player_controler>() != null)
        {
            collision.gameObject.GetComponent<Health>().TakeDamage();
            Destroy(gameObject);
        }
    }
}
