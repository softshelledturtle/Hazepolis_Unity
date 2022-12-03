using System.Collections.Generic;
using UnityEngine;
public class CharacterStat
{
    public List<BaseStat> stats = new List<BaseStat>();

    public CharacterStat(int sanity)
    {
        stats = new List<BaseStat>() { 
            new BaseStat(BaseStat.BaseStatType.Sanity, sanity, "Sanity")        
        };
    }

    public BaseStat GetStat(BaseStat.BaseStatType stat)
    {
        return this.stats.Find(x => x.StatType == stat);
    }

    public void AddStatBonus(List<BaseStat> statBonuses)
    {
        foreach(BaseStat statBonus in statBonuses)
        {
            GetStat(statBonus.StatType).AddStatBonus(new StatBonus(statBonus.BaseValue));
        }
    }

    public void RemoveStatBonus(List<BaseStat> statBonuses)
    {
        foreach (BaseStat statBonus in statBonuses)
        {
            GetStat(statBonus.StatType).RemoveStatBonus(new StatBonus(statBonus.BaseValue));
        }
    }
}
