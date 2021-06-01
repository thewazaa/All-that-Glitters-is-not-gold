using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontCourtainManager : MonoBehaviour
{
    public static FrontCourtainManager Instance { get; private set; }

    private Animator animator;

    public bool fadeOnAwake = false;
    public bool opened = false;

    private void Awake()
    {
        if (Instance != null)
            Destroy(this.gameObject);
        else
        {
            Instance = this;
            animator = GetComponent<Animator>();
        }
    }

    private void Start()
    {
        if (fadeOnAwake) 
            FadeOut();
    }

    public void BeginOpen() => animator.SetBool("opened", true);

    public void BeginClose() => animator.SetBool("opened", false);

    public void FadeIn() => animator.SetTrigger("light fade in");

    public void FadeOut() => animator.SetTrigger("light fade out");

    public void SetOpened() => opened = true;
    public void SetClosed() => opened = false;
}
