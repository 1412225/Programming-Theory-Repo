using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Threading;
using UnityEditor.SearchService;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] TextMeshProUGUI livesText;

    private string playerName;
    private float time;
    public static int score = 0;
    private int enemyCount = 2;
    public static int lives = 3;
    public static bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    { 
        if (MenuManager.Instance.playerName != null)
        {
            playerName = MenuManager.Instance.playerName;
        }
        nameText.text = "Name: " + playerName;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeText.text = "Time: " + Mathf.FloorToInt(time);
        scoreText.text = "Score: " + score;
        livesText.text = "Lives: " + lives;

        SpawnWave();
    }

    void SpawnWave()
    {
        if (GameObject.FindWithTag("Enemy") == null)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], new Vector3(Random.Range(-5, 5), 3, Random.Range(-5, 5)), Random.rotation);
            }
            enemyCount++;
        }
    }

}
