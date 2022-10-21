using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static int score;
    public TextMeshProUGUI points;
    float timer;
    public float increaseTime;
    public static float speedIncrease;
    public GameObject button;
    public GameObject[] spawn;
    

    // Start is called before the first frame update
    void Awake()
    {
        score = 0;
        timer = 0;
        speedIncrease = 1;
    }
    private void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > increaseTime)
        {
            speedIncrease += 0.1f;
            timer = 0;
        }
    }
    public void AddScore()
    {
        score += 1;
        points.text = score.ToString();
    }
    public void StartGame()
    {
        Instantiate(spawn[0]);
        Instantiate(spawn[1]);
        Instantiate(spawn[2]);
        Destroy(button);
    }
}
