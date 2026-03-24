using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class GachaPlan
{
    //---消費アイテム種類---
    public GachaExpenseType GachaExpenseType => gachaExpenseType;
    [SerializeField] private GachaExpenseType gachaExpenseType;
    //---消費用アイテム数---
    public int ExpenseItemNum => expenseItemNum;
    [SerializeField] private int expenseItemNum;
}
/// <summary>
/// ガチャを引くのに消費するアイテムの種類
/// </summary>
public enum GachaExpenseType
{
    STONE,
    TICKET
}
