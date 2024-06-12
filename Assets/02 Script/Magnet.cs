using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public ParticleSystem magnetEffect; // 파티클 효과
    public float magnetRange = 2.7f; // 자석 효과의 범위
    public bool isMagnetActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Magnet"))
        {
            Destroy(other.gameObject);
            isMagnetActive = true;
            magnetEffect.Play(); // 파티클 효과 재생
            StartCoroutine(MagnetEffect());
        }
    }

    IEnumerator MagnetEffect()
    {
        yield return new WaitForSeconds(10); // 자석 효과 지속 시간
        isMagnetActive = false;
        magnetEffect.Stop(); // 파티클 효과 중지
    }
}
