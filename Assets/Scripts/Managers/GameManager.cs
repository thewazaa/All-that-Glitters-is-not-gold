using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float speed = .05f;
    public bool pause = false;

    [Header("Sounds")]
    public AudioClip soundGameOver;
    public AudioClip soundTick;
    public AudioClip soundCoin;
    public AudioClip soundExplosion;
    public AudioClip soundMagicExplosion;
    public AudioClip soundAllThatGlittersIsNotGold;
    public AudioClip[] soundJaime;

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);
        else
            Instance = this;
    }

    private IEnumerator Start()
    {
        while (!FrontCourtainManager.Instance.opened)
            yield return new WaitForFixedUpdate();
        PlayerManager.Instance.isOn = true;
        TimeManager.Instance.enableTimer = true;
        StartCoroutine(CourotineCameraMovement());
    }

    public void End()
    {
        PlayerManager.Instance.isOn = false;
        TimeManager.Instance.enableTimer = false;
        GameOverManager.Instance.GameOver();
    }

    private IEnumerator CourotineCameraMovement()
    {
        while (!GameOverManager.Instance.End)
        {
            if (!pause)
                Camera.main.transform.position += new Vector3(speed, 0, 0);
            yield return new WaitForFixedUpdate();
        }
    }
}
