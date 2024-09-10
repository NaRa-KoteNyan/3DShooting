using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;
    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitparticles;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;
    void Awake()
    {
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        hitparticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        currentHealth = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(isSinking)
        {
            transform.Translate (-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }
    public void TakeDamage(int amount, Vector3 hitpoint)
    {
        if(isDead)
        {
            return;
        }
        enemyAudio.Play();

        currentHealth -= amount;

        hitparticles.transform.position = hitpoint;
        hitparticles.Play();

        if(currentHealth <= 0)
        {
            Death();
        }
    }
    void Death()
    {
        isDead = true;

        capsuleCollider.isTrigger = true;

        anim.SetTrigger("Dead");

        enemyAudio.clip = deathClip;
        enemyAudio.Play();
    }
    public void StartSinking()
    {
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;
        MyScoreManager.score += scoreValue;
        Destroy(gameObject,2f);
    }
}
