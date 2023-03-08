using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager_Carousel : MonoBehaviour
{
    public Canvas arrowCanvas;
    public Canvas echolocationCanvas;
    public Canvas ecosystemCanvas;
    public Canvas migrationCanvas;
    public GameObject orcaMom;
    private Animator orcaMomAnimator;
    public CarouselSceneIntro carouselSceneIntro;
    public GameObject flockManager;
    public GameObject carouselManager;
    public GameObject xRRig;
   

    void Awake()
    {
        //Disable Panels
        foreach (CanvasGroup panel in arrowCanvas.GetComponentsInChildren<CanvasGroup>())
        {
            panel.alpha = 0;
            panel.interactable = false;
            panel.blocksRaycasts = false;
        }
        foreach (CanvasGroup panel in echolocationCanvas.GetComponentsInChildren<CanvasGroup>())
        {
            panel.alpha = 0;
            panel.interactable = false;
            panel.blocksRaycasts = false;
        }
        foreach (CanvasGroup panel in migrationCanvas.GetComponentsInChildren<CanvasGroup>())
        {
            panel.alpha = 0;
            panel.interactable = false;
            panel.blocksRaycasts = false;
        }
        foreach (CanvasGroup panel in ecosystemCanvas.GetComponentsInChildren<CanvasGroup>())
        {
            panel.alpha = 0;
            panel.interactable = false;
            panel.blocksRaycasts = false;
        }
        //Disable Move Controls
        xRRig.GetComponent<LocomotionController_General>().enabled = false;
        ////Disable Follow script
        //xRRig.GetComponent<FollowMom>().enabled = false;
        //Disable flock manager
        flockManager.GetComponent<FlockManager>().enabled = false;
        //Disable spawned Orca
        //for (int i = 0; i < CarouselManager.CM.allAxes.Length; i++)
        //{
        //    CarouselManager.CM.allAxes[i].SetActive(false);
        //}
        
        //Start orca Swim animation
        orcaMomAnimator = orcaMom.GetComponent<Animator>();
        orcaMomAnimator.SetTrigger("Trigger_Swim");

        //Start Scene02IntroCoroutine
        StartCoroutine(carouselSceneIntro.Scene02Intro());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
