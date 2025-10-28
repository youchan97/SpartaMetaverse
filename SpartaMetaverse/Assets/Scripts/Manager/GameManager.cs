using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ConstInfo;

public class GameManager : SingletonManager<GameManager>
{
    [SerializeField] Dictionary<string, int> miniGameScore;

    public Dictionary<string, int> MiniGameScore { get { return miniGameScore; } set { miniGameScore = value; } }

    private void Awake()
    {
        MiniGameScore = new Dictionary<string, int>();
        if (PlayerPrefs.HasKey(loadScoreKeys))
            LoadScore();
    }

    public void UpdateMiniGameHighScore(string miniGame, int score)
    {
        if (MiniGameScore.ContainsKey(miniGame))
        {
            if(MiniGameScore[miniGame] < score)
                MiniGameScore[miniGame] = score;
        }
        else
            MiniGameScore[miniGame] = score;
    }

    public void SaveScore()
    {
        if (MiniGameScore.Count > 0) 
        {
            List<string> keys = new List<string>();
            foreach(var game in MiniGameScore)
            {
                PlayerPrefs.SetInt(game.Key, game.Value);
                keys.Add(game.Key);
            }

            PlayerPrefs.SetString(loadScoreKeys, string.Join("/", keys));
            PlayerPrefs.Save();
        }
    }

    public void LoadScore()
    {
        string keystring = PlayerPrefs.GetString(loadScoreKeys);
        string[] keys = keystring.Split("/");

        for (int i = 0; i < keys.Length; i++)
        {
            if(!string.IsNullOrEmpty(keys[i]))
            {
                int score = PlayerPrefs.GetInt(keys[i], 0);
                MiniGameScore[keys[i]] = score;
            }
        }
    }
}
