using YG;
using UnityEngine;
using TMPro;
public class Money : MonoBehaviour
{
    private static int currency;
    private Turn turn;
    [SerializeField] private TMP_Text currencyText;

    private void Start()
    {
        if (YandexGame.SDKEnabled == true)
            LoadSaveCloud();
        YandexGame.FullscreenShow();
    }
    public void GetMoney()
    {

        if (turn.gameOverBool) currency += 10;
        currencyText.text = currency.ToString();
        MySave();
    }
    private void OnEnable() => YandexGame.GetDataEvent += LoadSaveCloud;
    private void OnDisable() => YandexGame.GetDataEvent += LoadSaveCloud;

    public void LoadSaveCloud()
    {
        currencyText.text = YandexGame.savesData.money.ToString();
        

    }
    
    public void MySave()
    {
        YandexGame.savesData.money = currency;
        YandexGame.SaveProgress();

    }
}
