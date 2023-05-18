using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Latte : MonoBehaviour, IConsumable
{
    void IConsumable.Consume()
    {
        Debug.Log("You drink latte");
        Destroy(gameObject);
    }
    void IConsumable.Consume(CharacterStat stat)
    {
        Debug.Log("latte latte latte latte");
    }
}
