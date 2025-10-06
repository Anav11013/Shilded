using UnityEngine;

public class nullifier : MonoBehaviour
{
    
    private void Start()
    {
        PlayerPrefs.SetInt("sp", 5);
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt("bet_score", 0);
    }

}
