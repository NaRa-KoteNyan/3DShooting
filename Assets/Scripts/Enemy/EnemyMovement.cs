using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    //PlayerHealth playerHealth;
    //EnemyHealth enemyHealth;
    UnityEngine.AI.NavMeshAgent nav;
    MyPlayerHealth myPlayerHealth;
    MyEnemyHealth myEnemyHealth;


    void Awake ()
    {
        
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        //playerHealth = player.GetComponent <PlayerHealth> ();
        //enemyHealth = GetComponent <EnemyHealth> ();
        nav = GetComponent <UnityEngine.AI.NavMeshAgent> ();
        myPlayerHealth = player.GetComponent<MyPlayerHealth>();
        myEnemyHealth = GetComponent<MyEnemyHealth>();
    }


    void Update ()
    {
        if(myEnemyHealth.currentHealth > 0 && myPlayerHealth.currentHealth > 0)
        {
            nav.SetDestination (player.position);
        }
        else
        {
           nav.enabled = false;
        }
    }
}
