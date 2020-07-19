using PsyCurio;
using TMPro;
using UnityEngine;

public class UIBuyButton : MonoBehaviour
{
#pragma warning disable CS0649
    [SerializeField] private TextMeshProUGUI _buyButtonPriceTxt;
    public UIShop _uiShop;
    
    public void UpdateState(int totalPrice)
    {
        _buyButtonPriceTxt.text = "$" + totalPrice;
        //Check if player has enough currency, best in the currency class itself return bool
        //SetVisualState(bool)
    }

    private void SetVisualState(bool playerHasEnough)
    {
        //..
    }

    public void BuyClick()
    {
        //..
      
    }
}
