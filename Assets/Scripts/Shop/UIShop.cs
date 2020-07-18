using System;
using UnityEngine;

namespace PsyCurio
{
   
public class UIShop : MonoBehaviour
{
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
       
    }


    private void SetList()
    {
        Clean();
        Populate();
    }
 
}    
}
