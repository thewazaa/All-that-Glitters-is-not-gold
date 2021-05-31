using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance { get; private set; }

    private new Animation animation;
    private AudioSource audioSource;

    public bool End { get; private set; }
    private bool interacterable = false;

    private void Awake()
    {
        if (Instance != null)
            Destroy(this.gameObject);
        else
        {
            Instance = this;
            animation = GetComponent<Animation>();
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void GameOver()
    {
        End = true;
        animation.Play();

        PrinceOfMoroccoManager.Instance.Reset();
        if (FrontCourtainManager.Instance != null)
            FrontCourtainManager.Instance.Close();
    }

    public void SoundGameOver() => audioSource.PlayOneShot(GameManager.Instance.soundGameOver);

    public void SetInteracterable() => interacterable = true;

    public void Update()
    {
        if (!interacterable || !Input.anyKeyDown)
            return;
        FrontCourtainManager.Instance.Open();
        PlayerManager.Instance.Reset();
        DeadPlayerManager.Instance.Hide();
        SceneManager.LoadScene(0);
    }
}
