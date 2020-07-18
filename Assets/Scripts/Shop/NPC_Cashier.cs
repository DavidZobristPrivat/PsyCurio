using System;
using UnityEngine;

namespace PsyCurio
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Collider))]
    public class NPC_Cashier : MonoBehaviour, IMouseOver // Probably would inherit from a parent class NPC
    {
        private Animator _animator;
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        
        public void OnSelect()
        {
            // Add some nice effect
        
            transform.localScale= new Vector3(4.75f,4.75f,4.75f);
        }

        public void OnDeselect()
        {
            // Add some nice effect
            transform.localScale= new Vector3(4.7f,4.7f,4.7f);
        }

        public void OnClick()
        {
            _animator.SetTrigger("Clicked");
        }
    }
}