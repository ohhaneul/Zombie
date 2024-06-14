using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //우리 좀비 오브젝트로 
    public GameObject legs;
    public GameObject body;
    public GameObject arms;
    public GameObject head;

    private int partsCollected = 0; // 수집한 파츠 개수

    //자석 효과
    public ParticleSystem magnetEffect; // 파티클 효과
    public float magnetRange = 2.7f;    //자석 효과 범위
    public bool isMagnetActive = false;
    // Start is called before the first frame update
    void Start()
    {
        // 시작할 때는 모든 부위가 숨겨져 있음
        legs.SetActive(false);
        body.SetActive(false);
        arms.SetActive(false);
        head.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Part"))
        {
            Destroy(other.gameObject);
            partsCollected++;

            // 파츠 수에 따라 부위를 보이게 함, 예시로 20,40,60 넣음
            if (partsCollected == 0)
            {
                legs.SetActive(true);
            }
            else if (partsCollected == 20)
            {
                body.SetActive(true);
            }
            else if (partsCollected == 40)
            {
                arms.SetActive(true);
            }
            else if (partsCollected == 60)
            {
                head.SetActive(true);
            }
        }

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
