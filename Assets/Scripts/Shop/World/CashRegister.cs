using PsyCurio;
using UnityEngine;
using UnityEngine.Events;

public class CashRegister : MonoBehaviour,IMouseOver
{
#pragma warning disable CS0649
    [SerializeField] private UnityEvent onClick;
    [SerializeField] private QuickOutline _quickOutline;

    private void Awake()
    {
        _quickOutline.OutlineWidth = 0f;
    }
    
    public void OnSelect()
    {
        _quickOutline.enabled = true;
        _quickOutline.OutlineWidth = 4.1f;
    }

    public void OnDeselect()
    {
        _quickOutline.enabled = false;
   
  
    }

    public void OnClick()
    {
        onClick?.Invoke();
    }
}
