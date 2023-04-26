using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCtrl : MonoBehaviour
{
    public GameObject pastTemple;
    public GameObject futureTemple;
    public bool isFuture;
    
    // Start is called before the first frame update
    void Start()
    {
        isFuture = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFuture)
        {
            futureTemple.SetActive(true);
            pastTemple.SetActive(false);
        }
        else
        {
            futureTemple.SetActive(false);
            pastTemple.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.E) && isFuture)
        {
            isFuture = false;
        }
        else if (Input.GetKeyDown(KeyCode.E) && isFuture == false)
        {
            isFuture = true;
        }
    }
}
