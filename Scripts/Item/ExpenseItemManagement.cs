using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 消費アイテムの管理
/// </summary>
public class ExpenseItemManagement : MonoBehaviour
{
    //---ガチャボタン---
    [SerializeField] private List<GachaButtonController> gachaButtonControllerLists = new List<GachaButtonController>();
    //---アイテム管理をしているところ---
    [SerializeField] private ExpenseItemData expenseItemData;
    //---アイテムの数を反映---
    [SerializeField] private ExpenseItemView expenseItemView;
    // Start is called before the first frame update
    void Awake()
    {
        if(gachaButtonControllerLists == null) { Debug.LogError("gachaButtonControllerListsが参照されていません"); return; }
        if(expenseItemData == null) { Debug.LogError("expenseItemDataが参照されていません"); return; }
        if(expenseItemView == null) { Debug.LogError("expenseItemViewが参照されていません"); return; }

        foreach(var _button in gachaButtonControllerLists)
        {
            _button.OnClickGacha += UseItem;
        }

        UpdateItemText();
    }
    /// <summary>
    /// アイテムを使う
    /// </summary>
    /// <param name="_gachaPlan"></param>
    public void UseItem(GachaPlan _gachaPlan)
    {
        foreach(var _item in expenseItemData.ExpenseItems)
        {
            //---アイテムが一致---
            if (_item.myType != _gachaPlan.GachaExpenseType) continue;
            //---現在所有数よりも小さければ抜ける---
            if (_item.haveItemNum < _gachaPlan.ExpenseItemNum) return;
            //---アイテム使う---
            _item.Expense(_gachaPlan.ExpenseItemNum);
            expenseItemView.UpdateItemText(_item.myType, _item.haveItemNum);
            break;
        }
    }
    /// <summary>
    /// アイテム数をテキストに反映
    /// </summary>
    public void UpdateItemText()
    {
        foreach (var _item in expenseItemData.ExpenseItems)
        {
            expenseItemView.UpdateItemText(_item.myType, _item.haveItemNum);
        }
    }
}
