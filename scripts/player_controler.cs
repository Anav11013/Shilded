using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class player_controler : MonoBehaviour
{
    public float speed;
    public GameObject shield;
    public Vector2 ghost_move_pos;
    private Health health;
    public bool shielded;
    private float a_t;
    private Animator animator;
    public Text best;
    public int a;
    private void Start()
    {
        animator = GetComponent<Animator>();
        health = gameObject.GetComponent<Health>();
        StartCoroutine(ghost_rand());
    }
    private void Update()
    {
        if(best != null)best.text = "лучший счет: " + PlayerPrefs.GetInt("best_score",0);
        var X = Input.GetAxis("Horizontal");
        var Y = Input.GetAxis("Vertical");
        Vector2 a = new Vector2(X, Y);
        if (a.magnitude > 1 )
        {
            a.Normalize();
        }
        transform.Translate(a * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space) && a_t < 0 && health.shield_health > 0) StartCoroutine(shield_dest(shield));
        if (X > 0) transform.localScale = new Vector3(1,1,0);
        else if (X < 0) transform.localScale = new Vector3(-1,1,0);
        if (X != 0 || Y!= 0)
        {
            animator.SetBool("is_run", true);
        }
        else
        {
            animator.SetBool("is_run", false);
        }
        a_t -= Time.deltaTime;
    }
    private IEnumerator ghost_rand()
    {
        while (true)
        {
            ghost_move_pos = new Vector3(Random.Range(-10f + transform.position.x, 10f + transform.position.x), Random.Range(-5f + transform.position.y, 5f + transform.position.y), 0);
            yield return new WaitForSeconds(3f);
        }
    }
    private IEnumerator shield_dest(GameObject go)
    {
        go.SetActive(true);
        shielded = true;
        a_t = 1.5f;
        yield return new WaitForSeconds(0.5f);
        go.SetActive(false);
        shielded = false;
    }
}
