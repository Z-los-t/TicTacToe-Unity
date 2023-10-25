using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ButtonManager : MonoBehaviour
{
   
   [SerializeField] private  Sprite X;
   [SerializeField] private Button[] button;
   
    public void Selected(int whichButton)
    {
        button[whichButton].image.sprite = X;
        button[whichButton].interactable = false;
        int index = int.Parse(button[whichButton].name);
        gameObject.GetComponent<GameManager>().FullButton[whichButton]="X";
    }
}
