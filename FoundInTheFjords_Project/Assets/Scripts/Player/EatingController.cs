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
    public Eatable eatableHerring;
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
                eatableHerring = eatable;
                eatableHerring.OnHoverStart();
            }
        }
        //else
        //{
        //    eatableHerring = null;
        //}

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("stunnedHerring"))
        {
            //var eatable = other.GetComponent<Eatable>();
            //if (eatable == eatableHerring)
            //{
            //    eatableHerring.OnHoverEnd();
            //    eatableHerring = null;
            //}

            if (eatableHerring != null)
            {
                eatableHerring.OnHoverEnd();
                eatableHerring = null;
            }
        }
        //else
        //{
        //    eatableHerring = null;
        //}

    }

    public void Bite(InputAction.CallbackContext context)
    {
        if(eatableHerring != null)
        {
                   

            if(eatenHerringCount < targetHerringCount)
            {
                //DestroyHerring
                Destroy(eatableHerring.gameObject);
                Debug.Log("herring should disappear");
                //increase count by 1
                eatenHerringCount++;
                Debug.Log(eatenHerringCount);

                //play success audio

                int index = UnityEngine.Random.Range(0, successClips.Count);
                var clip = successClips[index];
                audioSource.PlayOneShot(clip);



            }

        }
        else
        {
            //play other sounds
            int index = UnityEngine.Random.Range(0, failureClips.Count);
            var clip = failureClips[index];
            audioSource.PlayOneShot(clip);

        }

    }

    private void Update()
    {
        if(eatenHerringCount == targetHerringCount)
        {
            Debug.Log("target reached");
        }
       
    }
    
        
    
}
