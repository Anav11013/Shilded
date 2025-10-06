using System;
using System.Collections;
using UnityEngine;

public class tombstone : MonoBehaviour
{
    public whisp whisp;
    public GameObject player;
    public spirit spirit;
    private void Start()
    {
        player = FindObjectOfType<player_controler>().gameObject;
        spirit = FindObjectOfType<spirit>();
        Array.Resize(ref this.spirit.tomb, this.spirit.tomb.Length + 1);
        this.spirit.tomb[this.spirit.tomb.Length - 1] = gameObject;
        StartCoroutine(a());
    }
    private void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < 2f && Input.GetKeyDown(KeyCode.E) && whisp.following == false)
        {
            player.GetComponent<player_controler>().a++;
            PlayerPrefs.SetInt("score", player.GetComponent<player_controler>().a);
            PlayerPrefs.SetInt("bet_score", PlayerPrefs.GetInt("score", 0));
            PlayerPrefs.Save();
            spirit.s++;
            whisp.following = true;
        }
    }
    public IEnumerator a()
    {
        while (!whisp.following) {
            whisp.a = whisp.transform.position;
            whisp.b = new Vector2(UnityEngine.Random.Range(-1f + transform.position.x, 1f + transform.position.x), UnityEngine.Random.Range(-0.65f + transform.position.y, 1.35f + transform.position.y));
            whisp.c = new Vector2(UnityEngine.Random.Range(-1f + transform.position.x, 1f + transform.position.x), UnityEngine.Random.Range(-0.65f + transform.position.y, 1.35f + transform.position.y));
            whisp.i = 0;
            yield return new WaitForSeconds(5f);
        }
    }
}
