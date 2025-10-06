using UnityEngine;
public class whisp : MonoBehaviour
{
    public bool following;
    public GameObject player;
    public float interpVelocity;
    public Vector3 offset;
    Vector3 targetPos;
    public float s;
    public Vector2 a;
    public Vector2 b;
    public Vector2 c;
    public float i;
    private void Start()
    {
        player = FindObjectOfType<player_controler>().gameObject;
    }
    void Update()
    {
        if (following && Vector2.Distance(transform.position, player.transform.position) > 1f)
        {
            Vector3 posNoZ = transform.position;
            posNoZ.z = player.transform.position.z;
            Vector3 targetDirection = (player.transform.position - posNoZ);
            interpVelocity = targetDirection.magnitude * s;
            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);
        }
        else if(!following)
        {
            transform.position = Vector2.Lerp(Vector2.Lerp(a,b,i), Vector2.Lerp(b,c,i), i);
            i += 0.2f * Time.deltaTime;
        }
    }
}
