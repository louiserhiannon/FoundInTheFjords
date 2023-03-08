using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumpbackSwimAnimation : MonoBehaviour
{
    private Animator humpbackAnimator;
    // Start is called before the first frame update
    void Start()
    {
        humpbackAnimator = GetComponent<Animator>();
        humpbackAnimator.SetTrigger("Trigger_Swim");
    }

    private void OnDisable()
    {
        humpbackAnimator.SetTrigger("Trigger_StopSwim");
    }


}
