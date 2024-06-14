using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    //public ParticleSystem magnetEffect; // 파티클 효과
    //public float magnetRange = 2.7f;    //자석 효과 범위
    //public GameObject magnetPrefab; //자석 아이템 프리팹
    //public float spawnInterval = 5f; //아이템 생성 간격 기본 5초

    public float magnetRange = 2.7f;
    public float magnetSpeed = 5f;
    public bool magnetActive = false;

    public void ActivateMagnet()
    {
        magnetActive = true;
    }

    // Start is called before the first frame update
    //void Start()
    //{
    //    InvokeRepeating("SpawnMagnet", spawnInterval, spawnInterval);
    //}

    //void SpawnMagnet()
    //{
    //    // 현재 위치에서 자석 아이템 생성
    //    Instantiate(magnetPrefab, transform.position, transform.rotation);
    //}

    // Update is called once per frame
    void Update()
    {
        if (magnetActive)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, magnetRange);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.gameObject.CompareTag("Part"))
                {
                    hitCollider.gameObject.transform.position = Vector3.Lerp(
                        hitCollider.gameObject.transform.position,
                        transform.position,
                        Time.deltaTime * magnetSpeed
                    );
                }
            }
        }
    }

   
}
