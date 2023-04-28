using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject SpawnPoint;
    public GameObject[] Enemys;
    public int minEnemys = 1, maxEnemys = 5;
    private GameObject Player;
    public float SpawnDistance = 10;
    private float quantity;
    private bool realizeSpawn;
    void Start()
    {
        realizeSpawn = false;
        Player = GameObject.FindWithTag("Player");
        quantity = Random.Range(minEnemys, maxEnemys);
    }

    // Update is called once per frame
    void Update()
    {
     if(Vector3.Distance(Player.transform.position, transform.position) <= SpawnDistance && realizeSpawn == false){
            for(int x = 0; x < quantity; x++)
            {
                Instantiate(Enemys[Random.Range (0, Enemys.Length)], SpawnPoint.transform.position, transform.rotation);
            }
            realizeSpawn = true;
        }  
    }
}
