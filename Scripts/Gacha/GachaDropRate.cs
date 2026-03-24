using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ガチャの排出率
/// </summary>
[CreateAssetMenu(fileName = "RareDropRate",menuName = "Scriptables/GachaDropRate")]
public class GachaDropRate : ScriptableObject
{
    public Rare thisGroupRare; //この排出率のレア度
    public float dropRate; //レア度の排出率
    public List<CharacterDropDetail> dropDetails = new List<CharacterDropDetail>();
    public float SumCharacterDropRate { get; private set; }
    /// <summary>
    /// 合計の重みを加算
    /// </summary>
    public void AddTotalWeight()
    {
        SumCharacterDropRate = 0f;

        foreach (var _detail in dropDetails)
        {
            SumCharacterDropRate += _detail.dischargeWeight;

            if(_detail.character != null)
            {
                _detail.character.SetRare(thisGroupRare);
            }
        }
    }
}
