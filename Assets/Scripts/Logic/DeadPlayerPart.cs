using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPlayerPart : MonoBehaviour
{
    public GameObject connect;

    private new Rigidbody2D rigidbody2D;

    private void Awake() => rigidbody2D = GetComponent<Rigidbody2D>();

    public void Activate()
    {
        gameObject.transform.position = connect.transform.position;
        gameObject.transform.rotation = connect.transform.rotation;
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        if (rigidbody2D)
            rigidbody2D.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }
}