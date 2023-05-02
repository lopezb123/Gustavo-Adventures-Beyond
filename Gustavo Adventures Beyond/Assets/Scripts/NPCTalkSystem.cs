using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTalkSystem : MonoBehaviour
{
    bool playerDetector = false;
    //Input to speak
    [SerializeField] public Canvas interacts;
    //the speech bubble for the npc
    [SerializeField] public Canvas speech;

    // Start is called before the first frame update
    void Start()
    {
        interacts.enabled = false;
        speech.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //tests if gustavo is in the area and pressed E
        if(playerDetector && Input.GetKeyDown(KeyCode.E)){
                interacts.enabled = false;
                speech.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider player){
        if(player.name == "Skateboard"){
            interacts.enabled = true;
            playerDetector = true;
        }
    }

    private void OnTriggerExit(Collider player){
            playerDetector = false;
            interacts.enabled = false;
            speech.enabled = false;
    }
}
