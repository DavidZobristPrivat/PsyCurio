
using DG.Tweening;
using UnityEngine;

namespace PsyCurio
{
    

public class itemTweener
{
    private Item _item;
    
    private Tween _selectedTween;
    
    private Tween _MoveToCounterX;
    private Tween _MoveToCounterY;
    private Tween _MoveToCounterZ;

    private bool blocked;

    public void Init(Item _itemIncoming)
    {
        _item = _itemIncoming;
        Application.quitting += () =>
        {
            blocked = true;
            DOTween.KillAll();
        };
    }
    
    public void CounterMoveUp()
    {
        if(blocked){return;}
        _selectedTween.Kill(false);
        _MoveToCounterX.Kill(false);
        _MoveToCounterY.Kill(false);
        _MoveToCounterZ.Kill(false);
      
      _selectedTween = _item.transform.DOLocalMove(new Vector3(_item.CounterPosition.x,_item.CounterPosition.y+1.2f,_item.CounterPosition.z), 0.4f, false).SetEase(Ease.Unset); 
    }
    
    public void CounterMoveDown()
    { 
        if(blocked){return;}
        _MoveToCounterX.Kill(false);
        _MoveToCounterY.Kill(false);
        _MoveToCounterZ.Kill(false);
        _selectedTween.Kill(false);
      
        _selectedTween = _item.transform.DOLocalMove(_item.CounterPosition, 0.5f, false).SetEase(Ease.OutBounce);
    }

    public void MoveToCounter()
    {
  
       _MoveToCounterX = _item.transform.DOLocalMoveX(0, 0.8f);
       _MoveToCounterY =  _item.transform.DOMoveY(8, 0.6f).SetEase(Ease.OutExpo).OnComplete(()=>  _item.transform.DOLocalMoveY(0, 0.2f).SetEase(Ease.OutBounce));
       _MoveToCounterZ = _item.transform.DOLocalMoveZ(_item.CounterPosition.z, 0.8f);
    }


    ~itemTweener()
    {
        DOTween.Kill(this);
    }

  
}
}