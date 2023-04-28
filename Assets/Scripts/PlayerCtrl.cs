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
    public GameObject MyAtk;
    public string Side = "" ;

    public SceneManagement SM;

    public int hp;
    public int maxHp = 10;

    public bool killBoss = false;   
    public SceneManagement sceneManagement;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();

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
            Side = "Front";
        }
        else if (destination.x > transform.position.x)
        {
            anim.SetBool("Front", false);
            Side = "Back";
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
            if (hit.collider.gameObject.tag == "Enemy")
            {
                agent.stoppingDistance = 1;
                agent.SetDestination(hit.point);
                destination = hit.point;

                    //if (Side == "Front")
                    //{
                    //    anim.SetTrigger("AtkFront");
                    //}

                    //if (Side == "Back")
                    //{
                    //    anim.SetTrigger("AtkBack");
                    //}
            }
            else
            {
                agent.stoppingDistance = 0;
                agent.SetDestination(hit.point);
                destination = hit.point;
            }
        }
    }
    private void Attack()
    {
        if(Side == "Back")
        {
            if(Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.X)) 
            {
                anim.SetTrigger("AtkBack");

            }
        }
        if (Side == "Front")
        {
            if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.X))
            {
                anim.SetTrigger("AtkFront");
            }
        }
    }

    public void ActivateAtk()
    {
        MyAtk.SetActive(true);

    }
    public void DeactivateAtk()
    {
        MyAtk.SetActive(false);
    }

    public void ApplyDamage(int damage)
    {
        hp--;
        if(hp <= 0)
        {
            youDie();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CooperDoor" && KeyGeren.cooperKey != 0)
        {
            KeyGeren.cooperKey--;

            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "SilverDoor" && KeyGeren.silverKey != 0)
        {
            KeyGeren.silverKey--;

            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "GoldDoor" && KeyGeren.goldKey != 0)
        {
            SM.PassPhase();
        }
        if(other.gameObject.tag == "Recover" && hp <= 10)
        {
            hp++;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Recover" && hp == 10)
        {
            Destroy(other.gameObject);
        }
    }

    public void Win()
    {
        if(killBoss == true)
        {
            sceneManagement.WinPhase();
        }
    }

    public void youDie()
    {
        sceneManagement.LostPhase();
    }
}
