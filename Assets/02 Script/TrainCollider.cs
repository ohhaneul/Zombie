using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Player 태그를 가진 객체와 충돌했을 때
        if (other.CompareTag("Player"))
        {
            // 게임 오버 처리
            GameOver();

            // 디버그 메시지를 출력
            Debug.Log("기차 충돌");
        }
    }

    void GameOver()
    {
        // 게임을 정지시키고 게임 오버 상태를 트리거
        Time.timeScale = 0;

        // 게임 오버 UI를 활성화하거나 다른 게임 오버 처리를 수행
        // 예: GameOverUI.SetActive(true);

        // 필요한 경우, 추가적인 게임 오버 처리를 여기에 추가
    }
}