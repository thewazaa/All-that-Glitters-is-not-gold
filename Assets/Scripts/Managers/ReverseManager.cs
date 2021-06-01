using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ReverseManager : MonoBehaviour
{
    public static ReverseManager Instance { get; private set; }

    public bool reversing = false;

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
        canvas.enabled = false;
        switch (DifficultyManager.Instance.difficultyLevel)
        {
            case DifficultyManager.EDifficultyLevel.hard: 
            case DifficultyManager.EDifficultyLevel.veryHard: 
                StartCoroutine(CourotineStage(80)); 
                break;
        }
    }

    private IEnumerator CourotineStage(int time)
    {
        reversing = false;
        canvas.enabled = false;

        if (!GameOverManager.Instance.End)
        {
            yield return new WaitForSeconds(time);
            JulietManager.Instance.StartAction();
        }
    }

    public void SetReversing() => StartCoroutine(CoroutineDownTime());

    private IEnumerator CoroutineDownTime()
    {
        canvas.enabled = true;
        reversing = true;

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
        StartCoroutine(CourotineStage(Random.Range(60, 120)));
    }
}