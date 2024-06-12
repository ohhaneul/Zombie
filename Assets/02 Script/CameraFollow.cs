using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;    // �÷��̾��� Transform
    public Vector3 offset;      // �÷��̾�� ī�޶� ������ �Ÿ� ������

    void Start()
    {
        // �ʱ� ������ ����
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        // ī�޶��� ���ο� ��ġ�� ����
        transform.position = player.position + offset;
    }
}
