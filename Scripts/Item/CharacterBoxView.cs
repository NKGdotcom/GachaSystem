using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBoxView : MonoBehaviour
{
    [SerializeField] private Image attributeImage; //属性
    private Color purple = new Color32(155, 114, 176, 255);
    private void Awake()
    {
        if(attributeImage == null) { Debug.LogError("attributeImageが参照されていません"); return; }
    }
    /// <summary>
    /// 属性画像をセット
    /// </summary>
    public void SetAttributeImage(Character _thisCharacter)
    {
        switch (_thisCharacter.myAttribute)
        {
            case Attribute.BLUE:
                attributeImage.color = Color.blue;
                break;
            case Attribute.GREEN:
                attributeImage.color = Color.green;
                break;
            case Attribute.PURPLE:
                Debug.Log("紫");
                attributeImage.color = purple;
                break;
            case Attribute.RED:
                attributeImage.color = Color.red;
                break;
            case Attribute.YELLOW:
                attributeImage.color = Color.yellow;
                break;
        }
    }
}
