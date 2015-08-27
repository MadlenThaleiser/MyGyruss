using UnityEngine;
using System.Collections;
using UnityGameBase;

public class Enemy : GameComponent<MyGyruss>
{
    //Fields
    // radius for the distance to the centre vector (0,0,0)
    public float r;
    // speed for the movement
    public float movingSpeed;
    // direction for movementcalculation
    float direction = 1f;
    // step for the movementcalulation
    float move;
    // startposition for angle calculation
    public Vector3 startPosition;

    // bomb which will be randomly spawned
    public GameObject bombPrefab;
    // bool for spawning one bomb per time
    bool activeBomb = false;

	// Use this for initialization
	void Start () 
    {
        transform.position = startPosition;
	}
	
	// Update is called once per frame
	void Update () 
    {
        move += direction * movingSpeed * Time.deltaTime;
        Vector3 nextPos = Vector3.zero;
        nextPos.x = Mathf.Cos(move) * r;
        nextPos.y = startPosition.y + Mathf.Sin(move) * r;
        transform.position = nextPos;
        BombSpawn();
	}

    void BombSpawn() 
    {
        if (!activeBomb) 
        {
            activeBomb = true;
            float spawnTime = Random.Range(1, 5);
            StartCoroutine(Spawn(spawnTime));
        }
    }

    IEnumerator Spawn(float range) 
    {
        Instantiate(bombPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(range);
        activeBomb = false;
        
    }
}
