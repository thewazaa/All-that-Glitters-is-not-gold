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
    private Box[] boxes;

    private void Awake()
    {
        coinOrBombs = GetComponentsInChildren<CoinOrBomb>();
        boxes = GetComponentsInChildren<Box>();
    }

    private void Start() => ChangeHowItIsSeen();

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
        Destroy(this.gameObject);
    }

    public void ChangeHowItIsSeen()
    {
        foreach (CoinOrBomb coinOrBomb in coinOrBombs)
            coinOrBomb.ChangeHowItIsSeen();
        foreach (Box box in boxes)
            box.ChangeHowItIsSeen();
    }
}