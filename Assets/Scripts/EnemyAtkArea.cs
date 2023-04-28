using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtkArea : MonoBehaviour
{
    public PlayerCtrl playerCtrl;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerCtrl.ApplyDamage(1);
        }
    }
}
