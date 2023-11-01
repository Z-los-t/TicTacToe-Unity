using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonManager : MonoBehaviour
{
   
   [SerializeField] private  Sprite X;
   public Button[] button;
   
    public void Selected(int whichButton)
    {
        
        button[whichButton].image.sprite = X;
        button[whichButton].interactable = false;
        
        gameObject.GetComponent<GameManager>().FullButton[whichButton] ="X";

        if (gameObject.GetComponent<GameManager>().verification("X")) Debug.Log("You Won!");
        else gameObject.GetComponent<GameManager>().AI();


    }


}
