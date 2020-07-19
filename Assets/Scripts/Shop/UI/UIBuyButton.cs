using PsyCurio;
using TMPro;
using UnityEngine;

public class UIBuyButton : MonoBehaviour
{
#pragma warning disable CS0649
    [SerializeField] private TextMeshProUGUI _buyButtonPriceTxt;
    private UIShop _uiShop;

    public void Initialize(UIShop _uiShopSent)
    {
        _uiShop = _uiShopSent;
    }
    
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
        //..if interactable (enough currency)
        
        foreach (GameObject current in _uiShop._counter.itemSlots)
        {
            // Subtract total price 
            // Add items to inventory
            _uiShop._counter.RemoveItem(current);
        }
        _uiShop.ToggleOnOff();
    }
}
