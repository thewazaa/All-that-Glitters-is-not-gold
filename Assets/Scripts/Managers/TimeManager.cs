using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance { get; private set; }

    private TextMeshProUGUI text;

    private float totalTime = 0;

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
        float previousTime = totalTime;
        totalTime += Time.deltaTime;
        text.text = $"{LanguageManager.Instance.Text.tTime}: {((int)totalTime / 60).ToString("00")}:{((int)totalTime % 60).ToString("00")}";
    }
}