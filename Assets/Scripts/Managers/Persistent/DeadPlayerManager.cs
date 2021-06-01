using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPlayerManager : MonoBehaviour
{
    public static DeadPlayerManager Instance { get; private set; }

    private DeadPlayerPart[] deadPlayerParts;

    private void Awake()
    {
        if (Instance != null)
            Destroy(this.gameObject);
        else
        {
            DontDestroyOnLoad(this);
            Instance = this;
        }
        deadPlayerParts = GetComponentsInChildren<DeadPlayerPart>(true);
    }

    public void Replace()
    {
        foreach (DeadPlayerPart deadPlayerPart in deadPlayerParts)
            deadPlayerPart.Activate();
    }

    public void Hide()
    {
        foreach (DeadPlayerPart deadPlayerPart in deadPlayerParts)
            deadPlayerPart.Deactivate();
    }
}