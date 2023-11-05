
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Turn : MonoBehaviour
{
    public bool player1Turn { get; private set; }
    public bool gameOverBool { get; private set; }
    [SerializeField] private  Sprite circle;
    //twoPlayerLocal
    //AI
    private GameObject[] areas;
    public string mode;
    private int lastAmountWon;
    
    private bool firstTurn;
    
    [SerializeField] private GameObject[] buttons; 
    private List<int> choice = new List<int>();
    private void Awake()
    {
        player1Turn = true;
        lastAmountWon = 0;
        gameOverBool = false;
        //changed for debugging firstTurn = true;
        firstTurn = false;
        buttons= GameObject.FindGameObjectsWithTag("Button");
        areas = GameObject.FindGameObjectsWithTag("Area"); 
    }

    public void endTurn(buttonProperties btn)
    {
        if(firstTurn)
        {
            firstTurn = false;
           
        }
        if (noWin())
        {
            SceneManager.LoadScene(0);
        }
        checkSmallWinner(btn);
        checkBigWinner(btn);

        if (!gameOverBool)
        {
            player1Turn = !player1Turn;

            if (mode == "twoPlayerLocal"|| mode == "AI")
            {
                Player player = SceneManagerr.Instance.player;
                player.circles = !player.circles;
                player.isPlayer1 = !player.isPlayer1;
            }
         
           

            bool nextBoardFull = adjustButtons(btn);
            adjustAreas(btn, nextBoardFull);
        }
    }
    public void AIChoosing()
    {
        


        choice.Clear();
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i].GetComponent<BoxCollider2D>().enabled == true)

                choice.Add(i);



        }


     
    }

    public void AI( )
    {
        AIChoosing();

        int choiceNumber = Random.Range(0, choice.Count);
        foreach (GameObject button in buttons)
        {
            click Click = button.GetComponent<click>();
            if ((choice[choiceNumber].ToString() == button.name) && Click.isSet() == false)
            {
                
                SpriteRenderer choicebutton = GameObject.Find(choice[choiceNumber].ToString()).GetComponent<SpriteRenderer>();
                choicebutton.enabled = true;
                choicebutton.sprite = circle;
                Click.set = true;
                endTurn(choicebutton.GetComponentInParent<buttonProperties>());
                
            }
            else if ((choice[choiceNumber].ToString() == button.name) && Click.isSet() == true) {

                AI();
            
            }

        }

    }
   
    private bool noWin()
    { int check = 0;
        foreach (GameObject Button in buttons) {
            if (Button.GetComponent<click>().set == true)
            {

                check++;
            }
            
        }
        if (check == 81)
            return true;
        else return false;
    }
    private bool adjustButtons(buttonProperties btn)
    {
        //check if board sent to is full
        string bigBoardCheck = btn.locationSmallBoard;    
        bool nextBoardFull = false;
        int used = 0;
        foreach (GameObject button in buttons)
        {
            if (button.GetComponent<click>().isSet() && button.GetComponent<buttonProperties>().locationBigBoard == bigBoardCheck) used++;
        }
        
        if (used == 9) nextBoardFull = true;
        
        foreach(GameObject button in buttons)
        {
            buttonProperties prop = button.GetComponent<buttonProperties>();
            if(prop.locationBigBoard == btn.locationSmallBoard || nextBoardFull)
            {
                button.GetComponent<BoxCollider2D>().enabled = true;
            } else
            {
                button.GetComponent<BoxCollider2D>().enabled = false;
            }
        }

        return nextBoardFull;
    }
    
    private void adjustAreas(buttonProperties btn, bool nextBoardFull)
    {
        foreach(GameObject area in areas)
        {
            if(area.transform.parent.name == btn.locationSmallBoard || nextBoardFull)
            {
                area.GetComponent<SpriteRenderer>().enabled = false;
                
            } else
            {
                area.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }
    /*  
     *  Check the mini board that was just played in for a winner
     */
    private void checkSmallWinner(buttonProperties btn)
    {
        //no use checking for a winner if the mini board is already won
        if (!btn.transform.parent.GetComponent<areaProperties>().areaWon)
        {
            string symbol = "Xbasic";
            if (SceneManagerr.Instance.player.circles) symbol = "Obasic";
            //check rows for winner
            for (int i = 0; i < 9; i = i + 3)
            {
                if (btn.transform.parent.GetChild(i).GetComponent<SpriteRenderer>().sprite.name == symbol &&
                    btn.transform.parent.GetChild(i + 1).GetComponent<SpriteRenderer>().sprite.name == symbol &&
                    btn.transform.parent.GetChild(i + 2).GetComponent<SpriteRenderer>().sprite.name == symbol)
                {
                    btn.transform.parent.GetComponent<areaProperties>().setWinner(symbol);
                } 
            }
            //check columns for winner
            for (int i = 0; i < 3; i++)
            {
                if (btn.transform.parent.GetChild(i).GetComponent<SpriteRenderer>().sprite.name == symbol &&
                    btn.transform.parent.GetChild(i + 3).GetComponent<SpriteRenderer>().sprite.name == symbol &&
                    btn.transform.parent.GetChild(i + 6).GetComponent<SpriteRenderer>().sprite.name == symbol)
                {
                    btn.transform.parent.GetComponent<areaProperties>().setWinner(symbol);
                }
            }
            //check diagonals for winner
            for (int i = 0, j = 4; i < 3; i = i + 2, j = j - 2)
            {
                if (btn.transform.parent.GetChild(i).GetComponent<SpriteRenderer>().sprite.name == symbol &&
                    btn.transform.parent.GetChild(i + j).GetComponent<SpriteRenderer>().sprite.name == symbol &&
                    btn.transform.parent.GetChild(i + 2 * j).GetComponent<SpriteRenderer>().sprite.name == symbol)
                {
                    btn.transform.parent.GetComponent<areaProperties>().setWinner(symbol);
                }
            }
        }
    }

    private void checkBigWinner(buttonProperties btn)
    {
        //check if a new board has been won, no use checking for a winner if the board hasn't changed
        //and check if at least 3 mini boards are won because you need at least 3 to win
        if(lastAmountWon != areaProperties.amountWon && areaProperties.amountWon >= 3)
        {
            lastAmountWon = areaProperties.amountWon;

            string symbol = "Xbasic";
            if (SceneManagerr.Instance.player.circles) symbol = "Obasic";
            GameObject buttons = GameObject.Find("Buttons");
            //check rows for winner
            for(int i = 0; i < 9; i = i + 3)
            {
                if(buttons.transform.GetChild(i).GetComponent<areaProperties>().winner == symbol &&
                    buttons.transform.GetChild(i + 1).GetComponent<areaProperties>().winner == symbol &&
                    buttons.transform.GetChild(i + 2).GetComponent<areaProperties>().winner == symbol)
                {
                    gameOver(symbol);
                    return;
                }
            }

            for(int i = 0; i < 3; i++)
            {
                if(buttons.transform.GetChild(i).GetComponent<areaProperties>().winner == symbol &&
                    buttons.transform.GetChild(i + 3).GetComponent<areaProperties>().winner == symbol &&
                    buttons.transform.GetChild(i + 6).GetComponent<areaProperties>().winner == symbol)
                {
                    gameOver(symbol);
                    return;
                }
            }

            for(int i = 0, j = 4; i < 3; i = i + 2, j = j - 2)
            {
                if(buttons.transform.GetChild(i).GetComponent<areaProperties>().winner == symbol &&
                    buttons.transform.GetChild(i + j).GetComponent<areaProperties>().winner == symbol &&
                    buttons.transform.GetChild(i + 2 * j).GetComponent<areaProperties>().winner == symbol)
                {
                    gameOver(symbol);
                    return;
                }
            }
        }
    }

    private void gameOver(string symbol)
    {
        gameOverBool = true;

        
        foreach (GameObject area in areas)
            area.GetComponent<SpriteRenderer>().enabled = false;

        SpriteRenderer winnerIcon = GameObject.Find("Winner Icon").GetComponent<SpriteRenderer>();
        winnerIcon.sprite = Resources.Load<Sprite>(symbol);
        winnerIcon.enabled = true;
    }
}
