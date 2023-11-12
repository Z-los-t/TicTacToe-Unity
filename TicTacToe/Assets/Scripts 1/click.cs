
using UnityEngine;

public class click : MonoBehaviour
{
    private Sprite circle;
     private Sprite cross;
     private SpriteRenderer render;
    private Player player;
    private Turn turn;
    public static string xSprite= "Xneon";
    private buttonProperties btn;
    //whether or not this square was used yet

    public bool set ;

    private void Awake()
    {
        SceneManagerr man = SceneManagerr.Instance;
        player = man.player;
        turn = man.turn;
        set = false;
        render = gameObject.GetComponent<SpriteRenderer>();

         btn = render.GetComponentInParent<buttonProperties>();
        cross = Resources.Load<Sprite>(xSprite);
        circle = Resources.Load<Sprite>(Turn.oSprite);
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
            turn.endTurn(btn);
            
        }
        if ((turn.player1Turn && player.isPlayer1) && !turn.gameOverBool && set == false && SceneManagerr.Instance.turn.mode == "AI")
        {
            
            set = true;
            render.enabled = true;
          
                render.sprite = cross;
            this.enabled = false;
            turn.endTurn(btn);
            turn.AI();



        }



    }

    public bool isSet()
    {
        return set;
    }
    
}
