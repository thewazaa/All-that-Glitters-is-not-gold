using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }

    private CanvasGroup canvasGroup;
    private AudioSource audioSource;

    [Header("Translations")]
    public TextMeshProUGUI bStartGame;
    public TextMeshProUGUI bConfig;
    public TextMeshProUGUI bQuit;

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

    private IEnumerator Start()
    {
        Translate();
        Camera.main.transform.position = new Vector3(0, 0, -10);
        PlayerManager.Instance.gameObject.SetActive(true);

        while (!FrontCourtainManager.Instance.opened)
            yield return new WaitForFixedUpdate();
        StartCoroutine(CoroutineShow(true));
#if UNITY_EDITOR || UNITY_WEBGL
        bQuit.enabled = false;
#endif
    }

    public void Translate()
    {
        bStartGame.text = LanguageManager.Instance.Text.bStartGame;
        bConfig.text = LanguageManager.Instance.Text.bConfig;
        bQuit.text = LanguageManager.Instance.Text.bQuit;
    }

    public void ButtonStart()
    {
        StartCoroutine(CoroutineHide());
        StartCoroutine(MenuDifficultyManager.Instance.CoroutineShow());
        audioSource.Play();
    }

    public void ButtonConfig()
    {
        StartCoroutine(CoroutineHide());
        StartCoroutine(ConfigManager.Instance.CoroutineShow());
        audioSource.Play();
    }

    public void ButtonQuit()
    {
        Application.Quit();
        audioSource.Play();
    }

    public IEnumerator CoroutineHide()
    {
        FrontCourtainManager.Instance.FadeOut();
        for (float i = 1; i >= 0; i -= .1f)
        {
            canvasGroup.alpha = i;
            yield return new WaitForFixedUpdate();
        }
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    public IEnumerator CoroutineShow(bool start = false)
    {
        if (!start)
            FrontCourtainManager.Instance.FadeIn();
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