using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ガチャボタンの見た目の変更
/// </summary>
public class GachaButtonView : BaseButtonView
{
    /// <summary>
    /// 見た目の色が暗くなる
    /// </summary>
    public override void DarkenColor()
    {
        base.DarkenColor();
    }
    /// <summary>
    /// 見た目の色が元に戻る
    /// </summary>
    public override void RestoreColor()
    {
        base.RestoreColor();
    }
}