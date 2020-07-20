using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace PsyCurio
{

    public class Counter : MonoBehaviour
    {
#pragma warning disable CS0649
        [SerializeField] private int maximumItems = 5;
        [SerializeField] private float distanceBetweenObject = 1.4f;
        [SerializeField] private Transform spawnedItems;
        public List<GameObject> itemSlots = new List<GameObject>();
        public UnityAction onListChanged;
        public StringUnityEvent onListFull;
        
        private void Awake()
        {
            for (int iterator = maximumItems; iterator > 0; iterator--)
            {
                itemSlots.Add(null);
            }
        }

        public void TryAddItem(GameObject _itemToAdd)
        {
            // There could be effects or a tween here, prevent interaction until this finished
            
            int index = itemSlots.FindIndex(slotIsEmpty => slotIsEmpty == null);
            //Debug.Log("index " + index);

            if (index == -1)
            {
                UIShop _uiShop = FindObjectOfType<UIShop>();
                
                if (_uiShop != null && _uiShop.gameObject.activeSelf)
                {
                    onListFull?.Invoke("Buy now or remove an item out of your list.");
                }
                else
                {
                    onListFull?.Invoke("That's enough! Click on the cash register.");
                }
                
                return;
            }

            GameObject tempGameObject = Instantiate(_itemToAdd.gameObject, spawnedItems);
            
            Item tempItem = tempGameObject.GetComponent<Item>();
           tempItem.InitCountObject(distanceBetweenObject,index);
           tempItem.transform.position = _itemToAdd.transform.position;
            itemSlots[index] = tempGameObject;
            
            onListChanged?.Invoke();
        }

        public void RemoveItem(GameObject _itemToRemove)
        {
            // There could be effects or a tween here, prevent interaction until this finished
            DestroyImmediate(_itemToRemove);
            onListChanged?.Invoke();
        }


     
    }
}