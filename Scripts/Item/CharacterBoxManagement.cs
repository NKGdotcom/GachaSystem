using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.IO;
/// <summary>
/// キャラクターボックス
/// </summary>
public class CharacterBoxManagement : MonoBehaviour
{
    public static CharacterBoxManagement Instance;
    [SerializeField] private List<BoxExtensionButtonController> boxExtensionButtonLists = new List<BoxExtensionButtonController>();
    public List<CharacterBox> CharacterLists => characterLists; 
    [SerializeField] private List<CharacterBox> characterLists = new List<CharacterBox>();
    [SerializeField] private CharacterBoxTextView characterBoxTextView;

    private int characterNum = 0;
    [SerializeField] private int maxCharacterNum = 100;

    [SerializeField] private CharacterBox characterBoxPrefab; // 生成するプレハブ本体
    [SerializeField] private Transform boxContentParent;      // 生成したプレハブを入れる親（ScrollViewのContentなど）

    private string SaveFilePath => Application.persistentDataPath + "/savedata.json";
    private void Awake()
    {
        if(Instance == null) Instance = this;

        if(characterLists == null) { Debug.LogError("boxExtensionButtonListsが参照されていません"); return; }

        Load();

        characterBoxTextView.UpdateText(characterLists.Count);

        foreach(var _button in boxExtensionButtonLists)
        {
            _button.OnClick += AddCharacterBox;
        }
    }
    /// <summary>
    /// 最大キャラクターボックスの追加
    /// </summary>
    public void AddCharacterBox(int _addBoxNum)
    {
        maxCharacterNum += _addBoxNum;
    }
    /// データの保存
    /// </summary>
    public void Save()
    {
        PlayerSaveData saveData = new PlayerSaveData();
        saveData.maxBoxNum = maxCharacterNum;

        // UI（CharacterBox）の中から、中身のキャラクターデータだけを取り出して保存リストに入れる
        foreach (var box in characterLists)
        {
            if (box.MyCharacter != null)
            {
                saveData.characters.Add(box.MyCharacter);
            }
        }

        // データをJSON（文字列）に変換して、スマホやPCの本体に書き込む
        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(SaveFilePath, json);
        Debug.Log($"セーブ完了！ 保存先: {SaveFilePath}");
    }

    /// <summary>
    /// データの読み込み
    /// </summary>
    public void Load()
    {
        // セーブデータが存在するかチェック
        if (File.Exists(SaveFilePath))
        {
            string json = File.ReadAllText(SaveFilePath);
            PlayerSaveData loadData = JsonUtility.FromJson<PlayerSaveData>(json);

            maxCharacterNum = loadData.maxBoxNum;

            // 読み込んだキャラクターリストを AddCharacter に渡して、UIを生成・並び替えしてもらう
            // （この時またSaveが呼ばれてしまいますが、特に実害はないので大丈夫です）
            AddCharacter(loadData.characters);

            Debug.Log("ロード完了！キャラクターを復元しました。");
        }
    }



/// <summary>
/// キャラクターの追加
/// </summary>
/// <param name="_getCharacterLists"></param>
    public void AddCharacter(List<Character> _getCharacterLists)
    {
        foreach (Character _character in _getCharacterLists)
        {
            Debug.Log("生成");
            CharacterBox _characterBox = Instantiate(characterBoxPrefab, boxContentParent);

            // 生成したプレハブ（のスクリプト）にキャラクター情報を渡す
            _characterBox.SetMyCharacter(_character);

            characterNum++;
            characterLists.Add(_characterBox);
            characterBoxTextView.UpdateText(characterLists.Count);
        }

        var sortedList = characterLists
            .Where(box => box != null && box.MyCharacter != null)
            .OrderBy(box => box.MyCharacter.myAttribute)          // 属性順（指定の順番）
            .ThenByDescending(box => box.MyCharacter.MyRare)      // 同じ属性の中ではレア度が高い順
            .ToList();

        // インスペクターの表示を壊さずにリストの中身を入れ替える
        characterLists.Clear();
        characterLists.AddRange(sortedList);

        // UI画面上の並び順（ヒエラルキーの順番）も更新する
        for (int i = 0; i < characterLists.Count; i++)
        {
            characterLists[i].transform.SetSiblingIndex(i);
        }
        Save();
    }
    /// <summary>
    /// ボックスよりも所持量が多い
    /// </summary>
    /// <returns></returns>
    public static bool IsOverBox() // static を追加
    {
        if (Instance == null) return false;

        return Instance.maxCharacterNum <= Instance.characterNum;
    }
}

/// <summary>
/// セーブデータ用のクラス
/// </summary>
[System.Serializable]
public class PlayerSaveData
{
    public int maxBoxNum;
    public List<Character> characters = new List<Character>();
}