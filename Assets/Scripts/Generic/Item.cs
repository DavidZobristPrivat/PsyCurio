using UnityEngine;

namespace PsyCurio
{
    public class Item : MonoBehaviour, IMouseOver
    {
        #pragma warning disable CS0649,CS0108 // Disable warnings that appear with SerializeField
        
        [SerializeField] private Renderer renderer;
        [SerializeField] private Material highlightMaterial;
     
        
        private Material defaultMaterial;
        private Counter _counter;
        
        public bool isOnCounter;
      
        
        private void Awake()
        {
            defaultMaterial = renderer.material;
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
          
                Destroy(gameObject);
            }
          
        }
        
    }
}