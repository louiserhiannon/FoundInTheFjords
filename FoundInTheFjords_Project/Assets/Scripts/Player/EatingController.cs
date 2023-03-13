using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class EatingController : MonoBehaviour
{
    public static EatingController EC;
    public InputActionReference biteAction = null;
    public Eatable thisEatableHerring;
    [SerializeField]
    private List<Eatable> eatableHerrings = new List<Eatable>();
    public int eatenHerringCount = 0;
    public int targetHerringCount = 4;
    [Range(1f, 60f)]
    public float herringLifetime;
    private AudioSource audioSource;
    public List<AudioClip> successClips;
    public List<AudioClip> failureClips;
    

    //public Eatable eatenHerring;

    private void Awake()
    {
        EatingController.EC = this;
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }


    private void OnEnable()
    {
        biteAction.action.started += Bite;
    }

    private void OnDisable()
    {
        biteAction.action.started -= Bite;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("stunnedHerring"))
        {
            var eatable = other.GetComponent<Eatable>();
            if (eatable != null)
            {
                thisEatableHerring = eatable;
                eatableHerrings.Add(thisEatableHerring);
                eatableHerrings[0].OnHoverStart();
            }
        }
        //else
        //{
        //    eatableHerring = null;
        //}

    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.CompareTag("stunnedHerring"))
    //    {
    //        var eatable = other.GetComponent<Eatable>();
    //        if (eatable != null)
    //        {
    //            thisEatableHerring = eatable;
    //            eatableHerrings.Add(thisEatableHerring);
    //            if (eatableHerrings[0].hoverActivated == false)
    //            {
    //                eatableHerrings[0].OnHoverStart();
    //            }
                
    //        }
    //    }
    //}

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("stunnedHerring"))
        {
            var eatable = other.GetComponent<Eatable>();
            if(eatableHerrings.Count > 0)
            {
                if (eatable == eatableHerrings[0])
                {
                    eatableHerrings[0].OnHoverEnd();
                    eatableHerrings.Clear();
                    //eatableHerrings.Remove(eatableHerrings[0]);

                }
            }
            

            //if (eatableHerring != null)
            //{
            //    eatableHerring.OnHoverEnd();
            //    eatableHerring = null;
            //}
        }
        //else
        //{
        //    eatableHerring = null;
        //}

    }

    public void Bite(InputAction.CallbackContext context)
    {
        
        if(eatableHerrings.Count == 0)
        {
            //play other sounds
            int index = UnityEngine.Random.Range(0, failureClips.Count);
            var clip = failureClips[index];
            audioSource.PlayOneShot(clip);

        }
        else
        {
            if (eatenHerringCount < targetHerringCount)
            {
                //Destroy Active Herring
                Destroy(eatableHerrings[0].gameObject);
                Debug.Log("pink herring should disappear");
                //increase count by 1
                eatenHerringCount++;
                //play success audio
                int index = UnityEngine.Random.Range(0, successClips.Count);
                var clip = successClips[index];
                audioSource.PlayOneShot(clip);
                //Remove from list
                eatableHerrings.Remove(eatableHerrings[0]);
                
            }
        }
        //if(eatableHerrings[0] != null)
        //{


        //    if(eatenHerringCount < targetHerringCount)
        //    {
        //        //DestroyHerring
        //        Destroy(eatableHerrings[0].gameObject);
        //        Debug.Log("herring should disappear");
        //        //increase count by 1
        //        eatenHerringCount++;
        //        Debug.Log(eatenHerringCount);

        //        //play success audio

        //        int index = UnityEngine.Random.Range(0, successClips.Count);
        //        var clip = successClips[index];
        //        audioSource.PlayOneShot(clip);

        //        //Remove from list
        //        eatableHerrings.Remove(eatableHerrings[0]);

        //    }

        //}
        //else
        //{
        //    //play other sounds
        //    int index = UnityEngine.Random.Range(0, failureClips.Count);
        //    var clip = failureClips[index];
        //    audioSource.PlayOneShot(clip);

        //}

    }

    private void Update()
    {
        if(eatenHerringCount == targetHerringCount)
        {
            Debug.Log("target reached");
        }
       
    }
    
        
    
}
