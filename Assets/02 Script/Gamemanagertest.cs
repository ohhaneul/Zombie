using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using static ZombieParttest;
using Unity.VisualScripting;

public class GameManagertest : MonoBehaviour
{
    public static GameManagertest Instance;

    private int totalPartsCollected = 0;
    private int currentPartCount = 0;
    public int partsToNextType = 20; // ¼³Á¤ °¡´ÉÇÑ ºÎºÐ
    public ZombieParttest.PartType currentPartType = ZombieParttest.PartType.Body;

    private GameObject player;
    private PlayerController playerController;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerController = player.GetComponent<PlayerController>();
        }

        UpdateScore();
        UpdateDistance();
    }
    private void Update()
    {
        UpdateDistance();
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

        UpdateScore();
    }

    public TMP_Text ProgressText;
    public TMP_Text DistanceText;

    //public Transform playerTransform;
    public void UpdateScore()
    {

        if (totalPartsCollected < partsToNextType)
        {
            ProgressText.text = "ÁøÇà·ü 0%";
        }
        else if (totalPartsCollected < partsToNextType * 2)
        {
            ProgressText.text = "ÁøÇà·ü 33%";
        }
        else if (totalPartsCollected < partsToNextType * 3)
        {
            ProgressText.text = "ÁøÇà·ü 67%";
        }
        else
        {
            ProgressText.text = "ÁøÇà·ü 100%";
        }
    }

    public void UpdateDistance()
    {
       float lastZPosition = playerController.GetLastZPosition();
       int distance = Mathf.FloorToInt(lastZPosition);
       DistanceText.text = "°Å¸®" + distance + "m";
        
    }

}