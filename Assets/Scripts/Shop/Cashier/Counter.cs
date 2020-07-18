using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PsyCurio
{
    public class Counter : MonoBehaviour
    {
#pragma warning disable CS0649
        [SerializeField] private int maximumItems = 5;
        [SerializeField] private float distanceBetweenObject = 1.4f;
        [SerializeField] private Transform spawnedItems;
        private  List<GameObject> openItemPosition = new List<GameObject>();
        public UnityAction onListChanged;
        
        private void Awake()
        {
            for (int iterator = maximumItems; iterator > 0; iterator--)
            {
                openItemPosition.Add(null);
            }
        }

        public void TryAddItem(GameObject _itemToAdd)
        {
            int index = openItemPosition.FindIndex(slotIsEmpty => slotIsEmpty == null);
            //Debug.Log("index " + index);

            if (index == -1)
            {
                Debug.Log("Counter is full. Remove an item first.");
                return;
            }

            GameObject tempGameObject = Instantiate(_itemToAdd.gameObject, spawnedItems);

            Item tempItem = tempGameObject.GetComponent<Item>();
                tempItem.isOnCounter = true;
                tempGameObject.transform.localPosition = new Vector3(0, 0, (distanceBetweenObject * index));
                tempGameObject.transform.localScale = Vector3.one;
                
            openItemPosition[index] = tempGameObject;
            
            onListChanged?.Invoke();
        }

        public void RemoveItem(GameObject _itemToRemove)
        {
            Destroy(_itemToRemove);
            
            onListChanged?.Invoke();
        }


     
    }
}