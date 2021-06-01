using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance { get; private set; }

    public bool staging = false;

    public Image clock;

    private TextMeshProUGUI text;
    private Canvas canvas;
    private AudioSource audioSource;
    private ChairLine[] chairLines;

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
        chairLines = FindObjectsOfType<ChairLine>();

        canvas.enabled = false;
        switch (DifficultyManager.Instance.difficultyLevel)
        {
            case DifficultyManager.EDifficultyLevel.normal: StartCoroutine(CourotineStage(30)); break;
            case DifficultyManager.EDifficultyLevel.hard: StartCoroutine(CourotineStage(30)); break;
            case DifficultyManager.EDifficultyLevel.veryHard: StartCoroutine(CourotineStage(130)); break;
        }
    }

    private IEnumerator CourotineStage(int time)
    {
        staging = false;
        canvas.enabled = false;

        foreach (ChairLine chairLine in chairLines)
            chairLine.chairLineMovement = ChairLine.EChairLineMovement.stopped;

        if (!GameOverManager.Instance.End)
        {
            yield return new WaitForSeconds(time);
            JaimeManager.Instance.StartAction();
            foreach (ChairLine chairLine in chairLines)
                chairLine.chairLineMovement = ChairLine.EChairLineMovement.sinusoidal;
        }
    }

    public void SetStaging() => StartCoroutine(CoroutineDownTime());

    private IEnumerator CoroutineDownTime()
    {
        canvas.enabled = true;
        staging = true;
        foreach (ChairLine chairLine in chairLines)
            chairLine.chairLineMovement = ChairLine.EChairLineMovement.linear;
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
        switch (DifficultyManager.Instance.difficultyLevel)
        {
            case DifficultyManager.EDifficultyLevel.normal: StartCoroutine(CourotineStage(Random.Range(15, 45))); break;
            case DifficultyManager.EDifficultyLevel.hard: StartCoroutine(CourotineStage(Random.Range(35, 105))); break;
            case DifficultyManager.EDifficultyLevel.veryHard: StartCoroutine(CourotineStage(Random.Range(65, 195))); break;
        }
    }
}