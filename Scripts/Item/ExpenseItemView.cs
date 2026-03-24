using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ExpenseItemView : MonoBehaviour
{
    [System.Serializable]
    public class ItemTextMapping
    {
        public GachaExpenseType expenseType;
        public Text countText;
    }

    [SerializeField] private List<ItemTextMapping> itemTextMappings = new List<ItemTextMapping>();
    private void Awake()
    {
        if(itemTextMappings == null) { Debug.LogError("itemTextMappingsÇ™éQè∆Ç≥ÇÍÇƒÇ¢Ç‹ÇπÇÒ"); return; }
    }
    public void UpdateItemText(GachaExpenseType _expenseType, int _haveNum)
    {
        foreach(var _mapping in itemTextMappings)
        {
            if (_mapping.expenseType == _expenseType)
            {
                _mapping.countText.text = _mapping.expenseType.ToString() +"Å~" + _haveNum.ToString();
                return;
            }
        }
    }
}
