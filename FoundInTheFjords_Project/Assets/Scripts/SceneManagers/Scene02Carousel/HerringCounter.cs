using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HerringCounter : MonoBehaviour
{
    public EatingController eatingController;
    public CanvasGroup counterDisplay;
    private TMP_Text counterText;
    



    // Start is called before the first frame update
    void Start()
    { 
        counterText = counterDisplay.GetComponentInChildren<TMP_Text>();
        ////Disable Panel
        //counterDisplay.alpha = 1f;
        //counterDisplay.blocksRaycasts = false; 
        //counterDisplay.interactable = false;

    }

    // Update is called once per frame
    void Update()
    {
        counterText.text = eatingController.eatenHerringCount.ToString();
    }
}
