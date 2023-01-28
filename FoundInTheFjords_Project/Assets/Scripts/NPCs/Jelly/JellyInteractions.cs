using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class JellyInteractions : MonoBehaviour
{
    public Canvas jellyCanvas;
    public CanvasGroup firstPanel;
    private AudioSource jellyAudioSource;
    public AudioClip jellyClip;
    public MeshRenderer interactionSignifier;
    private Color originalColour;
    

    private void Awake()
    {
        //jellyCanvas = FindObjectOfType<Canvas>();
        jellyAudioSource = GetComponent<AudioSource>();
        originalColour = interactionSignifier.material.color;
        DisablePanels();

    }

    private void DisablePanels()
    {
        foreach(CanvasGroup panel in jellyCanvas.GetComponentsInChildren<CanvasGroup>())
        {
            panel.alpha = 0;
            panel.interactable= false;
            panel.blocksRaycasts= false;
        }
    }

    public void ChangeSignifierColour()
    {
        interactionSignifier.material.color = Color.green;
    }

    public void ResetSignifierColour()
    {
        interactionSignifier.material.color = originalColour;
    }


    public void PlayJellyAudio()
    {
        if (jellyClip!= null)
        {
            jellyAudioSource.PlayOneShot(jellyClip);
        }
    }

    public void EnableJellyUI()
    {
        if (firstPanel != null)
        {
            firstPanel.DOFade(1f, 1.5f);
            firstPanel.interactable = true;
            firstPanel.blocksRaycasts = true;
        }
    }
}
