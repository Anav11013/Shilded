using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Health : MonoBehaviour
{
    public int health;
    private SpriteRenderer color;
    public player_controler player;
    public Light2D shield;
    public float shield_health;
    public float max_shield_health = 3;
    public GameObject R;
    private void Start()
    {
        player = GetComponent<player_controler>();
        color = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (health <= 0)
        {
            health = 0;
            gameObject.SetActive(false);
            R.SetActive(true);
        }
        R.transform.position = transform.position;
        color.color = new Color(1, 0.5f * (health - 1), 0.5f * (health - 1));
        shield.color = new Color(0.5f * (max_shield_health - shield_health), 1 / (max_shield_health - shield_health + 1),1 / (max_shield_health - shield_health + 1), 1 / (max_shield_health - shield_health + 2));
        if(shield_health < max_shield_health)shield_health += max_shield_health / 20 * Time.deltaTime;
    }
    public void TakeDamage()
    {
        if (!player.shielded) health -= 1;
        else if (shield_health > 0) shield_health -= 1;
        else health -= 1;
    }
}
