using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public GameObject magnetItem; // �ڼ� �������� ������
    public float spawnInterval = 5f; // ������ ���� ����

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnItem", spawnInterval, spawnInterval);
    }

    void SpawnItem()
    {
        // ������ ��ġ�� ������ ���� (���� ���̸� ����Ͽ� ��ġ ����)
        float randomX = Random.Range(-1.25f, 1.25f);
        Instantiate(magnetItem, new Vector3(randomX, transform.position.y, transform.position.z), Quaternion.identity);
    }
    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
