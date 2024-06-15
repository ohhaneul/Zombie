using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPlayer : MonoBehaviour
{
    // 게임오버 UI 받아올게요~
    [SerializeField]
    private GameObject UI;

    private void Start()
    {
        Debug.Log("준비댓어");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TrainBody"))
        {
            Debug.Log("호출댓어");
            Time.timeScale = 0;
            Debug.Log("멈첫어");
            SetGameOverUI();  //아직

            // 디버그 메시지를 출력
            Debug.Log("죽을게 뿌직");
        }
    }

    public void SetGameOverUI()
    {
        Debug.Log("호출돼써용");
        LeanTween.moveLocalY(UI, -50f, 0.5f)   //y축 좌표를 저만큼 0.5초 동안 위로 이동 
            .setDelay(0.5f)
            .setEase(LeanTweenType.easeInOutCubic)
            .setIgnoreTimeScale(true); //부드럽게
    }



}
