using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JustFollow : MonoBehaviour
{
    public float moveSpeed = 10;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
    }
}
