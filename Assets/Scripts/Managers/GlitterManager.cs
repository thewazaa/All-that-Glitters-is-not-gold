using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GlitterManager : MonoBehaviour
{
    public static GlitterManager Instance { get; private set; }

    public bool glitterIsBad = false;

    public Image clock;

    private TextMeshProUGUI text;
    private Canvas canvas;
    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);
        else
        {
            Instance = this;
            text = GetComponentInChildren<TextMeshProUGUI>();
            canvas = GetComponent<Canvas>();
            audioSource = GetComponent<AudioSource>();
        }
    }

    private void Start()
    {
        glitterIsBad = DifficultyManager.Instance.difficultyLevel == DifficultyManager.EDifficultyLevel.hard;
        canvas.enabled = false;
        WalkAreaManager.Instance.ChangeHowItIsSeen();
    }

    private IEnumerator CourotineGlitter()
    {
        glitterIsBad = false;
        canvas.enabled = false;
        WalkAreaManager.Instance.ChangeHowItIsSeen();
        if (!GameOverManager.Instance.End)
        {
            yield return new WaitForSeconds(30);
            PrinceOfMoroccoManager.Instance.StartAction();
        }
    }

    public void SetGlitterOn() => StartCoroutine(CoroutineDownTime());

    private IEnumerator CoroutineDownTime()
    {
        canvas.enabled = true;
        glitterIsBad = true;
        WalkAreaManager.Instance.ChangeHowItIsSeen();
        GameManager.Instance.pause = false;
        int time = 30;
        while (time > 0 && !GameOverManager.Instance.End)
        {
            clock.fillAmount = time / 30f;
            text.text = $"{time / 60:00}:{time % 60:00}";
            yield return new WaitForSeconds(1);
            time--;
            if (time <= 3)
                audioSource.PlayOneShot(GameManager.Instance.soundTick);
        }
        canvas.enabled = false;
        StartCoroutine(CourotineGlitter());
    }
}