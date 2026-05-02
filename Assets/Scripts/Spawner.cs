using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public GameManager gm;
    public GameObject enemy;
    // List of spawn point objects
    [SerializeField]public List<GameObject> spawnPoints = new();
    [SerializeField] private float spawnRate = 3;

    private GameObject player;
    
    // Indicates wheter an enemy is done spawning
    private bool enemySpawning = false;
    
    void Start(){
    }

    // Update is called once per frame
    void FixedUpdate(){
        // If the players exists, spawn enemies
        player = GameObject.Find("Player");
        if (player && !gm.isPaused && !enemySpawning){
            StartCoroutine(SpawnEnemy());
        } 
    }

    // Spawns an enemy
    IEnumerator SpawnEnemy(){
        enemySpawning = true;

        // Spawns a random enemy at a random spawn point
        Instantiate(enemy, spawnPoints[Random.Range(0, spawnPoints.Count)].transform.position, enemy.transform.rotation);
        yield return new WaitForSeconds(spawnRate);

        enemySpawning = false;
    }
    
}

    