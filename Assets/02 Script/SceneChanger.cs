using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void AAStartToPlay()
    {

        SceneManager.LoadScene("Play");
        Debug.Log("����ȭ������ �Ѿ �غ� �Ϸ�");

        Time.timeScale = 1f;
    }
    public void AAStartToStart()
    {
        SceneManager.LoadScene("Start");
        Debug.Log("����ȭ������ �Ѿ �غ� �Ϸ�");

        Time.timeScale = 1f;
    }
}
