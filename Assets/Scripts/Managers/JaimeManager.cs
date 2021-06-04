using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JaimeManager : MonoBehaviour
{
    public static JaimeManager Instance { get; private set; }

    private TextMeshProUGUI text;
    private readonly string[] textToShow = new string[3];
    private Animator animator;
    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance != null)
            Destroy(this.gameObject);
        else
        {
            Instance = this;
            text = GetComponentInChildren<TextMeshProUGUI>();
            animator = GetComponent<Animator>();
            audioSource = GetComponent<AudioSource>();
        }
    }

    private void Start() => Translate();

    public void Translate()
    {
        textToShow[0] = LanguageManager.Instance.Text.allTheWorldIsAStage;
        textToShow[1] = LanguageManager.Instance.Text.andAlltheMenAndWomenMerelyPlayers;
        textToShow[2] = LanguageManager.Instance.Text.theyHaveTheirExitsAndTheirEntrances;
    }

    public void StartAction() => animator.SetTrigger("start");

    public void Reset()
    {
        animator.ResetTrigger("start");
        animator.SetTrigger("reset");
    }

    public void HideText() => text.text = "";

    public IEnumerator CoroutineWriteText(int id)
    {
        Talk(id);
        for (int i = 1; i <= textToShow[id].Length; i++)
        {
            text.text = textToShow[id].Substring(0, i);
            yield return new WaitForSeconds(GameManager.Instance.soundJaime[id].length / textToShow[id].Length);
        }
        if (id == 2)
            StageManager.Instance.SetStaging();
    }

    public void SoundMagicExplosion() => audioSource.PlayOneShot(GameManager.Instance.soundMagicExplosion);

    public void Talk(int id) => audioSource.PlayOneShot(GameManager.Instance.soundJaime[id]);
}