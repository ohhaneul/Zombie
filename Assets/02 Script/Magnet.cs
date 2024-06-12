using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public ParticleSystem magnetEffect; // ��ƼŬ ȿ��
    public float magnetRange = 2.7f; // �ڼ� ȿ���� ����
    public bool isMagnetActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Magnet"))
        {
            Destroy(other.gameObject);
            isMagnetActive = true;
            magnetEffect.Play(); // ��ƼŬ ȿ�� ���
            StartCoroutine(MagnetEffect());
        }
    }

    IEnumerator MagnetEffect()
    {
        yield return new WaitForSeconds(10); // �ڼ� ȿ�� ���� �ð�
        isMagnetActive = false;
        magnetEffect.Stop(); // ��ƼŬ ȿ�� ����
    }
}
