using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinOrBomb : MonoBehaviour
{
    public enum ECoinOrBomb
    {
        Coin,
        Bomb
    }

    public ECoinOrBomb worksAs;
    public ECoinOrBomb lookAs;

    public bool inmutable = false;

    private bool isActive = true;

    private ECoinOrBomb initialWorkAs;
    private ECoinOrBomb OpositeInitialWorkAs => initialWorkAs == ECoinOrBomb.Coin ? ECoinOrBomb.Bomb : ECoinOrBomb.Coin;

    private AudioSource audioSource;
    private Animator animator;

    private void Awake()
    {
        initialWorkAs = worksAs;
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    public void Start() => Reset();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isActive)
            return;
        switch (worksAs)
        {
            case ECoinOrBomb.Coin:
                if (collision.gameObject.layer != 6)
                    return;
                audioSource.PlayOneShot(GameManager.Instance.soundCoin);
                Deactivate("hide");
                GoldManager.Instance.TotalGold++;
                break;
            case ECoinOrBomb.Bomb:
                audioSource.PlayOneShot(GameManager.Instance.soundExplosion);
                Deactivate("explode");

                if (collision.gameObject.layer != 6 && collision.gameObject.layer != 9)
                    return;
                PlayerManager.Instance.gameObject.SetActive(false);
                DeadPlayerManager.Instance.Replace();
                GameManager.Instance.End();
                break;
        }
    }

    public void Reset()
    {
        isActive = true;
        animator.SetTrigger("reset");
        ChangeHowItIsSeen();
    }

    private void Deactivate(string how)
    {
        isActive = false;
        animator.SetTrigger(how);
    }

    public void ChangeHowItIsSeen()
    {
        if (DifficultyManager.Instance.difficultyLevel == DifficultyManager.EDifficultyLevel.easy)
        {
            worksAs = lookAs;
            animator.SetBool("glow", worksAs == ECoinOrBomb.Coin);
        }
        else if (GlitterManager.Instance == null)
        {
            worksAs = initialWorkAs;
            animator.SetBool("glow", worksAs == ECoinOrBomb.Coin);
        }
        else
        {
            worksAs = inmutable || !GlitterManager.Instance.glitterIsBad ? initialWorkAs : OpositeInitialWorkAs;
            animator.SetBool("glow", GlitterManager.Instance.glitterIsBad && worksAs != ECoinOrBomb.Coin || !GlitterManager.Instance.glitterIsBad && worksAs == ECoinOrBomb.Coin);
        }
    }
}