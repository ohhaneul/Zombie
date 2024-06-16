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
        else return;      // Floor 혹은 다른 물체와의 충돌 무시
    }
}
