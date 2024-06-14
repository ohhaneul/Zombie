using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public GameObject magnetItem; // 자석 아이템의 프리팹
    public float spawnInterval = 5f; // 아이템 생성 간격

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnItem", spawnInterval, spawnInterval);
    }

    void SpawnItem()
    {
        // 랜덤한 위치에 아이템 생성 (길의 넓이를 고려하여 위치 설정)
        float randomX = Random.Range(-1.25f, 1.25f);
        Instantiate(magnetItem, new Vector3(randomX, transform.position.y, transform.position.z), Quaternion.identity);
    }
    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
