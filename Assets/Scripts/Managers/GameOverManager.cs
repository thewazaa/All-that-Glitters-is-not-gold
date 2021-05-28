using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance { get; private set; }

    private new Animation animation;

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
        }
    }

    public void GameOver()
    {
        End = true;
        animation.Play();
        FrontCourtainManager.Instance.Close();
    }

    public void SetInteracterable() => interacterable = true;

    public void Update()
    {
        if (!interacterable || !Input.anyKeyDown)
            return;
        FrontCourtainManager.Instance.Open();
        PlayerManager.Instance.Reset();
        SceneManager.LoadScene(0);
    }
}
