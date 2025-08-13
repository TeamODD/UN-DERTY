using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
    [SerializeField] private GameObject mainCanvas;
    [SerializeField] private GameObject menuCanvas;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void StartButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LsyScene");
        Debug.Log("����ȯ�Ϸ�");
    }

    public void ReloadButton()
    {

    }

    public void ExitButton()
    {
        Debug.Log("���� ����");
        //�����ϴ� �ڵ� �ʿ�
        Application.Quit();
    }

    public void MenuButton()
    {
        menuCanvas.SetActive(true);
        Debug.Log("����â ����");
    }
}
