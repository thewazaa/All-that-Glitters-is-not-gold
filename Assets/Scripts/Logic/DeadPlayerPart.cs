using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPlayerPart : MonoBehaviour
{
    public GameObject connect;

    private void Start()
    {
        gameObject.transform.position = connect.transform.position;
        gameObject.transform.rotation = connect.transform.rotation;        
    }
}