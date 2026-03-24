using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// キャラクター
/// </summary>
[Serializable]
public class Character
{
    public Rare MyRare => myRare;//レア度
    [SerializeField] private Rare myRare;
    public Attribute myAttribute; //属性
    public string myName; //キャラクターの名前
    public void SetRare(Rare _setRare)
    {
        myRare = _setRare;
    }
}
/// <summary>
/// キャラクターの排出について
/// </summary>
[Serializable]
public class CharacterDropDetail
{
    public Character character;
    public float dischargeWeight;
}
/// <summary>
/// 属性
/// </summary>
public enum Attribute
{
    BLUE,
    GREEN,
    PURPLE,
    RED,
    YELLOW,
}
/// <summary>
/// レアの種類
/// </summary>
public enum Rare
{
    LR,
    UR,
    SSR,
    SR,
    R,
    N
}
