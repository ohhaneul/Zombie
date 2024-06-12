using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;    // 플레이어의 Transform
    public Vector3 offset;      // 플레이어와 카메라 사이의 거리 오프셋

    void Start()
    {
        // 초기 오프셋 설정
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        // 카메라의 새로운 위치를 설정
        transform.position = player.position + offset;
    }
}
