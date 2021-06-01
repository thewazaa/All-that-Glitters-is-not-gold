using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHighScores : MonoBehaviour
{
    public static MenuHighScores Instance { get; private set; }

    private TextMeshProUGUI text;
    private RectTransform rectTransform;

    private static bool currentFurther = true;
    private static DifficultyManager.EDifficultyLevel currentDifficulty = DifficultyManager.EDifficultyLevel.easy;    

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);
        else
        {
            Instance = this;
            text = GetComponentInChildren<TextMeshProUGUI>();
            rectTransform = text.GetComponent<RectTransform>();
        }
    }

    private void Start() => GetText();

    private void GetNextText()
    {
        switch (currentDifficulty)
        {
            case DifficultyManager.EDifficultyLevel.easy: currentDifficulty = DifficultyManager.EDifficultyLevel.normal; break;
            case DifficultyManager.EDifficultyLevel.normal: currentDifficulty = DifficultyManager.EDifficultyLevel.hard; break;
            case DifficultyManager.EDifficultyLevel.hard: currentDifficulty = DifficultyManager.EDifficultyLevel.veryHard; break;
            case DifficultyManager.EDifficultyLevel.veryHard:
            default:
                currentDifficulty = DifficultyManager.EDifficultyLevel.easy;
                currentFurther = !currentFurther;
                break;
        }
        GetText();
    }

    private void GetText()
    {
        string difficulty = GetDifficulty();

        Dictionary<DifficultyManager.EDifficultyLevel, HighScore> info = currentFurther ? HighScoresManager.Furthers : HighScoresManager.Highers;
        if (info.ContainsKey(currentDifficulty))
        {
            text.text = (currentFurther ? LanguageManager.Instance.Text.highScoreFurtherText : LanguageManager.Instance.Text.highScoreHighestText)
                .Replace("[difficulty]", difficulty).Replace("[gold]", $"{info[currentDifficulty].gold}")
                .Replace("[time]", $"{(int)info[currentDifficulty].time / 60:00}:{(int)info[currentDifficulty].time % 60:00}");
        }
        else
            text.text = LanguageManager.Instance.Text.highScoreNotText.Replace("[difficulty]", difficulty);

        rectTransform.anchoredPosition = new Vector2((1920 + text.preferredWidth) / 2, 0);
    }

    private string GetDifficulty()
    {
        return currentDifficulty switch
        {
            DifficultyManager.EDifficultyLevel.easy => LanguageManager.Instance.Text.bEasy,
            DifficultyManager.EDifficultyLevel.normal => LanguageManager.Instance.Text.bNormal,
            DifficultyManager.EDifficultyLevel.hard => LanguageManager.Instance.Text.bHard,
            _ => LanguageManager.Instance.Text.bVeryHard
        };
    }

    private void Update()
    {
        rectTransform.anchoredPosition -= new Vector2(Time.deltaTime * 400, 0);
        if (rectTransform.anchoredPosition.x <= -(1920 + text.preferredWidth) / 2)
            GetNextText();
    }
}
