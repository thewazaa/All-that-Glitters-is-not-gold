using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool glitterIsBad = false;

    public float speed = .05f;

    [Header("Sounds")]
    public AudioClip soundCoin;
    public AudioClip soundExplosion;
    public AudioClip soundMagicExplosion;

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);
        else
            Instance = this;
    }

    private void Start()
    {
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
            Camera.main.transform.position += new Vector3(speed, 0, 0);
            yield return new WaitForFixedUpdate();
        }
    }

    public void SetGlitterOn()
    {
        glitterIsBad = true;
        WalkAreaManager.Instance.ChangeHowItIsSeen();
    }
}
