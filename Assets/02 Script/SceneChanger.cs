using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void AAStartToPlay()
    {

        SceneManager.LoadScene("Play");
        Debug.Log("게임화면으로 넘어갈 준비 완료");

        Time.timeScale = 1f;
    }
    public void AAStartToStart()
    {
        SceneManager.LoadScene("Start");
        Debug.Log("시작화면으로 넘어갈 준비 완료");

        Time.timeScale = 1f;
    }
}
