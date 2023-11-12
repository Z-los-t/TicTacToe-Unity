
using UnityEngine;
using UnityEngine.SceneManagement;
public class Select : MonoBehaviour
{
    [SerializeField] private string xSkin;
    [SerializeField] private string oSkin;
    [SerializeField] private string Backg;
    [SerializeField] private string Grid;


    public void Selectable()
    {

        Turn.oSprite = oSkin;
        click.xSprite = xSkin;
        backgngridchanger.BackgSprite = Backg;
        backgngridchanger.GridSprite = Grid;
        SceneManager.LoadScene(1);

    }

}
