using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedAttack : MonoBehaviour
{
    public GameObject ClosedAtkArea;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CloseAttack());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator CloseAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            ActivateAtk();
            yield return new WaitForSeconds(1);
            DeactivateAtk();
        }
        
    }
    public void ActivateAtk()
    {
        ClosedAtkArea.SetActive(true);
    }
    public void DeactivateAtk()
    {
        ClosedAtkArea.SetActive(false);
    }
}
