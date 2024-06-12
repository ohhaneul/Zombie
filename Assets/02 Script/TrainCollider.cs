using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Player �±׸� ���� ��ü�� �浹���� ��
        if (other.CompareTag("Player"))
        {
            // ���� ���� ó��
            GameOver();

            // ����� �޽����� ���
            Debug.Log("���� �浹");
        }
    }

    void GameOver()
    {
        // ������ ������Ű�� ���� ���� ���¸� Ʈ����
        Time.timeScale = 0;

        // ���� ���� UI�� Ȱ��ȭ�ϰų� �ٸ� ���� ���� ó���� ����
        // ��: GameOverUI.SetActive(true);

        // �ʿ��� ���, �߰����� ���� ���� ó���� ���⿡ �߰�
    }
}