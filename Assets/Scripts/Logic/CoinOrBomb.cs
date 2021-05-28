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

    public SpriteRenderer glowSprite;
    public bool inmutable = false;

    private ECoinOrBomb initialWorkAs;
    private ECoinOrBomb OpositeInitialWorkAs => initialWorkAs == ECoinOrBomb.Coin ? ECoinOrBomb.Bomb : ECoinOrBomb.Coin;

    private void Awake() => initialWorkAs = worksAs;

    public void Start() => Reset();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 6)
            return;
        switch (worksAs)
        {
            case ECoinOrBomb.Coin:
                GoldManager.Instance.TotalGold++;
                gameObject.SetActive(false);
                break;
            case ECoinOrBomb.Bomb:
                GameManager.Instance.End();
                break;
        }
    }

    public void Reset()
    {
        gameObject.SetActive(true);
        ChangeHowItIsSeen();
    }

    public void ChangeHowItIsSeen()
    {
        worksAs = inmutable || !GameManager.Instance.glitterIsBad ? initialWorkAs : OpositeInitialWorkAs;
        glowSprite.enabled = GameManager.Instance.glitterIsBad && worksAs != ECoinOrBomb.Coin;
    }
}