using System;
using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace PsyCurio
{
    public class Item : MonoBehaviour, IMouseOver
        // Item could also be a base class of child's but for this task it would be over engineered
    {
#pragma warning disable CS0649,CS0108
        // Disable warnings that appear with SerializeField

        [SerializeField] private Renderer _renderer;
        [SerializeField] private QuickOutline _quickOutline;
        private Counter _counter;
        public itemTweener _ItemTweener = new itemTweener();
        public Vector3 CounterPosition;
        public bool isOnCounter;

        public ItemData _itemData; // in a bigger game they could be scriptable objects that are loaded by id

        private void Awake()
        {
            _itemData.color = _renderer.material.color; // instead of an image for this test task, I pass the color to the ui version for representation
            _counter = FindObjectOfType<Counter>();
            _quickOutline.OutlineWidth = 0f;
            _ItemTweener.Init(this);
        }

        public void InitCountObject(float distance, int index)
        {
            isOnCounter = true;
            transform.localScale = Vector3.one;
            
            CounterPosition = new Vector3(0, 0, (distance * index));

            _ItemTweener.MoveToCounter();
            
            Destroy(_quickOutline);
            _quickOutline = gameObject.AddComponent<QuickOutline>();
            _quickOutline.OutlineWidth = 0f;
        }
        
        public void OnSelect()
        {
            // No null check better to get / see the reference error
            _quickOutline.enabled = true;
            if (isOnCounter)
            {
                _quickOutline.OutlineColor = Color.red;
                _quickOutline.OutlineWidth = 12f;
            }
            else
            {
                _quickOutline.OutlineColor = Color.white;
                _quickOutline.OutlineWidth = 5.5f;
            }
        }


        public void OnDeselect()
        {
            _quickOutline.enabled = false;
        }

        public void OnClick()
        {
            //  Debug.Log("Clicked");

            if (_counter == null)
            {
                Debug.LogWarning("Be sure to add a Counter to the world first");
                return;
            }

            if (!isOnCounter)
            {
                OnDeselect();
                _counter.TryAddItem(gameObject);
            }
            else
            {
                _counter.RemoveItem(gameObject);
            }
        }
        
        
        
    }
}