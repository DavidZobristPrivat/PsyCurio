using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PsyCurio
{
    public class UIShopElement : MonoBehaviour
    {
#pragma warning disable CS0649
        [SerializeField] private TextMeshProUGUI _priceTxt;
        [SerializeField] private TextMeshProUGUI _nameTxt;
        [SerializeField] private Image _image;
        [HideInInspector] public Item _item;
        private Counter _counter;
        
        void Awake()
        {
            _counter = FindObjectOfType<Counter>();
        }

        public void SetValues(Item _incomingItem)
        {
            _item = _incomingItem;
            _nameTxt.text = _item._itemData.name;
            _priceTxt.text = "$" + _item._itemData.price;
            _image.color = _item._itemData.color;
        }

        public void RemoveItem()
        {
            if (_counter == null)
            {
                Debug.LogWarning("Missing Counter. Add the counter to the scene");
                return;
            }

            _counter.RemoveItem(_item.gameObject);
        }

        public void onSelect()
        {
            _item._ItemTweener.CounterMoveUp();
        }
        
        public void onDeselect()
        {
            _item._ItemTweener.CounterMoveDown();
        }

        public void DestroyProperly()
        {
            Destroy(gameObject);
        }
    }
}