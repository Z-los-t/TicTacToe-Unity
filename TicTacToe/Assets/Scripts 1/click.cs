using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class click : MonoBehaviour
{
    public Sprite circle;
    public Sprite cross;
    public SpriteRenderer render;
    private Player player;
    private Turn turn;
    private buttonProperties btn;
    //whether or not this square was used yet

    private bool set;

    private void Awake()
    {
        SceneManager man = SceneManager.Instance;
        player = man.player;
        turn = man.turn;
        set = false;
    }
    private void OnMouseDown()
    {
        //check if turn
        if ((turn.player1Turn && player.isPlayer1 || (!turn.player1Turn && !player.isPlayer1))  && !turn.gameOverBool  && set == false && SceneManager.Instance.turn.mode== "twoPlayerLocal")
        {
            set = true;
            render.enabled = true;
            if (player.circles)
            {
                render.sprite = circle;
            }
            else
                render.sprite = cross;
            this.enabled = false;
            turn.endTurn(render.GetComponentInParent<buttonProperties>());
        }
        if ((turn.player1Turn && player.isPlayer1 || (!turn.player1Turn && !player.isPlayer1)) && !turn.gameOverBool && set == false && turn.mode == "AI")
        {

            set = true;
            render.enabled = true;
            if (player.circles)
            {
                turn.AI();
                int choice = Random.Range(0,turn.choice.Count);
                GameObject choicebutton = GameObject.Find(choice.ToString()) ;

                choicebutton.GetComponent<SpriteRenderer>().sprite = circle;
                Debug.Log("hi");
            }
            else
                render.sprite = cross;
            this.enabled = false;
            turn.endTurn(render.GetComponentInParent<buttonProperties>());

        }



    }

    public bool isSet()
    {
        return set;
    }
    
}
