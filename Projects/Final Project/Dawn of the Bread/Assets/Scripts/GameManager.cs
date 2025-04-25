using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Public variables
    public TextMeshProUGUI timeText;
    public GameObject[] enemyPrefabs;
    public TextMeshProUGUI gameOverText;
    public bool isGameActive;
    public Button restartButton;
    public GameObject titleScreen;

    //Private Variables
    private float spawnPosZ = 40;
    private float spawnRangeX = 25;
    private float spawnRate = 4.0f;
    private Coroutine spawnCoroutine;

    void Start()
    {
        gameOverText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Starts Game
    public void StartGame(int difficulty)
    {
        isGameActive = true;
        spawnRate /= difficulty;
        spawnCoroutine = StartCoroutine(SpawnTarget());
        titleScreen.gameObject.SetActive(false);
    }

    //Timer for game

    //Game Over screen
    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    //Spawns enemies randomly in a set area
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
            Instantiate(enemyPrefabs[enemyIndex], spawnPos, enemyPrefabs[enemyIndex].transform.rotation);

            if (spawnCoroutine != null)
            {
                StopCoroutine(spawnCoroutine);
            }
        }
    }

    //Restarts game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
