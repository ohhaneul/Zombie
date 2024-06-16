using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PartAI : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;    // 네비게이션 에이전트 
    Transform objectToChase;              // 추격할 위치

    public void Start()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        if (_navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent 오류");
        }
    }

    public void Update()
    {
        objectToChase = GameObject.FindGameObjectWithTag("Player").transform;   // 플레이어 위치로
        _navMeshAgent.SetDestination(objectToChase.position);   // 플레이어를 향해 이동
    }
}
