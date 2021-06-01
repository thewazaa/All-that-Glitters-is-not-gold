using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance { get; private set; }

    private TextMeshProUGUI text;

    public float totalTime = 0;

    public bool enableTimer;

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);
        else
        {
            Instance = this;
            text = GetComponentInChildren<TextMeshProUGUI>();
        }
    }

    private void FixedUpdate()
    {
        if (!enableTimer)
            return;
        totalTime += Time.deltaTime;
        if (GameManager.Instance.speed < .1 && totalTime > 60)
        {
            PlayerManager.Instance.speed += Time.deltaTime / 50;
            GameManager.Instance.speed += Time.deltaTime / 5000;
        }

        text.text = $"{LanguageManager.Instance.Text.tTime}: {(int)totalTime / 60:00}:{(int)totalTime % 60:00}";
    }
}