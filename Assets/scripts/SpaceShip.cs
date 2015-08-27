using UnityEngine;
using System.Collections;
using UnityGameBase;

public class SpaceShip : MonoBehaviour
{

    //Fields
    // radius for the distance to the centre vector (0,0,0)
    public float r;
    // speed for the movement
    public float movingSpeed;
    // direction for movementcalculation
    public float direction;
    // step for the movementcalulation
    float move;
    // startposition for angle calculation
    public Vector3 startPosition;

    // projectile, which is spawned after hitting the space-button/tap/klick
    public GameObject projectilePrefab;
    // helpervariable for spawning projectiles
    bool oneShot = false;

    // Use this for initialization
	void Start () 
    {
        // init startposition for the spaceship
        startPosition = transform.position;
        r = startPosition.y;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (GameManager.life > 0)
        {
            Move();
            Input();
        }

	}

    // checks the input
    void Input()
    {
        UGB.Input.KeyDown += MoveInputs;
        UGB.Input.KeyUp += MoveInputs;
        UGB.Input.TouchStart += MoveInputs;
        UGB.Input.TouchEnd += MoveInputs;
    }

    private void MoveInputs(TouchInformation touchInfo)
    {
        string info = touchInfo.GetSwipeDirection().ToString();
        switch (info)
        {
            case "Left": direction = 1f; break;
            case "Right": direction = -1f; break;
            case "None": direction = 0f; Fire(); break;
            default: break;
        }
    }


    // fires projectiles
    void Fire()    
    { 
        if (!oneShot)
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            oneShot = true;
        }
        else
        {
            if (this.gameObject.activeInHierarchy)
            {
                StartCoroutine("ShotDelay");
            }
        }
    }

    // Short delay
    // prevent spawing to much projectiles
    IEnumerator ShotDelay() 
    {
        yield return new WaitForSeconds(0.2f);
        oneShot = false;
    }


    void MoveInputs(string keyMappingName)
    {
        switch (keyMappingName) 
        {
            case "leftArrow":   direction = -1f;        break;
            case "rightArrow":  direction = 1f;         break;
            case "spaceButton": direction = 0f; Fire(); break;
            default: break;
        }
    }


    void Move() 
    {
        move += direction * movingSpeed * Time.deltaTime;
        Vector3 nextPos = Vector3.zero;
        nextPos.x = Mathf.Sin(move) * r;
        nextPos.y = Mathf.Cos(move) * r;
        transform.position = nextPos;
    }
    
}


