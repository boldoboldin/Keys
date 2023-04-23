using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    public Vector3 destination;

    [SerializeField] private GameObject sprite2D;
    public Animator anim;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Move();
        }

        if (agent.velocity.magnitude > 1)
        {
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }

        if (destination.x < transform.position.x)
        {
            anim.SetBool("Front", true);
        }
        else if (destination.x > transform.position.x)
        {
            anim.SetBool("Front", false);
        }

        if (destination.z < transform.position.z)
        {
            sprite2D.transform.localScale = new Vector3(-4, 4, 4);
        }
        else if (destination.z > transform.position.z)
        {
            sprite2D.transform.localScale = new Vector3(4, 4, 4);
        }
    }

    private void Move()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.tag == "Inimigo")
            {
                agent.stoppingDistance = 2;
                agent.SetDestination(hit.point);
                destination = hit.point;

            }
            else
            {
                agent.stoppingDistance = 0;
                agent.SetDestination(hit.point);
                destination = hit.point;
            }
        }
    }
}
