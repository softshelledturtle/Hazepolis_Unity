using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gummy : MonoBehaviour, IConsumable
{
    void IConsumable.Consume()
    {
        Debug.Log("Gummy Gummy Gummy Gummy");
        Destroy(gameObject);
    }

    void IConsumable.Consume(CharacterStat stat)
    {
        Debug.Log("You drink a swig of the coffee. Americano!");
    }
}
