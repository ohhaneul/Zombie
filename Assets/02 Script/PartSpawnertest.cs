using UnityEngine;
using System.Collections;
using static GameManagertest;

public class PartSpawner : MonoBehaviour
{
    public GameObject bodyPartPrefab;
    public GameObject armPartPrefab;
    public GameObject headPartPrefab;
    public Vector2 rail1Position;  // 첫 번째 레일의 x,y 위치
    public Vector2 rail2Position;  // 두 번째 레일의 x,y 위치
    public Vector2 rail3Position;  // 세 번째 레일의 x,y 위치

    public Transform playerTransform;   //플레이어의 정면에서 생성되는 위치설정을 위한
    public float continuousSpawnInterval = 0.5f;
    public float zPositionIncrement = 2f; // 오브젝트 간의 Z축 거리 간격
    public int CreateCount = 5;
    public float CreateWave = 3f;
    public float Distance = 25;

    private Coroutine spawnCoroutine;

    private void Start()
    {
        if (GameManagertest.Instance == null)
        {
            return;
        }
        spawnCoroutine = StartCoroutine(SpawnPartsContinuously());
    }

    IEnumerator SpawnPartsContinuously()
    {
        while (true)
        {
            // 랜덤으로 레일을 선택
            int randomIndex = Random.Range(0, 3);
            Vector2 selectedRailPos = Vector2.zero;

            switch (randomIndex)
            {
                case 0:
                    selectedRailPos = rail1Position;
                    break;
                case 1:
                    selectedRailPos = rail2Position;
                    break;
                case 2:
                    selectedRailPos = rail3Position;
                    break;
            }
            // CreateCount수만큼 생성
            for (int i = 0; i < CreateCount; i++)
            {

                Vector3 spawnPosition = new Vector3(selectedRailPos.x, selectedRailPos.y, playerTransform.position.z + Distance);
                GameObject partPrefab = GetPartPrefab(GameManagertest.Instance.currentPartType);

                Instantiate(partPrefab, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(continuousSpawnInterval);
            }
            yield return new WaitForSeconds(CreateWave);
        }
    }

    void SpawnPartBehindRandomRail(float zPositionOffset)
    {

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