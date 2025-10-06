using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_manager : MonoBehaviour
{
    public player_controler player;
    public tomb_spawner spawner;
    public spawn_manager spawn_manager;
    public int st_am; 
    private void Awake()
    {
        if (PlayerPrefs.GetInt("sp", 5) > 3) PlayerPrefs.SetInt("sp", PlayerPrefs.GetInt("sp", 5) - 1);
        else PlayerPrefs.SetInt("sp", 5);
        if (PlayerPrefs.GetInt("score", 0) > PlayerPrefs.GetInt("best_score", 0)) PlayerPrefs.SetInt("best_score", PlayerPrefs.GetInt("score", 0));
        PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("bet_score", 0));
        PlayerPrefs.Save();
        spawn_manager.cycle_lengh = PlayerPrefs.GetInt("sp", 5);
        st_am = spawner.amount;
    }
    void Update()
    {
        if (player.a >= st_am){
            player.GetComponent<Animator>().SetBool("is_win", true);
            player.speed = 0;
            player.GetComponent<Health>().health = 999;
            Invoke("load", 2f); 
        }
        if(Input.GetKeyDown(KeyCode.R)) { SceneManager.LoadScene("start"); }
    }
    public void load()
    {
        SceneManager.LoadScene("main");
    }
}
