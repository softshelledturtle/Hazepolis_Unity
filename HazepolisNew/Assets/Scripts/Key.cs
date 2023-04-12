using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour,IConsumable
{
    void IConsumable.Consume()
    {
        Debug.Log("You use a key!");
        Destroy(gameObject);
    }

    void IConsumable.Consume(CharacterStat stat)
    {
        Debug.Log("You use a door key");
    }
}
