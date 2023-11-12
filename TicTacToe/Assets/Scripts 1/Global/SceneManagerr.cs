
using UnityEngine;

public class SceneManagerr : MonoBehaviour
{
    // Declare any public variables that you want to be able 
    // to access throughout your scene
    public Player player;
    public Turn turn;
    public static SceneManagerr Instance { get; private set; } // static singleton
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else { Destroy(gameObject); }
    }
}
