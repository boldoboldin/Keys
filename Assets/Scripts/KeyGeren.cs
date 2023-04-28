using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class KeyGeren : MonoBehaviour
{
    [SerializeField] private string keyType;
    public static int cooperKey = 0;
    public static int silverKey = 0;
    public static int goldKey = 0;

    public Image goldIcon;
    public Image silverIcon;
    public Image cooperIcon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cooperKey > 0)
        {
            cooperIcon.enabled = true;
        }
        else
        {
            cooperIcon.enabled = false;
        }

        if (silverKey > 0)
        {
            silverIcon.enabled = true;
        }
        else
        {
            silverIcon.enabled = false;
        }

        if (goldKey > 0)
        {
            goldIcon.enabled = true;
        }
        else
        {
            goldIcon.enabled = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (keyType == "cooper" && other.gameObject.tag == "Player")
        {
            cooperKey++;

            Destroy(gameObject);
        }

        if (keyType == "silver" && other.gameObject.tag == "Player")
        {
            silverKey++;

            Destroy(gameObject);
        }

        if (keyType == "gold" && other.gameObject.tag == "Player")
        {
            goldKey++;

            Destroy(gameObject);
        }
    }

}
