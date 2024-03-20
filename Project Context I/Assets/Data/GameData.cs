using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Datas/GameData")]
public class GameData : ScriptableObject
{
    // color palette
    [SerializeField] public Color colorOn;
    [SerializeField] public Color colorOff;
    [SerializeField] public Color colorTrue;
    [SerializeField] public Color colorFalse;
}
