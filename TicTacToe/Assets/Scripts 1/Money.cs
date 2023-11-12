using YG;
using UnityEngine;
using TMPro;

public class Money : MonoBehaviour
{
    public static int currency;
    private Turn turn;
    public TMP_Text currencyText;
    public GameObject[] buttons;
    public bool[] Buyed;
    [SerializeField] private ShopManager[] management;
    private void Awake()
    {
        if (YandexGame.SDKEnabled == true)
            LoadSaveCloud();
        YandexGame.FullscreenShow();

        buttons = GameObject.FindGameObjectsWithTag("Buy");
       
    }
    private void Update()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(!Buyed[i]);
        }
    }
    public void BuyedChecker()
    {
       
            for (int i = 0; i < buttons.Length; i++)
            {
            ShopManager manager = management[i];
                if (manager.Buyed)
                {

                    Buyed[i] = manager.Buyed;
                MySave();
                }
            }
            
        
    }

    public void GetMoney()
    {

         currency += 50;
        currencyText.text = currency.ToString();
        MySave();
    }
    private void OnEnable() => YandexGame.GetDataEvent += LoadSaveCloud;
    private void OnDisable() => YandexGame.GetDataEvent += LoadSaveCloud;

    public void LoadSaveCloud()
    {
        currency = YandexGame.savesData.money;
        currencyText.text = YandexGame.savesData.money.ToString();
        Buyed = YandexGame.savesData.Buyed;
        if (buttons.Length != 0) { 
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].SetActive(!Buyed[i]);
            }
    }
    }
    
    public void MySave()
    {
        
        YandexGame.savesData.Buyed = Buyed  ;

        YandexGame.savesData.money = currency;
        YandexGame.SaveProgress();

    }



}
