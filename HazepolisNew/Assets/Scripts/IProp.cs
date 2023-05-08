using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProp 
{
    List<BaseStat> Stats { get; set; }
    void useKeyProp(string password);
    void useProp();
}
