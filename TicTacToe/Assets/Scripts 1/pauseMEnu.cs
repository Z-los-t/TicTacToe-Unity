
using UnityEngine;
using UnityEngine.SceneManagement;
public class pauseMEnu : MonoBehaviour
{
    [SerializeField] private GameObject Canvas;
    private bool onoff = false;
    private KeyCode PauseKey = KeyCode.Escape;

    void Update()
    {
        if (Input.GetKeyDown(PauseKey))
        {
            onoff = !onoff;
            Canvas.SetActive(onoff);
        }

    }
    public void Pause()
    {
        onoff = !onoff;
        Canvas.SetActive(onoff);
        
    }

    public void tomenu(int NumberScene)
    {
        SceneManager.LoadScene(0);

    }
 
}
