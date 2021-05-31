using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class FloorTutorial : MonoBehaviour
{
    public GameObject[] hideOnEasy;
    public GameObject[] showOnEasy;
    public GameObject[] showOnVeyHard;
    public GameObject[] hideOnVeyHard;


    public TextMeshPro textCoin;
    public TextMeshPro textBomb;
    public TextMeshPro textWalkingBoxes;
    public TextMeshPro textBackBoxes;
    public TextMeshPro textBeware;

    private void Start()
    {
        textCoin.text = LanguageManager.Instance.Text.tCoins;
        textBomb.text = LanguageManager.Instance.Text.tBombs;
        textWalkingBoxes.text = LanguageManager.Instance.Text.tWalkingBoxes;
        textBackBoxes.text = LanguageManager.Instance.Text.tBackBoxes;
        textBeware.text = LanguageManager.Instance.Text.tBeware;

        if (DifficultyManager.Instance.difficultyLevel == DifficultyManager.EDifficultyLevel.easy)
            foreach (GameObject gameObject in hideOnEasy)
                gameObject.SetActive(false);
        else
            foreach (GameObject gameObject in showOnEasy)
                gameObject.SetActive(false);
        if (DifficultyManager.Instance.difficultyLevel == DifficultyManager.EDifficultyLevel.veryHard)
            foreach (GameObject gameObject in hideOnVeyHard)
                gameObject.SetActive(false);
        else
            foreach (GameObject gameObject in showOnVeyHard)
                gameObject.SetActive(false);
    }
}