using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsScript : MonoBehaviour
{
    public Transform player;    //player ��ġ
    public PlayerScript playerScript;   //player ��ũ��Ʈ
    public float speed = 5f;    //������ �÷��̾�� �̵��ϴ� �ӵ�
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�ڼ� ȿ�� Ȱ��ȭ�� ���¿��� ������ �÷��̾�� �̵��ϵ���
        if (playerScript.isMagnetActive && Vector3.Distance(transform.position, player.position) <= playerScript.magnetRange)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.position, step);
        }

    }
}
