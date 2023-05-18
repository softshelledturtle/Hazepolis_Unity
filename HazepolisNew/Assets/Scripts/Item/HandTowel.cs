using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandTowel : MonoBehaviour, IConsumable
{
    void IConsumable.Consume()
    {
        Debug.Log("You find a hand towel");
        Destroy(gameObject);
    }
    void IConsumable.Consume(CharacterStat stat)
    {
        Debug.Log("You find a pink hand towel");
    }
}
