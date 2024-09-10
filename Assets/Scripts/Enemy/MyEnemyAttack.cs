using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemyAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;
    Animator anim;
    GameObject player;
    MyPlayerHealth myPlayerhealth;
    bool playerInRange;
    float timer;
    MyEnemyHealth myEnemyHealth;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        myPlayerhealth = player.GetComponent<MyPlayerHealth>();
        anim = GetComponent<Animator>();
        myEnemyHealth = GetComponent<MyEnemyHealth>();
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= timeBetweenAttacks && playerInRange && myEnemyHealth.currentHealth>0)
        {
            Attack();
        }

        if(myPlayerhealth.currentHealth <= 0)
        {
            anim.SetTrigger("PlayerDead");
        }
        
    }
    void Attack()
    {
        timer = 0f;

        if(myPlayerhealth.currentHealth > 0)
        {
            myPlayerhealth.TakeDamage(attackDamage);
        }
    }
}
