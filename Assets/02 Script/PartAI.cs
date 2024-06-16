//using System;
//using UnityEngine;
//using UnityEngine.AI;

//public class PartAI : MonoBehaviour
//{
//    NavMeshAgent _navMeshAgent;    // �׺���̼� ������Ʈ 
//    Transform playerTransform;     // �÷��̾��� ��ġ
//    bool isMagnetActive = false;   // �ڼ� ������ Ȱ��ȭ ����

//    public float MagnetTime = 5f;
//    public float chaseSpeed = 10f; // �÷��̾ �߰��ϴ� �ӵ�
//    private float normalSpeed;      // ���� �ӵ�

//    void Start()
//    {
//        _navMeshAgent = GetComponent<NavMeshAgent>();
//        if (_navMeshAgent == null)
//        {
//            Debug.LogError("NavMeshAgent ����");
//        }

//        normalSpeed = _navMeshAgent.speed; // ���� �ӵ� ����
//    }

//    void Update()
//    {
//        if (isMagnetActive && playerTransform != null)
//        {
//            _navMeshAgent.SetDestination(playerTransform.position); // �÷��̾ ���� �̵�
//        }
//    }

//    // �ڼ� �������� �Ծ��� �� ȣ��Ǵ� �޼���
//    public void ActivateMagnet()
//    {
//        isMagnetActive = true;
//        _navMeshAgent.speed = chaseSpeed; // �߰� �ӵ� ����
//        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // �÷��̾� ��ġ ����
//        Debug.Log("Magnet activated: AI is now chasing the player.");

//        // �ڼ� ������ ȿ���� ���� �Ŀ� �ڵ����� ��Ȱ��ȭ
//        Invoke("DeactivateMagnet", MagnetTime);
//    }

//    // �ڼ� ������ ȿ���� ��Ȱ��ȭ�ϴ� �޼���
//    void DeactivateMagnet()
//    {
//        isMagnetActive = false;
//        _navMeshAgent.speed = normalSpeed; // �ӵ� �ʱ�ȭ
//        Debug.Log("Magnet deactivated: AI stopped chasing the player.");
//    }
//}
