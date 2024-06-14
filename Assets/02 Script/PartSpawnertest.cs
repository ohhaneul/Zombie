using UnityEngine;
using System.Collections;
using static GameManagertest;

public class PartSpawner : MonoBehaviour
{
    public GameObject bodyPartPrefab;
    public GameObject armPartPrefab;
    public GameObject headPartPrefab;
    public Transform[] rails;  // ���� ���ϵ��� �迭�� ����
    public float spawnDistanceBehindRail = 5f;
    public float continuousSpawnInterval = 0.5f;

    private Coroutine spawnCoroutine;

    private void Start()
    {
        spawnCoroutine = StartCoroutine(SpawnPartsContinuously());
    }

    IEnumerator SpawnPartsContinuously()
    {
        while (true)
        {
            SpawnPartBehindRandomRail();
            yield return new WaitForSeconds(continuousSpawnInterval);
        }
    }

    void SpawnPartBehindRandomRail()
    {
        if (rails.Length == 0) return;

        // �������� ������ ����
        int randomIndex = Random.Range(0, rails.Length);
        Transform selectedRail = rails[randomIndex];

        Vector3 spawnPosition = selectedRail.position - new Vector3(0, 0, spawnDistanceBehindRail);
        GameObject partPrefab = GetPartPrefab(GameManagertest.Instance.currentPartType);
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

    private void OnDestroy()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
        }
    }
}
