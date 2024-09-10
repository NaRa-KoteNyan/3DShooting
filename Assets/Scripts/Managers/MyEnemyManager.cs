using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEnemyManager : MonoBehaviour
{
    public MyPlayerHealth myPlayerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    // Start is called
    void Start()
    {
        InvokeRepeating("Spawn",spawnTime,spawnTime);
    }

    // Update is called once per frame
    void Spawn()
    {
        Debug.Log(myPlayerHealth.currentHealth);
        if(myPlayerHealth.currentHealth <= 0f)
        {
            return;
        }
        int spawnPointIndex = Random.Range(0,spawnPoints.Length);

        Instantiate(enemy,spawnPoints[spawnPointIndex].position,spawnPoints[spawnPointIndex].rotation);
    }
}
