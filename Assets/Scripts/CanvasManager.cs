using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public int score;

    List<PlayerScore> players;

    public GameObject PlayerScoreContent;
    public GameObject PlayerScore;

    public GameObject Snake;
    public Text ScoreText;

    public GameObject ScorePanel;
    public GameObject GameOverPanel;
    // Start is called before the first frame update
    void Start()
    {

        GetComponent<SaveLoadJSON>().LoadScore();
        players = GetComponent<SaveLoadJSON>().players;

    }

    public void UpdateHighScore()
    {

        players = GetComponent<SaveLoadJSON>().players;

        foreach (Transform t in PlayerScoreContent.transform)
            Destroy(t.gameObject);

        for (int i = 0; i < players.Count; i++)
        {
            string playername = players[i].name;
            int score = players[i].score;
            string time = players[i].time;
            string date = players[i].date;

            Debug.Log($"Playername: {playername} Score: {score} Time:{time} Date:{date}");

            GameObject p = Instantiate(PlayerScore, PlayerScoreContent.transform);

            Text pn = p.transform.Find("PlayerName").GetComponent<Text>();
            pn.text = playername;
            Text sc = p.transform.Find("Score").GetComponent<Text>();
            sc.text = score.ToString();
            Text ti = p.transform.Find("Time").GetComponent<Text>();
            ti.text = time;
            Text da = p.transform.Find("Date").GetComponent<Text>();
            da.text = date;
        }
    }

    public void ShowGameOverPanel()
    {

        GameOverPanel.SetActive(true);

        Text sc = GameOverPanel.transform.Find("ScoreText").GetComponent<Text>();
        sc.text = score.ToString();

        DateTime startgame = Snake.GetComponent<Snake>().StartGame;
        DateTime endgame = DateTime.UtcNow;

        string time = (endgame - startgame).TotalSeconds.ToString();

        Text ti = GameOverPanel.transform.Find("TimeText").GetComponent<Text>();
        ti.text = time;
    }

    public void ShowHighScorePanel()
    {
        ScorePanel.SetActive(true);
        UpdateHighScore();

        Snake.GetComponent<Snake>().isPause = true;
    }
    public void CloseHighScorePanel()
    {
        ScorePanel.SetActive(false);
        Snake.GetComponent<Snake>().isPause = false;
    }

    public void RestartButton()
    {
        string PlayerName = GameOverPanel.transform.Find("PlayerName").GetComponent<InputField>().text;

        GetComponent<SaveLoadJSON>().AddNewScore(PlayerName);

        GameOverPanel.SetActive(false);

        //Snake.GetComponent<Snake>().StartGame = DateTime.UtcNow;
        Snake.GetComponent<Snake>().ResetState();

    }
    // Update is called once per frame
    void Update()
    {
        score = Snake.transform.GetComponent<Snake>().score; // hakee k‰‰rmeest‰ pisteet
        ScoreText.text = score.ToString(); // annetaan pisteet scoretekstille
    }
}
