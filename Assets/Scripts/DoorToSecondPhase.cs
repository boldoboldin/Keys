using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToSecondPhase : MonoBehaviour
{
    public SceneManagement SM;
  
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SM.PassPhase();
        }
    }
}
