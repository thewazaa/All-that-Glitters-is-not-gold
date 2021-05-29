using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AboutManager : MonoBehaviour
{
    public static AboutManager Instance { get; private set; }

    private CanvasGroup canvasGroup;
    private AudioSource audioSource;

    [Header("Translations")]
    public TextMeshProUGUI tAbout;

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
        tAbout.text = LanguageManager.Instance.Text.tAbout;

        bBack.text = LanguageManager.Instance.Text.bBack;
    }

    public void ButtonBack()
    {
        StartCoroutine(CoroutineHide());
        StartCoroutine(ConfigManager.Instance.CoroutineShow());
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
