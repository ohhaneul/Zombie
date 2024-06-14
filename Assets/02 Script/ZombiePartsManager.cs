using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiePartsManager : MonoBehaviour
{
    public enum ZombiePart
    {
        Body,
        Arm,
        Head
    }

    public int partsToChange = 20;   // �÷��̾ �Ծ�� �� ���� ��Ʈ ����
    private int currentParts = 0;    // ���� ���� ���� ��Ʈ ����
    public ZombiePart currentZombiePart = ZombiePart.Body;  // ���� ���� ��Ʈ

    public void CollectPart()
    {
        currentParts++;
        if (currentParts >= partsToChange)
        {
            ChangePart();
            currentParts = 0;
        }
    }

    private void ChangePart()
    {
        if (currentZombiePart == ZombiePart.Body)
        {
            currentZombiePart = ZombiePart.Arm;
        }
        else if (currentZombiePart == ZombiePart.Arm)
        {
            currentZombiePart = ZombiePart.Head;
        }
    }

    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
}
