using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeLog : MonoBehaviour, IConsumable
{
    void IConsumable.Consume()
    {
        Debug.Log("You drink a swig of the coffee. Cafe Latte!");
    }

    void IConsumable.Consume(CharacterStat stat)
    {
        Debug.Log("You drink a swig of the coffee. Americano!");
    }
}
