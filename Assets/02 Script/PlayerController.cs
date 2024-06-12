using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum SIDE { Left, Center, Right }

public class PlayerController : MonoBehaviour
{
    public SIDE c_Side = SIDE.Center;
    float NewXPos = 0f;
    public bool SwipeLeft;
    public bool SwipeRight;
    public bool SwipeUp;
    public float XValue = 2.5f;
    private Rigidbody rb;
    private Animator m_Animator;
    private float x;
    public float SpeedDodge = 5f; // SpeedDodge 초기화
    public float speed = 10f;
    public float JumpPower = 5f;
    private bool isJump = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        m_Animator = GetComponent<Animator>();
        transform.position = new Vector3(0, 0.5f, -9f);
    }

    void Update()
    {
        SwipeUp = Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W);
        SwipeLeft = Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A); // 왼쪽 이동은 방향키랑 A키
        SwipeRight = Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D); // 오른쪽 이동은 방향키랑 D키

        if (SwipeUp && isJump == false)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * JumpPower, ForceMode.Impulse);
            isJump = true;
        }

        if (SwipeLeft)
        {
            if (c_Side == SIDE.Center)
            {
                NewXPos = -XValue;
                c_Side = SIDE.Left;
                m_Animator.Play("DodgeLeft");
            }
            else if (c_Side == SIDE.Right)
            {
                NewXPos = 0;
                c_Side = SIDE.Center;
                m_Animator.Play("DodgeLeft");
            }
        }
        else if (SwipeRight)
        {
            if (c_Side == SIDE.Center)
            {
                NewXPos = XValue;
                c_Side = SIDE.Right;
                m_Animator.Play("DodgeRight");
            }
            else if (c_Side == SIDE.Left)
            {
                NewXPos = 0;
                c_Side = SIDE.Center;
                m_Animator.Play("DodgeRight");
            }
        }

        x = Mathf.Lerp(x, NewXPos, Time.deltaTime * 10f * SpeedDodge);
    }

    void FixedUpdate()
    {
        // 새로운 위치 계산
        Vector3 newPosition = new Vector3(x, transform.position.y, transform.position.z + speed * Time.deltaTime);

        // Rigidbody를 이용하여 새로운 위치로 이동
        rb.MovePosition(newPosition);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }
    }
}