using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    
    public PlayerCtrl pScript;


    public void Update()
    {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.01f);
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") 
        {
            pScript.ApplyDamage();
        }
    }
}
