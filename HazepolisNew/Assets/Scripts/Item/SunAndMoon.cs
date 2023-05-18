using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunAndMoon : MonoBehaviour, IConsumable
{
    void IConsumable.Consume()
    {
        Debug.Log("You open a book!");
        Destroy(gameObject);
    }
    void IConsumable.Consume(CharacterStat stat)
    {
        Debug.Log("sun and moon");
    }
}
