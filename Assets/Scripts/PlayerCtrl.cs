using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.tag == "Inimigo")
                {
                    agent.stoppingDistance = 2;
                    agent.SetDestination(hit.point);

                }
                else
                {
                    agent.stoppingDistance = 0;
                    agent.SetDestination(hit.point);
                }

            }
        }
    }
}
