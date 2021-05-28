using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoldManager : MonoBehaviour
{
    public static GoldManager Instance { get; private set; }

    private TextMeshProUGUI text;

    private int totalGold = 0;
    public int TotalGold
    {
        get => totalGold;
        set
        {
            totalGold = value;
            text.text = $"{LanguageManager.Instance.Text.tGold}: {value}";
        }
    }

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

    private void Start() => TotalGold = 0;
}