using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;

public class CarouselSceneIntro : MonoBehaviour
{
    public AudioSource orcaMomSounds;
    public AudioSource reflectedSounds;
    public AudioClip voiceover01;
    public AudioClip voiceover02;
    public AudioClip clickTrain;
    public Canvas arrowCanvas;
    public CanvasGroup echolocationPanel;
    public OceanMovement oceanMovement;
    public Animator orcaMomAnimator;
    public float timeBeforeVoiceover1;
    public float voiceover1Part1Duration;
    public float voiceover1Part2Duration;
    //public float voiceover1Part3Duration;
    public float pauseAfterClick;
    public float voiceover2Duration;
    public float pauseForReflection;


    public IEnumerator Scene02Intro()
    {
        //wait some seconds
        yield return new WaitForSeconds(timeBeforeVoiceover1);
        //Start voiceover 1
        orcaMomSounds.PlayOneShot(voiceover01);
        //wait some seconds
        yield return new WaitForSeconds(voiceover1Part1Duration);
        //Slow down surroundings and stop
        oceanMovement.isMoving = false;
        //Stop swim animation
        orcaMomAnimator.SetTrigger("Trigger_StopSwim");
        //Wait some seconds
        yield return new WaitForSeconds(voiceover1Part2Duration);
        ////show echolocation canvas
        //if (echolocationPanel != null)
        //{
        //    echolocationPanel.DOFade(1f, 1.5f);
        //    echolocationPanel.interactable = true;
        //    echolocationPanel.blocksRaycasts = true;
        //}
        ////Wait some seconds
        //yield return new WaitForSeconds(voiceover1Part3Duration);
        //play click sound
        orcaMomSounds.PlayOneShot(clickTrain);
        //wait some seconds
        yield return new WaitForSeconds(pauseAfterClick);
        //Activate Voiceover 2
        orcaMomSounds.PlayOneShot(voiceover02);
        //Wait some seconds
        yield return new WaitForSeconds(voiceover2Duration);
        //play click sound
        orcaMomSounds.PlayOneShot(clickTrain);
        //Fade echolocation canvas
        if (echolocationPanel != null)
        {
            echolocationPanel.DOFade(0f, 1.5f);
            echolocationPanel.interactable = false;
            echolocationPanel.blocksRaycasts = false;
        }
        //Activate Arrow Panels
        foreach (CanvasGroup panel in arrowCanvas.GetComponentsInChildren<CanvasGroup>())
        {
            panel.DOFade(1f, 1.5f);
            panel.interactable = true;
            panel.blocksRaycasts = true;
        }
        //wait some seconds
        yield return new WaitForSeconds(pauseForReflection);
        //play click sound reflection
        reflectedSounds.PlayOneShot(clickTrain, 0.5f);
        

    }
}
