using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HerringCounter : MonoBehaviour
{
    public EatingController eatingController;
    public CanvasGroup counterDisplay;
    private TMP_Text counterText;
    public CanvasGroup counterTitle;
    private TMP_Text titleText;



    // Start is called before the first frame update
    void Start()
    { 
        counterText = counterDisplay.GetComponentInChildren<TMP_Text>();
        titleText = counterTitle.GetComponentInChildren<TMP_Text>();
        titleText.text = "Herring Count";
    }

    // Update is called once per frame
    void Update()
    {
        counterText.text = eatingController.eatenHerringCount.ToString();
    }
}
