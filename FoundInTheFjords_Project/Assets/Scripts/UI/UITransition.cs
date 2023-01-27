using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using DG.Tweening;

public class UITransition : MonoBehaviour
{
    public Canvas infoUI;
    public CanvasGroup nextPanel;

    public void UINext()
    {

        if (nextPanel != null)
        {
            foreach (CanvasGroup panel in infoUI.GetComponentsInChildren<CanvasGroup>())
            {
                panel.DOFade(0f, 1.0f);
                panel.interactable = false;
                panel.blocksRaycasts = false;
            }

            nextPanel.DOFade(1f, 1.0f);
            nextPanel.interactable = true;
            nextPanel.blocksRaycasts = true;



        }

    }

    public void UIFade()
    {

        
            foreach (CanvasGroup panel in infoUI.GetComponentsInChildren<CanvasGroup>())
            {
                panel.DOFade(0f, 1.0f);
                panel.interactable = false;
                panel.blocksRaycasts = false;
            }

            
        

    }
}
