using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject Arrow;
    public GameObject ExitPoint;
    public Animator anim;
    private int bossHp = 15;
    public PlayerCtrl playerCtrl;  

    // Update is ca1lled once per frame
    void Update()
    {   
        StartCoroutine(Attack());
        Die();
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Attack")
        {
            bossHp--;
        }
    }
    IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            anim.SetTrigger("Atk");
        }
    }
   
   public void Shoot()
    {
        GameObject Dispair = Instantiate(Arrow, ExitPoint.transform.position, transform.rotation);
        Dispair.GetComponent<Rigidbody>().AddForce(transform.forward);
        Destroy(Dispair, 5f);
        StopAllCoroutines();
    }

    public void Die()
    {
        if(bossHp == 0)
        {
            Destroy(this.gameObject);
            playerCtrl.killBoss = true;
        }
    }

}
