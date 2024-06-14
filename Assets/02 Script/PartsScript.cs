using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsScript : MonoBehaviour
{
    public Transform player;    //player 위치
    public PlayerScript playerScript;   //player 스크립트
    public float speed = 5f;    //파츠가 플레이어에게 이동하는 속도
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //자석 효과 활성화된 상태에서 파츠가 플레이어에게 이동하도록
        if (playerScript.isMagnetActive && Vector3.Distance(transform.position, player.position) <= playerScript.magnetRange)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.position, step);
        }

    }
}
