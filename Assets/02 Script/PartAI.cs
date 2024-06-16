//using System;
//using UnityEngine;
//using UnityEngine.AI;

//public class PartAI : MonoBehaviour
//{
//    NavMeshAgent _navMeshAgent;    // 네비게이션 에이전트 
//    Transform playerTransform;     // 플레이어의 위치
//    bool isMagnetActive = false;   // 자석 아이템 활성화 여부

//    public float MagnetTime = 5f;
//    public float chaseSpeed = 10f; // 플레이어를 추격하는 속도
//    private float normalSpeed;      // 원래 속도

//    void Start()
//    {
//        _navMeshAgent = GetComponent<NavMeshAgent>();
//        if (_navMeshAgent == null)
//        {
//            Debug.LogError("NavMeshAgent 오류");
//        }

//        normalSpeed = _navMeshAgent.speed; // 원래 속도 저장
//    }

//    void Update()
//    {
//        if (isMagnetActive && playerTransform != null)
//        {
//            _navMeshAgent.SetDestination(playerTransform.position); // 플레이어를 향해 이동
//        }
//    }

//    // 자석 아이템을 먹었을 때 호출되는 메서드
//    public void ActivateMagnet()
//    {
//        isMagnetActive = true;
//        _navMeshAgent.speed = chaseSpeed; // 추격 속도 설정
//        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // 플레이어 위치 저장
//        Debug.Log("Magnet activated: AI is now chasing the player.");

//        // 자석 아이템 효과가 끝난 후에 자동으로 비활성화
//        Invoke("DeactivateMagnet", MagnetTime);
//    }

//    // 자석 아이템 효과를 비활성화하는 메서드
//    void DeactivateMagnet()
//    {
//        isMagnetActive = false;
//        _navMeshAgent.speed = normalSpeed; // 속도 초기화
//        Debug.Log("Magnet deactivated: AI stopped chasing the player.");
//    }
//}
