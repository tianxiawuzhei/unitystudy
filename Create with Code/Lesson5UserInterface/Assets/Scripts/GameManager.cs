using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> list;
    private float spawnRate = 1.0f;
    public bool isGameActive;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScene;

    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, list.Count);
            Instantiate(list[index]);
        }
        
    }
    public void UpdateScore(int scoreAdd)
    {
        score += scoreAdd;
        scoreText.text = "Score:" + score;
    }

    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {   
        score = 0;
        isGameActive = true;

        spawnRate = spawnRate / difficulty;
        
        StartCoroutine(SpawnTarget());
       
        UpdateScore(0);
        
        titleScene.gameObject.SetActive(false);
        
    }
}
