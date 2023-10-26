using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public string[] FullButton;
    [SerializeField] private List<int> choice = new List<int>();
    [SerializeField] private Sprite O;
    public void AI()
    {
        AICHOOSE();

        int BotsChoice = choice[Random.Range(0, choice.Count)];
        GameObject.Find(BotsChoice.ToString()).GetComponent<Button>().image.sprite = O;
        FullButton[BotsChoice] = "O";
        GameObject.Find(BotsChoice.ToString()).GetComponent<Button>().interactable = false;

        if (verification("O")) Debug.Log("You Lost !");
        else  AICHOOSE(); 

    }
    private void AICHOOSE()
    {
        choice.Clear();

        for (int i = 0; i < FullButton.Length; i++)
        {
            if (FullButton[i] == "")
            {
                choice.Add(i);
            }

        }
        if (choice.Count == 0)
        {
            Debug.Log("FriendShip Won!");
            return;
        }

    }
    public bool verification(string playerChoose)
    {
        if (FullButton[0] == playerChoose && FullButton[1] == playerChoose && FullButton[2] == playerChoose ||
            FullButton[3] == playerChoose && FullButton[4] == playerChoose && FullButton[5] == playerChoose ||
            FullButton[6] == playerChoose && FullButton[7] == playerChoose && FullButton[8] == playerChoose ||

            FullButton[0] == playerChoose && FullButton[4] == playerChoose && FullButton[8] == playerChoose ||
            FullButton[6] == playerChoose && FullButton[4] == playerChoose && FullButton[2] == playerChoose ||

            FullButton[0] == playerChoose && FullButton[3] == playerChoose && FullButton[6] == playerChoose ||
            FullButton[1] == playerChoose && FullButton[4] == playerChoose && FullButton[7] == playerChoose ||
            FullButton[2] == playerChoose && FullButton[5] == playerChoose && FullButton[8] == playerChoose ) return true;




        else return false;
    }
}
