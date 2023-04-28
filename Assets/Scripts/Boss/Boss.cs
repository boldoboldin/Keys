using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject Arrow;
    public GameObject ExitPoint;

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            Shoot();

        }
    }
    private void Shoot()
    {
        GameObject Dispair = Instantiate(Arrow, ExitPoint.transform.position, Quaternion.identity);
        Dispair.GetComponent<Rigidbody>().AddForce(transform.forward);
        Destroy(Dispair, 10f);
        StopAllCoroutines();
    }
}