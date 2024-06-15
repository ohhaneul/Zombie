using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public GameObject magnetItem; // �ڼ� �������� ������
    public float spawnInterval = 5f; // ������ ���� ����

    public Vector2 rail1Position;  // ù ��° ������ x,y ��ġ
    public Vector2 rail2Position;  // �� ��° ������ x,y ��ġ
    public Vector2 rail3Position;  // �� ��° ������ x,y ��ġ

    public Transform playerTransform;   //�÷��̾��� ���鿡�� �����Ǵ� ��ġ������ ����

    //public int createcount = 1;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnItem", spawnInterval, spawnInterval);
    }

    void SpawnItem()
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

        Vector3 ItemSpawnposition = new Vector3(selectedRailPos.x, selectedRailPos.y, playerTransform.position.z + 25);

        GameObject groundObject = GetGroundObjectAtPosition(ItemSpawnposition);
        if (groundObject != null)
        {
            ItemSpawnposition.y = groundObject.transform.position.y + 3.5f; // Ground ���� 3.5f ���̷� ���� ����
        }

        //// ������ ��ġ�� ������ ���� (���� ���̸� ����Ͽ� ��ġ ����)
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

