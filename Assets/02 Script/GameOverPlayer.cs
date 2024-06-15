using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverPlayer : MonoBehaviour
{
    // ���ӿ��� UI �޾ƿðԿ�~
    [SerializeField]
    private GameObject UI;

    private void Start()
    {
        Debug.Log("�غ���");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TrainBody"))
        {
            Debug.Log("ȣ����");
            Time.timeScale = 0;
            Debug.Log("��ù��");
            SetGameOverUI();  //����

            // ����� �޽����� ���
            Debug.Log("������ ����");
        }
    }

    public void SetGameOverUI()
    {
        Debug.Log("ȣ��Ž��");
        LeanTween.moveLocalY(UI, -50f, 0.5f)   //y�� ��ǥ�� ����ŭ 0.5�� ���� ���� �̵� 
            .setDelay(0.5f)
            .setEase(LeanTweenType.easeInOutCubic)
            .setIgnoreTimeScale(true); //�ε巴��
    }



}
