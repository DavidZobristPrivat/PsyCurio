using UnityEngine;

namespace PsyCurio
{
    public class Item : MonoBehaviour, IMouseOver 
        // Item could also be a base class of child's but for this task it would be over engineered
    {
#pragma warning disable CS0649,CS0108 
        // Disable warnings that appear with SerializeField

        [SerializeField] private Renderer renderer;
        [SerializeField] private Material highlightMaterial;
        
        private Material defaultMaterial;
        private Counter _counter;

        public bool isOnCounter;
        
        public ItemData _itemData; // in a bigger game they could be scriptable objects that are loaded by id

        private void Awake()
        {
            defaultMaterial = renderer.material;
            _itemData.color =   defaultMaterial.color;  // instead of an image for this test task, I pass the color to the ui version for representation
            _counter = FindObjectOfType<Counter>();
        }

        public void OnSelect()
        {
            // No null check better to get / see the reference error
            renderer.material = this.highlightMaterial;
        }


        public void OnDeselect()
        {
            renderer.material = this.defaultMaterial;
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