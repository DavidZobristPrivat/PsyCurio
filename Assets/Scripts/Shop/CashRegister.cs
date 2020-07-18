using PsyCurio;
using UnityEngine;
using UnityEngine.Events;

public class CashRegister : MonoBehaviour,IMouseOver
{
#pragma warning disable CS0649
    [SerializeField] private UnityEvent onClick;
    
    public void OnSelect()
    {
        transform.localScale= new Vector3(1.03f,1.03f,1.03f);
    }

    public void OnDeselect()
    {
        transform.localScale = Vector3.one;
    }

    public void OnClick()
    {
        onClick?.Invoke();
    }
}
