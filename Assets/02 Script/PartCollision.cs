using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PartCollision : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        else return;      // Floor Ȥ�� �ٸ� ��ü���� �浹 ����
    }
}
