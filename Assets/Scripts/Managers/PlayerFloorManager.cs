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

    private int collisions = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != 8)
            return;
        collisions++;
        PlayerManager.Instance.OnFloor = collisions != 0;
    }


    private void OnTriggerExit2D(Collider2D collision)
    {        
        if (collision.gameObject.layer != 8)
            return;
        collisions--;
        PlayerManager.Instance.OnFloor = collisions != 0;
    }

    public void Reset() => collisions = 0;
}