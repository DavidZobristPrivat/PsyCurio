﻿
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


    public void Init(Item _itemIncoming)
    {
        _item = _itemIncoming;
    }
    
    public void CounterMoveUp()
    {
        _selectedTween.Kill(false);
        _MoveToCounterX.Kill(false);
        _MoveToCounterY.Kill(false);
        _MoveToCounterZ.Kill(false);
        _selectedTween = _item.transform.DOLocalMoveY(_item.CounterPosition.y+1.2f, 0.4f, false).SetEase(Ease.Unset); 
    }
    
    public void CounterMoveDown()
    { 
        _MoveToCounterX.Kill(false);
        _MoveToCounterY.Kill(false);
        _MoveToCounterZ.Kill(false);
        _selectedTween.Kill(false);
        _selectedTween = _item.transform.DOLocalMoveY(_item.CounterPosition.y, 0.5f, false).SetEase(Ease.OutBounce);
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