using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// ボタンのベースとなる部分
/// </summary>
public class BaseButton : MonoBehaviour, IButton, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    /// <summary>
    /// ボタンを押す
    /// </summary>
    public virtual void ButtonDown()
    {

    }
    /// <summary>
    /// ボタンを離す
    /// </summary>
    public virtual void ButtonUp()
    {

    }
    /// <summary>
    /// ボタンクリック
    /// </summary>
    public virtual void ButtonClick()
    {

    }
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        ButtonDown();
    }
    public virtual void OnPointerUp(PointerEventData eventData)
    {
        ButtonUp();
    }
    public virtual void OnPointerClick(PointerEventData eventData)
    {
        ButtonClick();
    }
}
