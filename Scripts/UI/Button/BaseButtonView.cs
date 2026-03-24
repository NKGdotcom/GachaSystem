using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseButtonView : MonoBehaviour
{
    [SerializeField] private Image buttonImage;
    private Color grayColor = Color.gray;
    private Color restoreColor;
    public void Awake()
    {
        if (buttonImage == null) { TryGetComponent<Image>(out buttonImage); }
        restoreColor = buttonImage.color;
    }
    /// <summary>
    /// 見た目の色が暗くなる
    /// </summary>
    public virtual void DarkenColor()
    {
        Debug.Log("ボタンを押す");
        buttonImage.color = grayColor;
    }
    /// <summary>
    /// 見た目の色が元に戻る
    /// </summary>
    public virtual void RestoreColor()
    {
        Debug.Log("ボタンを離す");
        buttonImage.color = restoreColor;
    }
}
