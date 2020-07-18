using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace PsyCurio
{
   
public class UIShop : MonoBehaviour
{
    #pragma  warning disable CS0649
    [SerializeField] private GameObject _prefabShopElement;
    [SerializeField] private GameObject _elementHolder;
    private Counter _counter;
    private bool subbed;
    
    private void Awake()
    {
        gameObject.SetActive(false);
        _counter = FindObjectOfType<Counter>();
    }

    public void ToggleOnOff()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    private void OnEnable()
    {
        if (_counter == null)
        {
            return;}
        
        SetList();
        
      if(!subbed)
      {
          subbed = true;  _counter.onListChanged += SetList;}
    }
    
    private void OnDisable()
    {
        if(subbed)
        {
            subbed = false;  _counter.onListChanged -= SetList;}
    }

    private void Clean()
    {
        foreach(Transform child in _elementHolder.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void Populate()
    {

        if (_counter.itemSlots.Count == 0)
        {
            return;}
        
        for (int index = _counter.itemSlots.Count-1; index >= 0; --index) // has to loop from back to front to mirror the position the items on the table.
        {
           // Debug.Log("index " + index);
           
            if (_counter.itemSlots[index] == null)
            {
                continue;
            }
            
            GameObject temp = Instantiate(_prefabShopElement, _elementHolder.transform);
            temp.GetComponent<UIShopElement>().SetValues(_counter.itemSlots[index].gameObject.GetComponent<Item>()._itemData);
        }
            
   
          
            
            

    }


    private void SetList()
    {
        Clean();
        Populate();
    }


 
}    
}
