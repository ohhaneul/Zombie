using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public GameObject magnetItem; // 자석 아이템의 프리팹
    public float spawnInterval = 5f; // 아이템 생성 간격

    public Vector2 rail1Position;  // 첫 번째 레일의 x,y 위치
    public Vector2 rail2Position;  // 두 번째 레일의 x,y 위치
    public Vector2 rail3Position;  // 세 번째 레일의 x,y 위치

    public Transform playerTransform;   //플레이어의 정면에서 생성되는 위치설정을 위한

    //public int createcount = 1;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnItem", spawnInterval, spawnInterval);
    }

    void SpawnItem()
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

        Vector3 ItemSpawnposition = new Vector3(selectedRailPos.x, selectedRailPos.y, playerTransform.position.z + 25);

        GameObject groundObject = GetGroundObjectAtPosition(ItemSpawnposition);
        if (groundObject != null)
        {
            ItemSpawnposition.y = groundObject.transform.position.y + 3.5f; // Ground 위에 3.5f 높이로 파츠 생성
        }

        //// 랜덤한 위치에 아이템 생성 (길의 넓이를 고려하여 위치 설정)
        //float randomX = Random.Range(-2.5f, 2.5f);

        Instantiate(magnetItem, ItemSpawnposition, Quaternion.identity);
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

}

