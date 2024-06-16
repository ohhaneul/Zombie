using UnityEngine;

public class AudioRepeater : MonoBehaviour
{
    public AudioSource audioSource; // �ݺ� ����� ����� �ҽ�
    public float repeatInterval = 5f; // ����� ��� ���� (5��)

    void Start()
    {
        // 5�ʸ��� PlayAudio �޼��带 ȣ���մϴ�.
        InvokeRepeating("PlayAudio", 0f, repeatInterval);
    }

    void PlayAudio()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
