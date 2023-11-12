
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public bool Buyed = false;
    [SerializeField] private Money money;
  
    [SerializeField] private TMP_Text PriceText;

  

    public void Buy()
    {if (Money.currency >= int.Parse(PriceText.text)) { 
            Money.currency= Money.currency-int.Parse(PriceText.text);

        Buyed = true;
        gameObject.SetActive(!Buyed);
        money.currencyText.text = Money.currency.ToString();
        money.BuyedChecker();}
    }







}