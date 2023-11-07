using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;

[System.Serializable]
public class PlayerScore
{
    public string name; // Player Name
    public int score; // Score 
    public string time; // kuinka kauan on pelattu peliä
    public string date; // Milloin on pelattu
}
public class SaveLoadJSON : MonoBehaviour
{
    public List<PlayerScore> players;
    public void NewScore(string name, int score, string time, string date)
    {
        PlayerScore p = new PlayerScore();
        p.name = name;
        p.score = score;
        p.time = time;
        p.date = date;

        players.Add(p);
    }

    // Start is called before the first frame update
    void Start()
    {
        DateTime now = DateTime.UtcNow;

        //StartGame = now.ToString();

        string date = DateTime.Now.ToString("dd.mm.yyyy");

        NewScore("Kimmo", 500, "150", date);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
