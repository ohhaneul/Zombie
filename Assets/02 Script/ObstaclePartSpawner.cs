using UnityEngine;
using static GameManagertest;

public class ObstaclePartSpawner : MonoBehaviour
{
    public GameObject bodyPartPrefab;
    public GameObject armPartPrefab;
    public GameObject headPartPrefab;

    private void OnEnable()
    {
        SpawnPartOnObstacle();
    }

    void SpawnPartOnObstacle()
    {
        GameObject partPrefab = GetPartPrefab(GameManagertest.Instance.currentPartType);
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z); // 장애물 위로 스폰
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
