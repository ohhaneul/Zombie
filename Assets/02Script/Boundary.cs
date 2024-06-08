using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    //좌 우로 갈 수 있는 최대 영역 지정 (추후에 늘려야될듯)
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
