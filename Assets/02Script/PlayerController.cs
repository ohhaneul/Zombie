using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 3;        // 캐릭터가 달리는 속도
    public float leftRightSpeed = 4;    // 양 옆으로 움직이는 속도
    //public 쓸까 private 쓸까 


    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) // 왼쪽 이동은 방향키랑 A키
        {
            if (this.gameObject.transform.position.x > Boundary.leftside)
            {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
            }
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) // 오른쪽 이동은 방향키랑 D키
        {
            if (this.gameObject.transform.position.x < Boundary.rightside)
            {
                transform.Translate(Vector3.right * Time.deltaTime * leftRightSpeed);
            }
        }
    }
}
