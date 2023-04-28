using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KeyGeren : MonoBehaviour
{
    [SerializeField] private string keyType;
    public static int cooperKey;
    public static int silverKey;
    public static int goldKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
