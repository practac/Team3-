using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMain : MonoBehaviour
{
    public void GoToMainScene()
    {
        SceneManager.LoadScene("MainScene"); // "MainScene"을 Main 씬의 정확한 이름으로 설정
    }
}
