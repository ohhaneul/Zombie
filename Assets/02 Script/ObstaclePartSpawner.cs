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

    //    // 파츠 스폰 코루틴 시작
    //    StartCoroutine(SpawnParts());
    //}

    //// 파츠를 스폰하는 코루틴
    //private IEnumerator SpawnParts()
    //{
    //    while (true)
    //    {
    //        // 기차(장애물)의 일정 위치에 파츠 생성
    //        Vector3 spawnPosition = trainTransform.position + new Vector3(0, 1.0f, 0);  // 예시: 기차 위에서 적절한 높이에 생성

    //        GameObject parts = Instantiate(partsPrefab, spawnPosition, Quaternion.identity);

    //        // 파츠가 기차(장애물)과 같은 부모를 가지도록 설정 (선택적)
    //        parts.transform.parent = trainTransform;

    //        // 일정 시간 대기 후 다음 파츠 생성
    //        yield return new WaitForSeconds(Random.Range(3.0f, 7.0f));  // 예시: 3초에서 7초 사이의 랜덤한 시간 간격으로 생성
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
