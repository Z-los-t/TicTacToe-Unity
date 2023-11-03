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

    //whether or not this square was used yet

    private bool set;

    private void Awake()
    {
        SceneManager man = SceneManager.Instance;
        player = man.player;
        turn = man.turn;
        set = false;
        turn.AIChoosing();
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
        if ((turn.player1Turn && player.isPlayer1) && !turn.gameOverBool && set == false && SceneManager.Instance.turn.mode == "AI"&&render.enabled==false)
        {

            set = true;
            render.enabled = true;
          
                render.sprite = cross;
            this.enabled = false;
            turn.endTurn(render.GetComponentInParent<buttonProperties>());
            turn.AI();
            
           

        }



    }

    public bool isSet()
    {
        return set;
    }
    
}
