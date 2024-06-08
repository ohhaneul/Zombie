using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 3;        // ĳ���Ͱ� �޸��� �ӵ�
    public float leftRightSpeed = 4;    // �� ������ �����̴� �ӵ�
    //public ���� private ���� 


    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) // ���� �̵��� ����Ű�� AŰ
        {
            if (this.gameObject.transform.position.x > Boundary.leftside)
            {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
            }
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) // ������ �̵��� ����Ű�� DŰ
        {
            if (this.gameObject.transform.position.x < Boundary.rightside)
            {
                transform.Translate(Vector3.right * Time.deltaTime * leftRightSpeed);
            }
        }
    }
}
