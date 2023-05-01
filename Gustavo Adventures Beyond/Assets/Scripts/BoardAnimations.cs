using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardAnimations : MonoBehaviour
{

    Animator animator;
    public AudioSource BoardTrickSound;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            //BoardTrickSound.enabled = true;
            animator.SetTrigger("OllieTrigger");
        }
        else if(Input.GetKeyDown(KeyCode.K)){
            //BoardTrickSound.enabled = true;
            animator.SetTrigger("GroundKickFlipTrigger");
        }
        else
        {
            //BoardTrickSound.enabled = false;
            animator.ResetTrigger("GroundKickFlipTrigger");
        }

        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Idle")){
            BoardTrickSound.enabled = false;
        }
        else if(MenusController.VolumeEnabled){
            BoardTrickSound.enabled = true;
        }
    }
}
