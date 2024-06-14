using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public GameObject magnetPrefab; //�ڼ� ������ ������
    public float spawnInterval = 5f; //������ ���� ���� �⺻ 5��
    //public ParticleSystem magnetEffect; // ��ƼŬ ȿ��
    //public float magnetRange = 2.7f; // �ڼ� ȿ���� ����
    //public bool isMagnetActive = false;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnMagnet", spawnInterval, spawnInterval);
    }

    void SpawnMagnet()
    {
        // ���� ��ġ���� �ڼ� ������ ����
        Instantiate(magnetPrefab, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Magnet"))
    //    {
    //        Destroy(other.gameObject);
    //        isMagnetActive = true;
    //        magnetEffect.Play(); // ��ƼŬ ȿ�� ���
    //        StartCoroutine(MagnetEffect());
    //    }
    //}

    //IEnumerator MagnetEffect()
    //{
    //    yield return new WaitForSeconds(10); // �ڼ� ȿ�� ���� �ð�
    //    isMagnetActive = false;
    //    magnetEffect.Stop(); // ��ƼŬ ȿ�� ����
    //}
}
