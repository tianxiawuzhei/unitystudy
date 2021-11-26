using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> list;
    private float spawnRate = 1.0f;

    public TextMeshProUGUI scoreText;

    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnTarget()
    {
        while (true)
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
}
