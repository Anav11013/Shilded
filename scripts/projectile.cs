using UnityEngine;

public class projectile : MonoBehaviour
{
    public float lifetime;
    private void Update()
    {
        lifetime -= Time.deltaTime;
        if ( lifetime <= 0 ) Destroy( gameObject );
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<player_controler>() != null)
        {
            collision.gameObject.GetComponent<Health>().TakeDamage();
            Destroy( gameObject );
        }
    }
}
