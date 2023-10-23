using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SoldierNear : CharacterBase
{
    private object idTarget;
    public override void Start()
    {
        base.Start();
        Run();
    }

    public override void Update()
    {
        base.Update();
        if(Input.GetKeyDown(KeyCode.Space))
            DOTween.Pause(idTarget);
        if(Input.GetKeyDown(KeyCode.X))
            DOTween.Play(idTarget);
    }
    public override void Run()
    {
        base.Run();
        idTarget = transform.DOPath(GameManager.Instance.GetListPoint().ToArray(), 4, PathType.CatmullRom, PathMode.TopDown2D).SetEase(Ease.Linear).target;
    }
}
