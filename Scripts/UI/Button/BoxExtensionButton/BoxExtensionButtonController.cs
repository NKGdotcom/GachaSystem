using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxExtensionButtonController : BaseButton
{
    [SerializeField] private BoxExtensionButtonView buttonView;
    [SerializeField] private int extendNum = 5; //拡張数
    public event Action<int> OnClick;
    /// <summary>
    /// ボタンを押す
    /// </summary>
    public override void ButtonDown()
    {
        buttonView.DarkenColor();
    }
    /// <summary>
    /// ボタンを離す
    /// </summary>
    public override void ButtonUp()
    {
        buttonView.RestoreColor();
    }
    /// <summary>
    /// ボタンクリック
    /// </summary>
    public override void ButtonClick()
    {
        OnClick?.Invoke(extendNum);

        buttonView.RestoreColor();
    }
}
