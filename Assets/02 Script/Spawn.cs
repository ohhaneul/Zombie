using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject bodyPart;
    public GameObject armPart;
    public GameObject headPart;

    public Transform leftLane;
    public Transform centerLane;
    public Transform rightLane;

    public Transform train; // ���� transform �߰�

    private ZombiePartsManager.ZombiePart lastSpawnedPart;

    private int spawnCount = 0; // ���� ���� ī��Ʈ
    private int maxSpawnCount = 5; // �ִ� ���� ���� ����
    private Transform lastSpawnPoint; // ������ ���� ����Ʈ


    public void SpawnPart()
    {
        GameObject toSpawn;

        switch (lastSpawnedPart)
        {
            case ZombiePartsManager.ZombiePart.Body:
                toSpawn = bodyPart;
                break;
            case ZombiePartsManager.ZombiePart.Arm:
                toSpawn = armPart;
                break;
            case ZombiePartsManager.ZombiePart.Head:
                toSpawn = headPart;
                break;
            default:
                toSpawn = bodyPart;
                break;
        }

        Transform spawnPoint;
        if (spawnCount < maxSpawnCount)
        {
            spawnPoint = lastSpawnPoint;
        }
        else
        {
            int lane = Random.Range(0, 4); // ���� ����Ʈ �߰��� ���� ���� ����
            switch (lane)
            {
                case 0:
                    spawnPoint = leftLane;
                    break;
                case 1:
                    spawnPoint = centerLane;
                    break;
                case 2:
                    spawnPoint = rightLane;
                    break;
                case 3:
                    spawnPoint = train; // ���� ���� ����Ʈ �߰�
                    break;
                default:
                    spawnPoint = centerLane;
                    break;
            }
            spawnCount = 0;
        }

        Instantiate(toSpawn, spawnPoint.position, spawnPoint.rotation);
        lastSpawnPoint = spawnPoint;
        spawnCount++;
    }
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
