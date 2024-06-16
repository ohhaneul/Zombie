using UnityEngine;
using System.Collections;
using static GameManagertest;

public class PartSpawner : MonoBehaviour
{
    public GameObject bodyPartPrefab;
    public GameObject armPartPrefab;
    public GameObject headPartPrefab;
    public Vector2 rail1Position;  // ù ��° ������ x,y ��ġ
    public Vector2 rail2Position;  // �� ��° ������ x,y ��ġ
    public Vector2 rail3Position;  // �� ��° ������ x,y ��ġ

    public Transform playerTransform;   //�÷��̾��� ���鿡�� �����Ǵ� ��ġ������ ����
    public float continuousSpawnInterval = 0.5f;
    public float zPositionIncrement = 2f; // ������Ʈ ���� Z�� �Ÿ� ����
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
            // �������� ������ ����
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


            // CreateCount����ŭ ����
            for (int i = 0; i < CreateCount; i++)
            {

                Vector3 spawnPosition = new Vector3(selectedRailPos.x, selectedRailPos.y, playerTransform.position.z + Distance);

                // "Ground" �±װ� ���� ������Ʈ�� ��ġ ���� ����
                GameObject groundObject = GetGroundObjectAtPosition(spawnPosition);
                if (groundObject != null)
                {
                    spawnPosition.y = groundObject.transform.position.y + 3.5f; // Ground ���� 3.5f ���̷� ���� ����
                }

                GameObject partPrefab = GetPartPrefab(GameManagertest.Instance.currentPartType);

                Instantiate(partPrefab, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(continuousSpawnInterval);
            }
            yield return new WaitForSeconds(CreateWave);
        }
    }

    GameObject GetGroundObjectAtPosition(Vector3 position)
    {
        RaycastHit hit;
        if (Physics.Raycast(position, Vector3.up, out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("Ground"))
            {
                return hit.collider.gameObject;
            }
        }
        return null;
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