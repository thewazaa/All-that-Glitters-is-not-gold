using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Floor : MonoBehaviour
{
    public float width = 60;

    private CoinOrBomb[] coinOrBombs;

    private void Awake()
    {
        coinOrBombs = GetComponentsInChildren<CoinOrBomb>();
    }

    private void OnBecameVisible()
    {
#if UNITY_EDITOR
        if (Camera.current && Camera.current.name == "SceneCamera") return;
#endif
        WalkAreaManager.Instance.ShowFloorAfter(this);
    }

    private void OnBecameInvisible()
    {
#if UNITY_EDITOR
        if (Camera.current && Camera.current.name == "SceneCamera") return;
#endif
        WalkAreaManager.Instance.HideFloor(this);
    }

    public void Reset()
    {
        foreach (CoinOrBomb coinOrBomb in coinOrBombs)
            coinOrBomb.Reset();
    }

    public void ChangeHowItIsSeen()
    {
        foreach (CoinOrBomb coinOrBomb in coinOrBombs)
            coinOrBomb.ChangeHowItIsSeen();
    }
}