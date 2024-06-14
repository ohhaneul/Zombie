using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //�츮 ���� ������Ʈ�� 
    public GameObject legs;
    public GameObject body;
    public GameObject arms;
    public GameObject head;

    private int partsCollected = 0; // ������ ���� ����

    //�ڼ� ȿ��
    public ParticleSystem magnetEffect; // ��ƼŬ ȿ��
    public float magnetRange = 2.7f;    //�ڼ� ȿ�� ����
    public bool isMagnetActive = false;
    // Start is called before the first frame update
    void Start()
    {
        // ������ ���� ��� ������ ������ ����
        legs.SetActive(false);
        body.SetActive(false);
        arms.SetActive(false);
        head.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Part"))
        {
            Destroy(other.gameObject);
            partsCollected++;

            // ���� ���� ���� ������ ���̰� ��, ���÷� 20,40,60 ����
            if (partsCollected == 0)
            {
                legs.SetActive(true);
            }
            else if (partsCollected == 20)
            {
                body.SetActive(true);
            }
            else if (partsCollected == 40)
            {
                arms.SetActive(true);
            }
            else if (partsCollected == 60)
            {
                head.SetActive(true);
            }
        }

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
