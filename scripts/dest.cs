using UnityEngine;

public class dest : MonoBehaviour
{
    public float time;
    private void Update() { Invoke("destr", time); }
    private void destr() { Destroy(gameObject); }
}
