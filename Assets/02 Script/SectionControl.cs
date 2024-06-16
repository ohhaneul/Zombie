using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class SectionControl : MonoBehaviour
{
    public GameObject[] section;    // ������Ʈ �޾ƿ���
    public int zPos = 50;           // �� ����
    public bool isCreatingSection = false;     // �� ���� - �� �������� �Ǻ�
    public int secNum;              // �� ����


    void Update()
    {
        if (isCreatingSection == false) // ���� ������
        {
            isCreatingSection = true;   // ��������
            StartCoroutine(SecGen());   
        }
    }

    IEnumerator SecGen()    
    {
        secNum = Random.Range(0, 3);    // �ϴ� ��������
        GameObject newSection = Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
        // Z��ǥ�� �޾ƿͼ� �� ��ġ�� �����Ұ���
        zPos += 50; // �̰� �� ũ������ ���� (Ground)
        yield return new WaitForSeconds(5.0f);
        isCreatingSection = false;  // �ٽ� ���ֱ�

        yield return new WaitForSeconds(6.0f);  
        // �����̶� �ı� �ð��� ���� �ؾ� �޸� �� ��Ƹ�����
        Destroy(newSection);  // ������ �� �ı�

    }

}
