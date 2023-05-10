using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleAnima : MonoBehaviour
{
    public RectTransform TitlePanel, Titlechoice1, Titlechoice2, Titlechoice3, settingBanner, settingPanel, panelSwitchD;

    void Start()
    {
        //標題畫面動畫
        //TitleAnimation();
        TitlePanel.DOAnchorPos(new Vector2(-225, 100), 0.25f);
        Titlechoice1.DOAnchorPos(new Vector2(-270, -50 ), 0.25f);
        Titlechoice2.DOAnchorPos(new Vector2(-270, -100), 0.35f);
        Titlechoice3.DOAnchorPos(new Vector2(-270, -150), 0.45f);

        settingPanel.DOAnchorPos(new Vector2(0, -360), 0.25f);
        settingBanner.DOAnchorPos(new Vector2(0, 90), 0.25f);
        panelSwitchD.DOAnchorPos(new Vector2(-570, -215), 0.25f);
    }

    public void Titledissapear() {

        TitlePanel.DOAnchorPos(new Vector2(-550, 100), 0.25f);
        Titlechoice1.DOAnchorPos(new Vector2(-500, -50 ), 0.25f);
        Titlechoice2.DOAnchorPos(new Vector2(-500, -100), 0.35f);
        Titlechoice3.DOAnchorPos(new Vector2(-500, -150), 0.45f);

        settingBanner.DOAnchorPos(new Vector2(0, 5), 0.25f);
        settingPanel.DOAnchorPos(new Vector2(0, 0), 0.2f);
        panelSwitchD.DOAnchorPos(new Vector2(-425, -215), 0.25f);
    }

    public void Titleappear() {
        TitlePanel.DOAnchorPos(new Vector2(-225, 100), 0.25f);
        Titlechoice1.DOAnchorPos(new Vector2(-270, -50), 0.25f);
        Titlechoice2.DOAnchorPos(new Vector2(-270, -100), 0.35f);
        Titlechoice3.DOAnchorPos(new Vector2(-270, -150), 0.45f);

        settingBanner.DOAnchorPos(new Vector2(0, 90), 0.25f);
        settingPanel.DOAnchorPos(new Vector2(0, -360), 0.2f);
        panelSwitchD.DOAnchorPos(new Vector2(-570, -215), 0.25f);
    }
    //public void TitleAnimation()
    //    {
    //        LeanTween.move(TitleMenuCanvas, new Vector3(48f, 0f, 0f), 1f).setDelay(.4f);
    //        LeanTween.alpha(TitleMenuCanvas, 2f, 5f).setFrom(0f).setDelay(.5f).setEase(LeanTweenType.easeOutQuad);

    //    }
}
