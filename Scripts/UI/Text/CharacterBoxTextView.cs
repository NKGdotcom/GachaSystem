using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBoxTextView : MonoBehaviour
{
    [SerializeField] Text characterBoxText;

    public void UpdateText(int _cahacterBoxNum)
    {
        characterBoxText.text = _cahacterBoxNum.ToString() + "ŒÂ";
    }
}
