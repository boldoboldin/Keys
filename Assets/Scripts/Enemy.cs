using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int life = 10;
    public GameObject AreaOfAttack;
    public GameObject Protagonist;
   
    private void Update()
    {
        FollowProtagonist();
    }


    private void OnTriggerEnter(Collider collide)
    {
            if(collide.gameObject.tag == "Attack")
        {
            TakeDamage();
        }
    }
    public void TakeDamage()
    {
        life--;
        if(life <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void ActivateAttack()
    {
        AreaOfAttack.SetActive(true);
    }

    public void DeactivateAttack()
    {
        AreaOfAttack.SetActive(false);
    }

    private void FollowProtagonist()
    {
       float distance = Vector3.Distance(transform.position, Protagonist.transform.position);
        if(distance < 5 && distance > 1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, Protagonist.transform.position, 0.07f);
        }
    }
    
}
