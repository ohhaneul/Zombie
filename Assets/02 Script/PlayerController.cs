using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public float JumpPower = 10f; // JumpPower 증가
    private bool isJump = false;

    private float lastZPosition;    //마지막 z값

    private Magnet magnetEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        m_Animator = GetComponent<Animator>();
        transform.position = new Vector3(0, 0.5f, -9f);

        // 중력 증가
        Physics.gravity = new Vector3(0, -30f, 0);

        // 플레이어가 Magnet 컴포넌트를 가지고 있는지 확인하고 참조를 얻습니다.
        magnetEffect = GetComponent<Magnet>();
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

        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        
        // 현재 z 위치를 lastZPosition에 저장
        lastZPosition = transform.position.z;

    }

    void FixedUpdate()
    {
        // 새로운 위치 계산
        Vector3 newPosition = new Vector3(x, transform.position.y, transform.position.z + speed * Time.deltaTime);

        // 현재 z 위치를 lastZPosition에 저장
        lastZPosition = transform.position.z;

        // Rigidbody를 이용하여 새로운 위치로 이동
        rb.MovePosition(newPosition);
    }

    // 마지막 z 위치를 반환하는 메소드
    public float GetLastZPosition()
    {
        return lastZPosition;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }
    }


    // 파츠를 먹는 로직을 처리하는 메서드
    void CollectPart(GameObject part)
    {
        // 여기에 파츠를 먹었을 때의 로직을 작성
        // 예를 들면, 점수를 증가시키거나 UI를 업데이트하는 등의 작업이 포함될 수 있습니다.
        Debug.Log("Collected a part!");
    }

    // 파츠와 충돌했을 때 호출되는 메서드
    void OnTriggerEnter(Collider other)
    {
        // 충돌한 오브젝트가 파츠인지 확인
        if (other.gameObject.CompareTag("Part"))
        {
            ZombieParttest part = other.GetComponent<ZombieParttest>();
            if (part)
            {
                GameManagertest.Instance.CollectPart(part);
            }
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("MagnetItem"))
        {
            // Magnet 컴포넌트가 있으면, ActivateMagnet 메서드를 호출합니다.
            if (magnetEffect != null)
            {
                magnetEffect.ActivateMagnet();
                Debug.Log("Magnet item collected!");
            }

            Destroy(other.gameObject);
        }


        //if (other.gameObject.CompareTag("MagnetItem"))
        //{
        //    GameObject partai = GameObject.FindGameObjectWithTag("Part");
        //    PartAI aiScript = partai.GetComponent<PartAI>();
        //    if (aiScript)
        //    {
        //        aiScript.ActivateMagnet();
        //        Debug.Log("너 실행됐니?");
        //    }
        //    Debug.Log("자석 파괴 뿌쓩뿌쓩");
        //    Destroy(other.gameObject); // 자석 아이템을 파괴
        //}


    }

    
}
