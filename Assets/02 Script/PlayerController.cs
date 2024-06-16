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
    public float SpeedDodge = 5f; // SpeedDodge �ʱ�ȭ
    public float speed = 10f;
    public float JumpPower = 10f; // JumpPower ����
    private bool isJump = false;

    private float lastZPosition;    //������ z��

    private Magnet magnetEffect;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        m_Animator = GetComponent<Animator>();
        transform.position = new Vector3(0, 0.5f, -9f);

        // �߷� ����
        Physics.gravity = new Vector3(0, -30f, 0);

        // �÷��̾ Magnet ������Ʈ�� ������ �ִ��� Ȯ���ϰ� ������ ����ϴ�.
        magnetEffect = GetComponent<Magnet>();
    }


    void Update()
    {
        SwipeUp = Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W);
        SwipeLeft = Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A); // ���� �̵��� ����Ű�� AŰ
        SwipeRight = Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D); // ������ �̵��� ����Ű�� DŰ

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
        
        // ���� z ��ġ�� lastZPosition�� ����
        lastZPosition = transform.position.z;

    }

    void FixedUpdate()
    {
        // ���ο� ��ġ ���
        Vector3 newPosition = new Vector3(x, transform.position.y, transform.position.z + speed * Time.deltaTime);

        // ���� z ��ġ�� lastZPosition�� ����
        lastZPosition = transform.position.z;

        // Rigidbody�� �̿��Ͽ� ���ο� ��ġ�� �̵�
        rb.MovePosition(newPosition);
    }

    // ������ z ��ġ�� ��ȯ�ϴ� �޼ҵ�
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


    // ������ �Դ� ������ ó���ϴ� �޼���
    void CollectPart(GameObject part)
    {
        // ���⿡ ������ �Ծ��� ���� ������ �ۼ�
        // ���� ���, ������ ������Ű�ų� UI�� ������Ʈ�ϴ� ���� �۾��� ���Ե� �� �ֽ��ϴ�.
        Debug.Log("Collected a part!");
    }

    // ������ �浹���� �� ȣ��Ǵ� �޼���
    void OnTriggerEnter(Collider other)
    {
        // �浹�� ������Ʈ�� �������� Ȯ��
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
            // Magnet ������Ʈ�� ������, ActivateMagnet �޼��带 ȣ���մϴ�.
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
        //        Debug.Log("�� ����ƴ�?");
        //    }
        //    Debug.Log("�ڼ� �ı� �Ѿ��Ѿ�");
        //    Destroy(other.gameObject); // �ڼ� �������� �ı�
        //}


    }

    
}
