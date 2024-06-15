using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    //public ParticleSystem magnetEffect; // ��ƼŬ ȿ��
    //public float magnetRange = 2.7f;    //�ڼ� ȿ�� ����
    //public GameObject magnetPrefab; //�ڼ� ������ ������
    //public float spawnInterval = 5f; //������ ���� ���� �⺻ 5��

    public float magnetRange = 2.7f;
    public float magnetSpeed = 5f;
    public bool magnetActive = false;

    public void ActivateMagnet()
    {
        magnetActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (magnetActive)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, magnetRange);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.CompareTag("Part"))
                {
                    hitCollider.gameObject.transform.position = Vector3.Lerp(
                        hitCollider.gameObject.transform.position,
                        transform.position,
                        Time.deltaTime * magnetSpeed
                    );
                }
            }
        }
    }

   
}
