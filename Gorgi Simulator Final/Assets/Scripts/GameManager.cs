using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] ObsticalPrefabs;
    public GameObject[] PowerupPrefabs;
    private float spawnRangeX = 6;
    private float spawnPosZ = 50;
    private float startDelay = 2;
    private float repeatRate = 7;
    private float counter = 0;
    private int score;
    public GameObject TitleScreen;
    public Button restartButton;
    public bool gameOver = false;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI GameOvertext;
    private PlayerController playerControllerScript;
   
    // Start is called before the first frame update
    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
     
    }

    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), -1, spawnPosZ);
            int obsticalIndex = Random.Range(0, ObsticalPrefabs.Length);
            Instantiate(ObsticalPrefabs[obsticalIndex], spawnPos, ObsticalPrefabs[obsticalIndex].transform.rotation);
        }
    }
    void SpawnPowerup() 
    {
        if (playerControllerScript.gameOver == false){
        
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), -1, spawnPosZ);
            int PowerupIndex = Random.Range(0, PowerupPrefabs.Length);
            Instantiate(PowerupPrefabs[PowerupIndex], spawnPos, PowerupPrefabs[PowerupIndex].transform.rotation);
        
        }
    }

   public void UpdateScore( int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score:" + score;
    }

   public void GameOver()
   {
       GameOvertext.gameObject.SetActive(true);
       restartButton.gameObject.SetActive(true);
   }

   public void RestartGame()
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }

   public void Startgame(int difficulty)
   {
       InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
       InvokeRepeating("SpawnPowerup", startDelay, repeatRate);
       playerControllerScript = GameObject.Find("Corgi").GetComponent<PlayerController>();
       score = 0;
       repeatRate = repeatRate / difficulty;
       UpdateScore(0);
       TitleScreen.gameObject.SetActive(false);
   }
}



