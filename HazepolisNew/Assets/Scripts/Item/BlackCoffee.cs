using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackCoffee : MonoBehaviour, IConsumable
{
    void IConsumable.Consume()
    {
        Debug.Log("You drink balck coffee");
        Destroy(gameObject);
    }
    void IConsumable.Consume(CharacterStat stat)
    {
        Debug.Log("balck balck balck coffee");
    }
}

