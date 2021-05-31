using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDifficultyManager : MonoBehaviour
{
    public static MenuDifficultyManager Instance { get; private set; }

    private CanvasGroup canvasGroup;
    private AudioSource audioSource;

    [Header("Translations")]
    public TextMeshProUGUI bEasy;
    public TextMeshProUGUI bNormal;
    public TextMeshProUGUI bHard;
    public TextMeshProUGUI bVeryHard;
    public TextMeshProUGUI bBack;

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);
        else
        {
            Instance = this;
            canvasGroup = GetComponent<CanvasGroup>();
            audioSource = GetComponent<AudioSource>();
        }
    }

    private void Start() => Translate();

    public void Translate()
    {
        bEasy.text = LanguageManager.Instance.Text.bEasy;
        bNormal.text = LanguageManager.Instance.Text.bNormal;
        bHard.text = LanguageManager.Instance.Text.bHard;
        bVeryHard.text = LanguageManager.Instance.Text.bVeryHard;
        bBack.text = LanguageManager.Instance.Text.bBack;
    }

    public void ButtonEasy() => ButtonStart(DifficultyManager.EDifficultyLevel.easy);

    public void ButtonNormal() => ButtonStart(DifficultyManager.EDifficultyLevel.normal);

    public void ButtonHard() => ButtonStart(DifficultyManager.EDifficultyLevel.hard);

    public void ButtonVeryHard() => ButtonStart(DifficultyManager.EDifficultyLevel.veryHard);

    private void ButtonStart(DifficultyManager.EDifficultyLevel difficultyLevel)
    {
        DifficultyManager.Instance.difficultyLevel = difficultyLevel;
        StartCoroutine(CoroutineHide(true));
        audioSource.Play();
    }

    public void ButtonBack()
    {
        StartCoroutine(CoroutineHide());
        StartCoroutine(MenuManager.Instance.CoroutineShow());
        audioSource.Play();
    }

    public IEnumerator CoroutineHide(bool changeScene = false)
    {
        for (float i = 1; i >= 0; i -= .1f)
        {
            canvasGroup.alpha = i;
            yield return new WaitForFixedUpdate();
        }
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
        if (changeScene)
        {
            PlayerFloorManager.Instance.Reset();
            SceneManager.LoadScene(1);            
        }
    }

    public IEnumerator CoroutineShow()
    {
        for (float i = 0; i <= 1; i += .1f)
        {
            canvasGroup.alpha = i;
            yield return new WaitForFixedUpdate();
        }
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }
}