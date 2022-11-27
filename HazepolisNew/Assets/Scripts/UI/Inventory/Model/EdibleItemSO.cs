using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Inventory.UI;

namespace Inventory.Model
{
    [CreateAssetMenu]
    public class EdibleItemSO : ItemSO, IDestroybleItem, IItemAction
    {
        [SerializeField]
        private List<ModifierData> modifiersData = new List<ModifierData>();

        public string ActionName => "Consume";
        public AudioClip actionSFX { get; private set; }

        public bool PerformAction(GameObject charater)
        {
            foreach (ModifierData data in modifiersData)
            {
                data.statModifier.AffectCharacter(charater, data.value);
            }
            return true;
        }
    }

    public interface IDestroybleItem 
    { 
    
    }

    public interface IItemAction
    { 
        public string ActionName { get; }
        public AudioClip actionSFX { get; }
        public bool PerformAction(GameObject charater);
    }

    [Serializable]
    public class ModifierData
    {
        public CharacterStatModifierSO statModifier;
        public float value;
    }
}