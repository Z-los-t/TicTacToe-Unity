
using UnityEngine;

public class click : MonoBehaviour
{
    [SerializeField] private Sprite circle;
    [SerializeField] private Sprite cross;
    [SerializeField] private SpriteRenderer render;
    private Player player;
    private Turn turn;

    //whether or not this square was used yet

    public bool set ;

    private void Awake()
    {
        SceneManagerr man = SceneManagerr.Instance;
        player = man.player;
        turn = man.turn;
        set = false;
        if (turn.mode=="AI")
        turn.AIChoosing();
    }
    private void OnMouseDown()
    {
        //check if turn
        if ((turn.player1Turn && player.isPlayer1 || (!turn.player1Turn && !player.isPlayer1))  && !turn.gameOverBool  && set == false && SceneManagerr.Instance.turn.mode== "twoPlayerLocal")
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
        if ((turn.player1Turn && player.isPlayer1) && !turn.gameOverBool && set == false && SceneManagerr.Instance.turn.mode == "AI"&&render.enabled==false)
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
