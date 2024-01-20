using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Threading;

public class GameManager : MonoBehaviour
{
    private string playerName;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timeText;
    private float time;
    public static int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerName = MenuManager.Instance.playerName;
        nameText.text = "Name: " + playerName;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeText.text = "Time: " + Mathf.FloorToInt(time);
        scoreText.text = "Score: " + score;
    }
}
