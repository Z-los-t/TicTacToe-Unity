
using UnityEngine;

public class areaProperties : MonoBehaviour
{
    public bool areaWon { get; private set; }
    public string winner { get; private set; }
    public static int amountWon { get; private set; }

    private void Awake()
    {
        areaWon = false;
        winner = "";
        amountWon = 0;
    }

    public void setWinner(string symbol)
    {
        if(!areaWon)
        {
            SpriteRenderer render = this.transform.Find("winner symbol").GetComponent<SpriteRenderer>();
            amountWon++;
            areaWon = true;
            winner = symbol;
            
             render.sprite= Resources.Load<Sprite>(symbol);
           render.enabled = true;
        }
    }
}
