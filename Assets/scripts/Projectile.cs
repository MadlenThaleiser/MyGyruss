using UnityEngine;
using System.Collections;
using UnityGameBase;

public class Projectile : MonoBehaviour
{
    // Fields
    // speed of the projectile
    public float movingSpeed;
    // step the projectile is moving
    float step;
    // target vector for moving calculation
    Vector3 targetPos = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        // calculates the step
        step = movingSpeed * Time.deltaTime;
        // calculates the moving
        // projectile moves from any position to the position of the target
        transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
        // destroys the projectile, if it reach the target without hitting an enemy
        if (transform.position.Equals(targetPos))
        {
            Destroy(gameObject);
        }
    }

    // checks, if projectile hits an enemy
    void OnTriggerEnter(Collider other)
    {        
        if (other.CompareTag("Enemy"))
        {
            GameManager.score += 1000;
            Destroy(gameObject);
            Destroy(other.gameObject);            
        }
    }
}
