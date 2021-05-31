using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public enum EDifficultyLevel
    {
        easy,
        normal,
        hard,
        veryHard
    }

    public static DifficultyManager Instance { get; private set; }

    public EDifficultyLevel difficultyLevel = EDifficultyLevel.veryHard;

    private void Awake()
    {
        if (Instance != null)
            Destroy(this.gameObject);
        else
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
    }
}