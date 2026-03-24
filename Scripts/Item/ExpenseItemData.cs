using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 消費アイテムデータをまとめた物
/// </summary>
[CreateAssetMenu(fileName = "ExpenseItemData", menuName = "Scriptables/ExpenseItemData")]
public class ExpenseItemData : ScriptableObject
{
    public List<ExpenseItem> ExpenseItems => expenseItems;
    [SerializeField] private List<ExpenseItem> expenseItems = new List<ExpenseItem>();
}
/// <summary>
/// 消費アイテムの種類
/// </summary>
[System.Serializable]
public class ExpenseItem
{
    public GachaExpenseType myType;
    public int haveItemNum;
    public void Expense(int _expenseNum)
    {
        haveItemNum -= _expenseNum;
    }
}
