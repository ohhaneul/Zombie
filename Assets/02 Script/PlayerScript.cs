using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
   
    //자석 효과
    public ParticleSystem magnetEffect; // 파티클 효과
    public float magnetRange = 2.7f;    //자석 효과 범위
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
            Destroy(other.gameObject); // 아이템 제거
            isMagnetActive = true; // 자석 효과 활성화
            magnetEffect.Play(); // 파티클 효과 재생
            StartCoroutine(MagnetEffectDuration(10f)); // 10초 동안 자석 효과 유지
        }
    }
    IEnumerator MagnetEffectDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        isMagnetActive = false; // 자석 효과 비활성화
        magnetEffect.Stop(); // 파티클 효과 중지
    }
}
