using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    //�� ��� �� �� �ִ� �ִ� ���� ���� (���Ŀ� �÷��ߵɵ�)
    public static float leftside = -2.5f;
    public static float rightside = 2.5f;
    public float internalLeft;
    public float internalRight;

    void Update()
    {
        internalLeft = leftside;
        internalRight = rightside;
    }
}
