using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
   
    //�ڼ� ȿ��
    public ParticleSystem magnetEffect; // ��ƼŬ ȿ��
    public float magnetRange = 2.7f;    //�ڼ� ȿ�� ����
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
            Destroy(other.gameObject); // ������ ����
            isMagnetActive = true; // �ڼ� ȿ�� Ȱ��ȭ
            magnetEffect.Play(); // ��ƼŬ ȿ�� ���
            StartCoroutine(MagnetEffectDuration(10f)); // 10�� ���� �ڼ� ȿ�� ����
        }
    }
    IEnumerator MagnetEffectDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        isMagnetActive = false; // �ڼ� ȿ�� ��Ȱ��ȭ
        magnetEffect.Stop(); // ��ƼŬ ȿ�� ����
    }
}
