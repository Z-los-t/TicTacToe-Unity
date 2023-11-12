
using UnityEngine;

public class backgngridchanger : MonoBehaviour
{
     private Sprite Backg ;
     private Sprite Grid ;
     public static string BackgSprite  ;
     public static string GridSprite ;
    [SerializeField] private SpriteRenderer Gridler;
    [SerializeField] private SpriteRenderer Backger;
    private void Awake()
    {
        Backg = Resources.Load<Sprite>(BackgSprite);
        Grid = Resources.Load<Sprite>(GridSprite);
        Backger.sprite = Backg;
        Gridler.sprite = Grid;
    }


}
