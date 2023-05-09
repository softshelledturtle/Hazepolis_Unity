using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour, IConsumable
{
    void IConsumable.Consume()
    {
        Debug.Log("You open a Letter!");
        Destroy(gameObject);
    }
    void IConsumable.Consume(CharacterStat stat)
    {
        Debug.Log("You use a door key");
    }
}
