using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PartCollision : MonoBehaviour
{
    public GameObject explosion;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else return;      // Floor 혹은 다른 물체와의 충돌 무시
    }
}
