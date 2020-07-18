using System;
using PsyCurio;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIShopElement : MonoBehaviour
{
#pragma  warning disable CS0649
   [SerializeField] private TextMeshProUGUI _priceTxt;
   [SerializeField] private TextMeshProUGUI _nameTxt;
   [SerializeField] private Image _image;
   public ItemData _itemData;
   
   public void SetValues(ItemData _itemDataIncoming)
   {
       _itemData = _itemDataIncoming;
       _nameTxt.text = _itemDataIncoming.name;
       _priceTxt.text = "$" + _itemDataIncoming.price;
       _image.color = _itemDataIncoming.color;
   }
}
