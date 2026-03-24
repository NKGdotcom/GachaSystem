using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ガチャガチャのシステム
/// </summary>
public class GachaSystem : MonoBehaviour
{
    [SerializeField] private CharacterBoxManagement characterBoxManagement;
    [SerializeField] private List<GachaDropRate> gachaDropRate = new List<GachaDropRate>();
    [SerializeField] private List<GachaButtonController> gachaButtonControllerLists = new List<GachaButtonController>();
    private const float SUM_DROP_RATE = 100f;
    private float sumDropRate = 0;

    private List<Character> getCharacterLists = new List<Character>();
    private void Awake()
    {
        if(gachaDropRate == null) { Debug.LogError("gachaDropRateが参照されていません"); return; }

        foreach(var _gacha in gachaDropRate)
        {
            sumDropRate += _gacha.dropRate;
        }
        Debug.Log(sumDropRate);
        if(sumDropRate != SUM_DROP_RATE) { Debug.LogError("ガチャの排出率が100%ではありません"); }

        foreach(var _gachaButton in gachaButtonControllerLists)
        {
            _gachaButton.OnUseItemGacha += SpinGacha;
        }
    }
    /// <summary>
    /// ---ガチャを_spinNum分回す---
    /// ---_spinNumは別のボタンに設定し、Actionから受け取る---
    /// </summary>
    /// <param name="_spinNum"></param>
    public void SpinGacha(int _spinNum)
    {
        getCharacterLists.Clear();

        for (int i = 0; i < _spinNum; i++)
        {
            GachaDropRate _thisGachaDropRate = Rarity();
            Character _thisTimeCharacter = CharacterSelect(_thisGachaDropRate);

            if (_thisTimeCharacter != null)
            {
                getCharacterLists.Add(_thisTimeCharacter);
            }
            else
            {
                Debug.LogWarning("キャラクターの抽選結果がnullになりました。");
            }
        }

        characterBoxManagement.AddCharacter(getCharacterLists);
    }
    /// <summary>
    /// ---レア度抽選---
    /// </summary>
    public GachaDropRate Rarity()
    {
        float _rareRandomValue = UnityEngine.Random.Range(0f, SUM_DROP_RATE);
        float _currentRareRate = 0f;
        GachaDropRate _selectedGroup = null;

        foreach (var _gacha in gachaDropRate)
        {
            _currentRareRate += _gacha.dropRate;
            //---ランダム値が現在の確率の累積値以下なら、そのレア度が当選---
            if (_rareRandomValue <= _currentRareRate)
            {
                _selectedGroup = _gacha;
                break;
            }
        }
        //---浮動小数点の計算誤差でnullになった場合の安全対策---
        if (_selectedGroup == null)
        {
            _selectedGroup = gachaDropRate[gachaDropRate.Count - 1];
        }

        return _selectedGroup;
    }
    /// <summary>
    /// ---_rarityGroupの中からキャラクターを選択---
    /// </summary>
    /// <param name="_rarityGroup"></param>
    /// <returns></returns>
    public Character CharacterSelect(GachaDropRate _rarityGroup)
    {
        _rarityGroup.AddTotalWeight();

        if (_rarityGroup.SumCharacterDropRate <= 0f) return null;

        float _characterRandomValue = UnityEngine.Random.Range(0f, _rarityGroup.SumCharacterDropRate);
        float _currentWightRate = 0f;
        Character _selectedCharacter = null;

        foreach (var _detail in _rarityGroup.dropDetails)
        {
            _currentWightRate += _detail.dischargeWeight;

            if (_characterRandomValue <= _currentWightRate)
            {
                _selectedCharacter = _detail.character;
                break;
            }
        }

        if (_selectedCharacter == null && _rarityGroup.dropDetails.Count > 0)
        {
            _selectedCharacter = _rarityGroup.dropDetails[_rarityGroup.dropDetails.Count - 1].character;
        }

        return _selectedCharacter;
    }
}
