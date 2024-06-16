using UnityEngine;
using System.Collections;
using static GameManagertest;

public class ObstaclePartSpawner : MonoBehaviour
{
    public GameObject bodyPartPrefab;
    public GameObject armPartPrefab;
    public GameObject headPartPrefab;

    //private Transform trainTransform;


    //private void Start()
    //{
    //    trainTransform = GetComponent<Transform>();

    //    // ���� ���� �ڷ�ƾ ����
    //    StartCoroutine(SpawnParts());
    //}

    //// ������ �����ϴ� �ڷ�ƾ
    //private IEnumerator SpawnParts()
    //{
    //    while (true)
    //    {
    //        // ����(��ֹ�)�� ���� ��ġ�� ���� ����
    //        Vector3 spawnPosition = trainTransform.position + new Vector3(0, 1.0f, 0);  // ����: ���� ������ ������ ���̿� ����

    //        GameObject parts = Instantiate(partsPrefab, spawnPosition, Quaternion.identity);

    //        // ������ ����(��ֹ�)�� ���� �θ� �������� ���� (������)
    //        parts.transform.parent = trainTransform;

    //        // ���� �ð� ��� �� ���� ���� ����
    //        yield return new WaitForSeconds(Random.Range(3.0f, 7.0f));  // ����: 3�ʿ��� 7�� ������ ������ �ð� �������� ����
    //    }
    //}

    //GameObject GetPartPrefab(ZombieParttest.PartType partType)
    //{
    //    switch (partType)
    //    {
    //        case ZombieParttest.PartType.Arm:
    //            return armPartPrefab;
    //        case ZombieParttest.PartType.Head:
    //            return headPartPrefab;
    //        case ZombieParttest.PartType.Body:
    //        default:
    //            return bodyPartPrefab;
    //    }
    //}



    private void OnEnable()
    {
        SpawnPartOnObstacle();
    }

    void SpawnPartOnObstacle()
    {
        GameObject partPrefab = GetPartPrefab(GameManagertest.Instance.currentPartType);
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z); // ��ֹ� ���� ����
        Instantiate(partPrefab, spawnPosition, Quaternion.identity);
    }

    GameObject GetPartPrefab(ZombieParttest.PartType partType)
    {
        switch (partType)
        {
            case ZombieParttest.PartType.Arm:
                return armPartPrefab;
            case ZombieParttest.PartType.Head:
                return headPartPrefab;
            case ZombieParttest.PartType.Body:
            default:
                return bodyPartPrefab;
        }
    }
}
