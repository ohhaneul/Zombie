using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    //�� ��� �� �� �ִ� �ִ� ���� ���� (���Ŀ� �÷��ߵɵ�)
    public static float leftside = -1.5f;
    public static float rightside = 1.5f;
    public float internalLeft;
    public float internalRight;

    void Update()
    {
        internalLeft = leftside;
        internalRight = rightside;
    }
}
