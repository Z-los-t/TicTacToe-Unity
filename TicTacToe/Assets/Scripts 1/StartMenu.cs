
using UnityEngine.SceneManagement;
using UnityEngine;


public class StartMenu : MonoBehaviour
{
    public static string mode;
    public void startAI()
    {
        mode = "AI";

        SceneManager.LoadScene(2);
    }

  
    public void startLocal()
    {
        mode= "twoPlayerLocal";
        SceneManager.LoadScene(2);

    }

 
    

   


   
}
