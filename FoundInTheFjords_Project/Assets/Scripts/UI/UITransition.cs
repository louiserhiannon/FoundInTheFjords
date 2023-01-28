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
            StartCoroutine(SwitchPanel()); 
            
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

    private IEnumerator SwitchPanel()
    {
        foreach (CanvasGroup panel in infoUI.GetComponentsInChildren<CanvasGroup>())
        {
            panel.DOFade(0f, 1.0f);
            panel.interactable = false;
            panel.blocksRaycasts = false;
        }
        yield return new WaitForSeconds(1.1f);

        nextPanel.DOFade(1f, 1.5f);
        nextPanel.interactable = true;
        nextPanel.blocksRaycasts = true;


    }
}
