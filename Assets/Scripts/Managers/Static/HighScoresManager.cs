using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;

public static class HighScoresManager
{
    public static Dictionary<DifficultyManager.EDifficultyLevel,HighScore> Furthers
    {
        get
        {
            string tmp = PlayerPrefs.GetString("Further");
            if (tmp == null || tmp == "")
                return new Dictionary<DifficultyManager.EDifficultyLevel, HighScore> { };
            return JsonConvert.DeserializeObject<Dictionary<DifficultyManager.EDifficultyLevel, HighScore>>(tmp);
        }
        private set => PlayerPrefs.SetString("Further", JsonConvert.SerializeObject(value));
    }

    public static Dictionary<DifficultyManager.EDifficultyLevel, HighScore> Highers
    {
        get
        {
            string tmp = PlayerPrefs.GetString("Higher");
            if (tmp == null || tmp == "")
                return new Dictionary<DifficultyManager.EDifficultyLevel, HighScore> { };
            return JsonConvert.DeserializeObject<Dictionary<DifficultyManager.EDifficultyLevel, HighScore>>(tmp);
        }
        private set => PlayerPrefs.SetString("Higher", JsonConvert.SerializeObject(value));
    }

    public static void AddHighScore(DifficultyManager.EDifficultyLevel difficultyLevel,  float time, int gold)
    {
        HighScore highScore = new HighScore(time, gold);

        Dictionary<DifficultyManager.EDifficultyLevel, HighScore> furthers = Furthers;
        if (!furthers.ContainsKey(difficultyLevel) || furthers[difficultyLevel].time < time ||
            (furthers[difficultyLevel].time == time && furthers[difficultyLevel].gold < gold))
        {
            furthers[difficultyLevel] = highScore;
            Furthers = furthers;
        }

        Dictionary<DifficultyManager.EDifficultyLevel, HighScore> highers = Highers;
        if (!highers.ContainsKey(difficultyLevel) || highers[difficultyLevel].gold < gold ||
            (highers[difficultyLevel].gold == gold && highers[difficultyLevel].time > time))
        {
            highers[difficultyLevel] = highScore;
            Highers = highers;
        }
    }
}

public class HighScore
{
    public float time;
    public int gold;

    public HighScore(float time, int gold)
    {
        this.time = time;
        this.gold = gold;
    }
}
