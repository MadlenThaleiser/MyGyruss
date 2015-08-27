using UnityEngine;
using System.Collections;
using UnityGameBase.Core.ObjPool;
using System.Collections.Generic;

public class EnemieSpawner : MonoBehaviour {

    //Fields
    // enemie prefab for spawning
    public GameObject enemyPrefab;
    // time between spawns
    public float spawnTime = 25f;
    // start time between spawns
    public float startTime;
    // number of spawning enemies
    public int enemyCounter = 3;
    // objectpool with current number of enemies
    public ObjectPool enemiePool = new ObjectPool();
    // list with current spawning positions
    public List<Vector3> spawningPositions = new List<Vector3>();
    // start radius for the first wave of enemies
    float radius = 2f;
    // list of angles
    public List<float> angleList = new List<float>();
    // bool for spawn
    bool spawnOn = false;

	// Use this for initialization
	void Start () 
    {
        // init all prefabs as part of enemiepool
        //enemiePool.CreateNewObjectPoolEntry(enemyPrefab, 0, enemyCounter); // doesn't work like i want
        // init spawningpostitions for the first enemie-wave
        AddSpawnPositions(radius);
        // spawn the first enemiewave
        Spawning();	
        // init timer for next spawn
        startTime = spawnTime;
	}
	
	// Update is called once per frame
	void Update () 
    {
        // decrease spawntimer
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0.0f) 
        {
            // reset spawntimer
            NewSpawnTime();
        }
        // spawns the next enemie wave
        if (spawnOn) 
        {
            Spawning();
        }
	}

    // calculates spawnpostion on a circle 
    Vector3 SpawnPostitin(Vector3 startPosition, float radius) 
    {
        // minimum radius has to be 1f
        if (radius.Equals(0f)) 
        {
            radius = 1f;
        }
        Vector3 spawnPosition = Vector3.zero;
        // sets random angle and adds it to the anglelist
        float angle = Random.value * 360;
        angleList.Add(angle);
        // calculation of the coordinates
        spawnPosition.x = startPosition.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        spawnPosition.y = startPosition.y + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        return spawnPosition;
    }

    // adds all spawnposition to the spawningpositionlist
    void AddSpawnPositions(float r) 
    {
        // for all enemies calculates a spawningposition
        for (int i = 0; i < enemyCounter; i++) 
        {
            Vector3 pos = SpawnPostitin(Vector3.zero, r % 7);
            spawningPositions.Add(pos);
        }
    }

    // spawns the enemies
    void Spawning() 
    {
        // spawns only, if the enemy has a spawningposition
        if (spawningPositions.Count > 0)
        {
            // spawning
            for (int i = 0; i < enemyCounter; i++)
            {          
                // get the current spawningposition
                Vector3 currPos = spawningPositions[0];
                // get the current angle
                float currAngle = angleList[0];
                // spawn current enemy
                GameObject currEnemy = (GameObject)Instantiate(enemyPrefab, currPos, Quaternion.identity);
                // set some parameters
                currEnemy.GetComponent<Enemy>().startPosition = currPos;
                currEnemy.GetComponent<Enemy>().movingSpeed = 5f;
                currEnemy.GetComponent<Enemy>().r = radius;
                currEnemy.transform.localPosition += currPos;
                currEnemy.transform.rotation = Quaternion.Euler(new Vector3(0, 0, currAngle));
                // remove used position und used angle
                spawningPositions.Remove(currPos);
                angleList.Remove(currAngle);
            }
            // signals the end of the spawing
            spawnOn = false;
        }
        else 
        {
            // inits values to the variables for the next spawning
            enemiePool.ResetPool();
            enemyCounter += 2;
            radius += 1;
            enemiePool.CreateNewObjectPoolEntry(enemyPrefab, 0, enemyCounter);
            AddSpawnPositions(radius);
        }
    }

    // decreases the spawningtime between enemie-waves
    void NewSpawnTime() 
    {
        if (startTime > 0)
        {
            startTime -= 5f;
            spawnTime = startTime;
        }
        else 
        {
            spawnTime = 5f;
        }
        // signals to start spawning
        spawnOn = true;
        Spawning();
    }
}
