using UnityEngine;
using System.Collections;
using UnityGameBase;

public class Bomb : GameComponent<MyGyruss> 
{
    //Fields
    // speed for the movement
    public float movingSpeed;
    // step the projectile is moving
    float step;
    // target vector for moving calculation
    Vector3 targetPos;

	// Use this for initialization
	void Start () 
    {
        // calculation the postion of the target
        targetPos = transform.position;
        targetPos *= 15f;
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        // calculates the step
        step = movingSpeed * Time.deltaTime;
        // calculates the moving
        // projectile moves from any position to the position of the target
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);

        // destroys the bomb, if it reach the target without hitting the player
        if (transform.position.Equals(targetPos))
        {
            Destroy(gameObject);
        }
	}

    // checks, if a bomb hits the player
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            GameManager.life -= 1;
            Destroy(gameObject);
            // signals the gamemanager, that the player has to respawn
            GameManager.respawn = true;
            // quick and dirty solution to missing reference exception after player respawns
            other.gameObject.SetActive(false);
            other.gameObject.GetComponent<SpaceShip>().direction = 0;
        }
    }

}
