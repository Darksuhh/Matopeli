using System.Collections;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;
using System.IO;

[System.Serializable]
public class PlayerScore
{
    public string name; // Player Name
    public int score; // Score 
    public string time; // kuinka kauan on pelattu peli‰
    public string date; // Milloin on pelattu
}
public class SaveLoadJSON : MonoBehaviour
{
    public GameObject Snake;

    public List<PlayerScore> players;

    string saveFilePath;
    // Start is called before the first frame update
    void Start()
    {
        saveFilePath = Application.persistentDataPath + "/PlayerData.json";
        Debug.Log(saveFilePath);

    }

    public void LoadScore()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            // muutetaan json players muuttujiksi
            players = JsonConvert.DeserializeObject<List<PlayerScore>>(json);
        }
    }

    public void SaveScore()
    {
        string PlayerJSON = JsonConvert.SerializeObject(players, new Newtonsoft.Json.Converters.StringEnumConverter());
        // tallenneaan players tiedot
        File.WriteAllText(saveFilePath, PlayerJSON);
    }
    public void NewScore(string name, int score, string time, string date)
    {
        PlayerScore p = new PlayerScore();
        p.name = name;
        p.score = score;
        p.time = time;
        p.date = date;

        players.Add(p);
    }

    public void AddNewScore(string name)
    {
        int score = Snake.GetComponent<Snake>().score; // haetaan pisteet k‰‰rmeest‰

        DateTime startgame = Snake.GetComponent<Snake>().StartGame; // haetaan aloitusaika k‰‰rmeest‰

        DateTime endgame = DateTime.UtcNow; // annetaan t‰m‰nhetkinen lopetusaika

        string time = (endgame - startgame).TotalSeconds.ToString(); // lasketaan kuinkamonta sekunttia on mennyt aloituksen ja lopetus v‰liss‰

        string date = DateTime.Now.ToString("dd.MM.yyyy");  

        NewScore(name, score, time, date);

        Debug.Log($"Player: {name} Score: {score} Startgame: {startgame} Endgame: {endgame} Time: {time}");

        SaveScore();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
