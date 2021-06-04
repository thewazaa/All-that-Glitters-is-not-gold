using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfigManager : MonoBehaviour
{
    public static ConfigManager Instance { get; private set; }

    private CanvasGroup canvasGroup;
    private AudioSource audioSource;

    [Header("Toggle")]
    public Toggle tMusic;
    public Toggle tSound;

    public Toggle tEnglish;
    public Toggle tSpanish;
    public Toggle tCatalonian;

    [Header("Translations")]
    public TextMeshProUGUI bMusic;
    public TextMeshProUGUI bSound;
    public TextMeshProUGUI bAbout;

    public TextMeshProUGUI bEnglish;
    public TextMeshProUGUI bSpanish;
    public TextMeshProUGUI bCatalonian;

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

    private void Start()
    {
        tMusic.isOn = Settings.Instance.Music;
        tSound.isOn = Settings.Instance.Sound;
        switch (LanguageManager.Instance.Language)
        {
            case "Spanish": tSpanish.isOn = true;break;
            case "English": tEnglish.isOn = true; break;
            default: tCatalonian.isOn = true;break;
        }
        Translate();
    }

    public void Translate()
    {
        bMusic.text = LanguageManager.Instance.Text.bMusic;
        bSound.text = LanguageManager.Instance.Text.bSound;
        bAbout.text = LanguageManager.Instance.Text.bAbout;

        bEnglish.text = LanguageManager.Instance.Text.bEnglish;
        bSpanish.text = LanguageManager.Instance.Text.bSpanish;
        bCatalonian.text = LanguageManager.Instance.Text.bCatalonian;

        bBack.text = LanguageManager.Instance.Text.bBack;
    }

    public void ButtonMusic(bool check)
    {
        Settings.Instance.Music = check;
        audioSource.Play();
    }

    public void ButtonSound(bool check)
    {
        Settings.Instance.Sound = check;
        audioSource.Play();
    }

    public void ButtonAbout()
    {
        StartCoroutine(CoroutineHide());
        StartCoroutine(AboutManager.Instance.CoroutineShow());
        audioSource.Play();
    }

    public void ButtonLanguage(string language)
    {
        LanguageManager.Instance.Language = language;
        Translate();
        MenuManager.Instance.Translate();
        MenuDifficultyManager.Instance.Translate();
        JaimeManager.Instance.Translate();
        JulietManager.Instance.Translate();
        PrinceOfMoroccoManager.Instance.Translate();
        audioSource.Play();
    }

    public void ButtonBack()
    {
        StartCoroutine(CoroutineHide());
        StartCoroutine(MenuManager.Instance.CoroutineShow());
        audioSource.Play();
    }
    public IEnumerator CoroutineHide()
    {
        for (float i = 1; i >= 0; i -= .1f)
        {
            canvasGroup.alpha = i;
            yield return new WaitForFixedUpdate();
        }
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
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
