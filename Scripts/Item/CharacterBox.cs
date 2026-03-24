using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBox : MonoBehaviour
{
    [SerializeField] private CharacterBoxView characterBoxView;
    public Character MyCharacter => character;
    [SerializeField] private Character character;

    public void SetMyCharacter(Character _character)
    {
        character = new Character();

        character.SetRare(_character.MyRare);
        character.myAttribute = _character.myAttribute;
        character.myName = _character.myName;

        characterBoxView.SetAttributeImage(_character);
    }
}
