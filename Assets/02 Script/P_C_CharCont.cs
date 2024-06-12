//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[System.Serializable]
//public enum SIDE { Left, Center, Right }

//public class PlayerController : MonoBehaviour
//{
//    public SIDE c_Side = SIDE.Center;
//    float NewXPos = 0f;
//    public bool SwipeLeft;
//    public bool SwipeRight;
//    public float XValue = 2.5f;
//    private CharacterController m_char;
//    private Animator m_Animator;
//    private float x;
//    public float SpeedDodge;
//    public float speed = 10f;

//    private void Start()
//    {
//        m_char = GetComponent<CharacterController>();
//        m_Animator = GetComponent<Animator>();
//        transform.position = new Vector3(0, 0.5f, -9f);
//    }

//    void Update()
//    {

//        SwipeLeft = Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A); // 왼쪽 이동은 방향키랑 A키
//        SwipeRight = Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D); // 오른쪽 이동은 방향키랑 D키

//        if (SwipeLeft)
//        {
//            if (c_Side == SIDE.Center)
//            {
//                NewXPos = -XValue;
//                c_Side = SIDE.Left;
//                m_Animator.Play("DodgeLeft");
//            }
//            else if (c_Side == SIDE.Right)
//            {
//                NewXPos = 0;
//                c_Side = SIDE.Center;
//                m_Animator.Play("DodgeLeft");
//            }
//        }
//        else if (SwipeRight)
//        {
//            if (c_Side == SIDE.Center)
//            {
//                NewXPos = XValue;
//                c_Side = SIDE.Right;
//                m_Animator.Play("DodgeRight");
//            }
//            else if (c_Side == SIDE.Left)
//            {
//                NewXPos = 0;
//                c_Side = SIDE.Center;
//                m_Animator.Play("DodgeRight");
//            }
//        }

//        x = Mathf.Lerp(x, NewXPos, Time.deltaTime * 10f * SpeedDodge);
//        m_char.Move((x - transform.position.x) * Vector3.right);

//        Vector3 forwardMove = transform.forward * speed * Time.deltaTime;
//        m_char.Move(forwardMove);
//    }
//}