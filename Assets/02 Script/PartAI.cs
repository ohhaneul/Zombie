using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PartAI : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;    // �׺���̼� ������Ʈ 
    Transform objectToChase;              // �߰��� ��ġ

    public void Start()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        if (_navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent ����");
        }
    }

    public void Update()
    {
        objectToChase = GameObject.FindGameObjectWithTag("Player").transform;   // �÷��̾� ��ġ��
        _navMeshAgent.SetDestination(objectToChase.position);   // �÷��̾ ���� �̵�
    }
}
