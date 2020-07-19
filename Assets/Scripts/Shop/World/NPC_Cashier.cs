using UnityEngine;

namespace PsyCurio
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Collider))]
    public class NPC_Cashier : MonoBehaviour, IMouseOver // Probably would inherit from a parent class NPC
    {
        private Animator _animator;
#pragma warning disable CS0649
        [SerializeField] private QuickOutline _quickOutline;
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _quickOutline.OutlineWidth = 0f;

        }
        
        public void OnSelect()
        {
            // Add some nice effect
            _quickOutline.OutlineWidth = 3.5f;
            _quickOutline.enabled = true;

        }

        public void OnDeselect()
        {
            // Add some nice effect
            _quickOutline.enabled = false;
           
        }

        public void OnClick()
        {
            _animator.SetTrigger("Clicked");
        }
    }
}