using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionControl : MonoBehaviour
{
    public GameObject[] section;    // 오브젝트 받아오기
    public int zPos = 50;           // 땅 길이
    public bool isCreatingSection = false;     // 땅 생성 - 참 거짓으로 판별
    public int secNum;              // 땅 지정


    void Update()
    {
        if (isCreatingSection == false) // 땅이 없으면
        {
            isCreatingSection = true;   // 만들어야지
            StartCoroutine(SecGen());   
        }
    }

    IEnumerator SecGen()    
    {
        secNum = Random.Range(0, 3);    // 일단 이정도만
        GameObject newSection = Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
        // Z좌표를 받아와서 그 위치에 생성할거임
        zPos += 50; // 이게 땅 크기이자 간격 (Ground)
        yield return new WaitForSeconds(5);
        isCreatingSection = false;  // 다시 꺼주기

        yield return new WaitForSeconds(5);  
        // 생성이랑 파괴 시간을 같이 해야 메모리 덜 잡아먹을듯
        Destroy(newSection);  // 생성된 땅 파괴

    }
}
