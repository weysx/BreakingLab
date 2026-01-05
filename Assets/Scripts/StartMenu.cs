using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    [Header("UI References")]
    public Button startButton;  // 开始游戏按钮
    
    [Header("Scene Settings")]
    public string gameSceneName = "SampleScene";
    
    void Start()
    {
        
        if (startButton == null)
        {
            GameObject startBtnObj = GameObject.Find("StartButton");
            if (startBtnObj != null)
            {
                startButton = startBtnObj.GetComponent<Button>();
            }
        }
        
        // 绑定按钮事件
        if (startButton != null)
        {
            startButton.onClick.AddListener(StartGame);
        }
    }
    
    public void StartGame()
    {
        // 加载游戏场景
        SceneManager.LoadScene(gameSceneName);
    }
    
    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            // 在构建版本中退出应用
            Application.Quit();
        #endif
    }
    
    void OnDestroy()
    {
        if (startButton != null)
        {
            startButton.onClick.RemoveListener(StartGame);
        }
    }
}