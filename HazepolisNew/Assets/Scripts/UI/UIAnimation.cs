using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class UIAnimation : MonoBehaviour
{
    public RectTransform bagPanel,miniMap,hpBar,functionBar;
    // Start is called before the first frame update
    void Start()
    {
       bagPanel.DOAnchorPos(new Vector2(0, -1025 ), 0.25f);
    }

    public void bagapear()
    {
        bagPanel.DOAnchorPos(new Vector2(0, -20), 0.25f);
    }    
    public void bagdisapear()
    {
        bagPanel.DOAnchorPos(new Vector2(0, -1025), 0.25f);
    }
}
