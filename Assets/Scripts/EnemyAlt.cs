using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAlt : MonoBehaviour
{
    [SerializeField] private GameObject sprite2D;
    public Animator anim;
    private NavMeshAgent navMesh;
    private Rigidbody rb;

    [SerializeField] private GameObject player;

    [SerializeField] private PlayerCtrl playerCtrl;

    [SerializeField] private float atkDist; // Distancia para atk
    [SerializeField] private float followDist; // Distancia para perceguir
    [SerializeField] private GameObject atkArea;
    public float currentFollowDist;
    private float dist;

    private AudioSource sfx;
    //[SerializeField] private AudioClip atkSFX;
    //[SerializeField] private AudioClip followSFX;

    //[SerializeField] private PlayerHP playerHP;
    [SerializeField] private int damage;
    [SerializeField] private int hp;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExampleCoroutine());

        sfx = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        navMesh = GetComponent<NavMeshAgent>();

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (navMesh.enabled) // Se navMesh estive ativo
        {
            bool atk = false;
            bool follow = (dist < currentFollowDist);
            dist = Vector3.Distance(player.transform.position, transform.position);


            if (follow && atk == false)
            {
                navMesh.SetDestination(player.transform.position); // Faz trajetória evitando obstaculos
            }

            if (follow == false)
            {
                navMesh.SetDestination(transform.position);
            }

            if (dist < atkDist)
            {
                atk = true;
                currentFollowDist = 0;
                transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
            }
            else
            {
                currentFollowDist = 5;
            }

            if (player.transform.position.x < transform.position.x)
            {
                anim.SetBool("Front", true);
            }
            else if (player.transform.position.x > transform.position.x)
            {
                anim.SetBool("Front", false);
            }

            if (player.transform.position.z < transform.position.z)
            {
                sprite2D.transform.localScale = new Vector3(-4, 4, 4);
            }
            else if (player.transform.position.z > transform.position.z)
            {
                sprite2D.transform.localScale = new Vector3(4, 4, 4);
            }


           //anim.SetBool("Atk", atk); // Relaciona o valor da variavel "atk" com a animação "Atk"
           anim.SetBool("Walk", follow); // Relaciona o valor da variavel "follow" com a animação "Walk"

        }

        if (currentFollowDist >= followDist)
        {
            currentFollowDist = currentFollowDist - Time.deltaTime * 7;
        }
    }
    IEnumerator ExampleCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            ActivateAtk();
            yield return new WaitForSeconds(5);
            DeactivateAtk();
        }

    }


   public void ActivateAtk()
    {
        atkArea.SetActive(true);
        //sfx.PlayOneShot(atkSFX);
    }
    public void DeactivateAtk()
    {
        atkArea.SetActive(false);
    }

    public void ApplyDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            //navMesh.enabled = false;
            //anim.SetBool("Atk", false);
            //anim.SetBool("Walk", false);
            //anim.SetTrigger("Die");
            //GetComponent<Collider>().enabled = false;
            //Destroy(gameObject, 2.5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Attack")
        {
            navMesh.enabled = false;
            //anim.SetBool("Atk", false);
            anim.SetBool("Walk", false);
            anim.SetTrigger("Die");
            GetComponent<Collider>().enabled = false;
            Destroy(gameObject, 1f);
        }
        
    }
    public void RecoverHp()
    {
        hp++;
    }

}
