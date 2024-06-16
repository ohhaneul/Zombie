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
    public int partsToNextType = 20; // ���� ������ �κ�
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
    private void FixedUpdate()
    {
        UpdateDistance();
        UpdateScore();
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

    public TMP_Text ProgressText;
    public TMP_Text DistanceText;
    public TMP_Text InDistanceText;

    //public Transform playerTransform;
    public void UpdateScore()
    {
        int percent = totalPartsCollected * 100 / 60;
        ProgressText.text = percent + "% ����";
        if (percent == 100)
        {
            GameObject gameover = GameObject.FindGameObjectWithTag("Player");
            GameOverPlayer overUI = gameover.GetComponent<GameOverPlayer>();
            if (overUI != null)
            {
                overUI.SetGameOverUI();
            }
        }
        //if (totalPartsCollected < partsToNextType)
        //{
        //    ProgressText.text = "0% ����";
        //}
        //else if (totalPartsCollected < partsToNextType * 2)
        //{
        //    ProgressText.text = "33% ����";
        //}
        //else if (totalPartsCollected < partsToNextType * 3)
        //{
        //    ProgressText.text = "67% ����";
        //}
        //else
        //{
        //    ProgressText.text = "100% ����";
        //}
    }

    public void UpdateDistance()
    {
       float lastZPosition = playerController.GetLastZPosition();
       int distance = Mathf.FloorToInt(lastZPosition) + 10;
       DistanceText.text = "�Ÿ� " + distance + " m";
       InDistanceText.text = "�Ÿ� " + distance + " m";
    }

}