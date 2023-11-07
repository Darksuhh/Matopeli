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
        players = GetComponent<SaveLoadJSON>().players;

        for(int i=0; i < players.Count; i++)
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

    // Update is called once per frame
    void Update()
    {
        score = Snake.transform.GetComponent<Snake>().score;
        ScoreText.text = score.ToString();

        if (Input.GetKeyDown(KeyCode.P))
        {
            //GameOverPanel.SetActive(True);

            Text sc = GameOverPanel.transform.Find("ScoreText").GetComponent<Text>();
            //sc.text = score;
            Text ti = GameOverPanel.transform.Find("TimeText").GetComponent<Text>();
            //ti.text = time;

        }
    }
}
