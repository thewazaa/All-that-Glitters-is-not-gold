using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PrinceOfMoroccoManager : MonoBehaviour
{
    public static PrinceOfMoroccoManager Instance { get; private set; }

    private TextMeshProUGUI text;
    private string textToShow;
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

    private void Start() => textToShow = LanguageManager.Instance.Text.allThatGlittersIsNotGold;

    public void StartAction() => animator.SetTrigger("start");

    public void Reset()
    {
        animator.ResetTrigger("start");
        animator.SetTrigger("reset");
    }

    public IEnumerator CoroutineWriteText()
    {
        Talk();
        for (int i = 1; i <= textToShow.Length; i++)
        {
            text.text = textToShow.Substring(0, i);
            yield return new WaitForSeconds(GameManager.Instance.soundAllThatGlittersIsNotGold.length / textToShow.Length);
        }   
        GlitterManager.Instance.SetGlitterOn();
    }

    public void SoundMagicExplosion() => audioSource.PlayOneShot(GameManager.Instance.soundMagicExplosion);

    public void Talk() => audioSource.PlayOneShot(GameManager.Instance.soundAllThatGlittersIsNotGold);
}