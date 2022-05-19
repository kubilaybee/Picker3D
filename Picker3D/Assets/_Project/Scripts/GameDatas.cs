using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GameDatas", order = 1)]
public class GameDatas : ScriptableObject
{
    public int Score;
    public int Level;
}
