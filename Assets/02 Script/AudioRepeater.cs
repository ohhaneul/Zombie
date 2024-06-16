using UnityEngine;

public class AudioRepeater : MonoBehaviour
{
    public AudioSource audioSource; // 반복 재생할 오디오 소스
    public float repeatInterval = 5f; // 오디오 재생 간격 (5초)

    void Start()
    {
        // 5초마다 PlayAudio 메서드를 호출합니다.
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
