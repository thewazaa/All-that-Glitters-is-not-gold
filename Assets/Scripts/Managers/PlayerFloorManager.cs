using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFloorManager : MonoBehaviour
{
    public static PlayerFloorManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
            Destroy(this);
        else
        {
            Instance = this;
            enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 8)
            return;
        PlayerManager.Instance.OnFloor = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 8)
            return;
        PlayerManager.Instance.OnFloor = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 8)
            return;
        PlayerManager.Instance.OnFloor = false;
    }
}