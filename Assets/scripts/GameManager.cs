using UnityEngine;
using System.Collections;
using UnityGameBase;
using UnityEngine.UI;
using UnityGameBase.Core.ObjPool;

public class GameManager : GameComponent<MyGyruss>
{
    //Fields
    // text for displaying the current score
    public GameObject scoreCount;
    // text for displaying the current life-cont
    public GameObject lifeCount;
    // counter for score
    public static int score = 0;
    // counter for life
    public static int life = 5;
    // player for instantiate after a life is lost
    public GameObject player;
    // boolhelper for spawning the player
    public static bool respawn = false;
    // startpostion for the player respawn
    Vector3 startPos = new Vector3(0, -14f, 0);

    // score enter
    public GameObject scoreGui;
    // text for displaying the best score
    public GameObject bestScoreText;
    // text of entered name
    public GameObject inputFieldText;


	// Use this for initialization
    void Start()
    {
        // init display
        if (life <= 0) 
        {
            life = 5;
            score = 0;
        }
        scoreCount.GetComponent<Text>().text = score.ToString();
        lifeCount.GetComponent<Text>().text = life.ToString();
        player = GameObject.FindGameObjectWithTag("Player");

        if (PlayerPrefs.HasKey("Score"))
        {
            string name = PlayerPrefs.GetString("Name");
            string bestScore = PlayerPrefs.GetInt("Score").ToString();
            bestScoreText.GetComponent<Text>().text = name + " " + bestScore;
        }
        else 
        {
            bestScoreText.GetComponent<Text>().text = "0";
        }
    }
	
	// Update is called once per frame
	void Update () 
    {
        // updating interface with current score and number of life
        if (life > -1) 
        {
            scoreCount.GetComponent<Text>().text = score.ToString();
            lifeCount.GetComponent<Text>().text = life.ToString();
            
            //SpawnMechanism(timer);
        }
        // respawn after player lost a life
        if (respawn && life > 0) 
        {
            player.transform.position = startPos;            
            player.SetActive(true);
            respawn = false;
        }

        if (life == 0) 
        {
            scoreGui.SetActive(true);
        }             
  	}

    public void SetHighscore() 
    {
        Text placeHolder = inputFieldText.GetComponent<Text>(); 
        if (PlayerPrefs.HasKey("Score")) 
        {
            int tempScore = PlayerPrefs.GetInt("Score");
            if (tempScore < score) 
            {
                PlayerPrefs.SetString("Name", placeHolder.text);
                PlayerPrefs.SetInt("Score", score);
            }
        }
        else            
        {
            PlayerPrefs.SetString("Name", placeHolder.text);
            PlayerPrefs.SetInt("Score", score);
            
        }
        bestScoreText.GetComponent<Text>().text = placeHolder.text + " " + score;
        scoreGui.SetActive(false);
        Application.LoadLevel("default");
    }

}
