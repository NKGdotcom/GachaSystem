using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GachaButtonController : BaseButton
{
    //---ガチャの見た目---
    [SerializeField] private GachaButtonView gachaButtonView;
    //---ガチャ消費と得られるもの---
    [SerializeField] private GachaPlan gachaPlan;
    public event Action<GachaPlan> OnClickGacha;
    //---ガチャで使用するアイテム---
    [SerializeField] private int extensionNum;
    public event Action<int> OnUseItemGacha;

    void Awake()
    {
        if(gachaButtonView == null) { Debug.LogError("gachaButtonViewが参照されていません"); return; }
        if(gachaPlan == null) { Debug.LogError("gachaPlanが参照されていません"); return; }
    }
    /// <summary>
    /// ボタンを押す
    /// </summary>
    public override void ButtonDown()
    {
        gachaButtonView.DarkenColor();
    }
    /// <summary>
    /// ボタンを離す
    /// </summary>
    public override void ButtonUp()
    {
        gachaButtonView.RestoreColor();
    }
    /// <summary>
    /// ボタンクリック
    /// </summary>
    public override void ButtonClick()
    {
        OnClickGacha?.Invoke(gachaPlan);
        OnUseItemGacha?.Invoke(extensionNum);

        gachaButtonView.RestoreColor();
    }
}
