using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterStat characterStats;

    private void Start()
    {
        characterStats = new CharacterStat(10);
    }
}
