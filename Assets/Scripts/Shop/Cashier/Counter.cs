using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace PsyCurio
{
    public class Counter : MonoBehaviour
    { 
        #pragma warning disable CS0649 
        [SerializeField] private int maximumItems = 5;
        [SerializeField] private float distanceBetweenObject = 1.4f;  
        [SerializeField] private Transform spawnedItems;
      
      public void TryAddItem(Item _itemToAdd)
      {
          if (spawnedItems.childCount < maximumItems)
          {
              
              GameObject tempGameObject = Instantiate(_itemToAdd.prefab,spawnedItems);
             
              
              Item tempItem = tempGameObject.GetComponent<Item>();
              tempItem.isOnCounter = true;
          
              
              tempGameObject.transform.localPosition = new Vector3(0,0, (distanceBetweenObject*spawnedItems.childCount));
              tempGameObject.transform.localScale = Vector3.one;
             
          }
      }

  

      public void GetPriceSum()
      {
          
      }
      
    }

    
}
