using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    public List<BaseStat> stat = new List<BaseStat>();

    private void Start()
    {
        stat.Add(new BaseStat(4, "Sanity", "Your Sanity."));
        stat[0].AddStatBonus(new StatBonus(1));
        Debug.Log(stat[0].GetCalculatedStatValue());
    }
}
