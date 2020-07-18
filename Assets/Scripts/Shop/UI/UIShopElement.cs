using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIShopElement : MonoBehaviour
{
#pragma  warning disable CS0649
   [SerializeField] private TextMeshProUGUI _priceTxt;
   [SerializeField] private TextMeshProUGUI _nameTxt;
   [SerializeField] private Image _image;

   public void SetValues(ItemData _itemData)
   {
       _nameTxt.text = _itemData.name;
       _priceTxt.text = _itemData.price.ToString();
       _image.color = _itemData.color;

   }
}
