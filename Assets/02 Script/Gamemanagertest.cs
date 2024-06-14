using UnityEngine;
using static ZombieParttest;

public class GameManagertest : MonoBehaviour
{
    public static GameManagertest Instance;

    private int totalPartsCollected = 0;
    private int currentPartCount = 0;
    public int partsToNextType = 20; // 설정 가능한 부분
    public ZombieParttest.PartType currentPartType = ZombieParttest.PartType.Body;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬 전환 시에도 인스턴스를 유지하려면 추가합니다.
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CollectPart(ZombieParttest part)
    {
        totalPartsCollected += part.scoreValue;
        currentPartCount++;

        if (currentPartCount >= partsToNextType)
        {
            currentPartCount = 0;
            ChangePartType();
        }
    }

    private void ChangePartType()
    {
        if (currentPartType == ZombieParttest.PartType.Body)
        {
            currentPartType = ZombieParttest.PartType.Arm;
        }
        else if (currentPartType == ZombieParttest.PartType.Arm)
        {
            currentPartType = ZombieParttest.PartType.Head;
        }
    }
}
