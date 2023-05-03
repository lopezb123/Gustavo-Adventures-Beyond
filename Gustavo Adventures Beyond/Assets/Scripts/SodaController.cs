using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SodaController : MonoBehaviour
{
    [SerializeField] GameObject uiCamera;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("collision with sodacan");
        if(other.tag == "Skateboard"){
            uiCamera.GetComponent<ScoreTracker>().SodaCollected();
            gameObject.SetActive(false);
        }
    }
}
