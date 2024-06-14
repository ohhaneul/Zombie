using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip Scream;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Invoke("HeadLater", 4f); //���� n�� �� ���¢��
    }

    // Update is called once per frame

    public void HeadLater()
    {
        audioSource.PlayOneShot(Scream);
    }
}
