using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public enum SceneType
{
    Lobby,
    Main
}

public class SceneLoader
{
    #region Singleton
    public static SceneLoader Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new SceneLoader();
            }
            return instance;
        }
    }

    private static SceneLoader instance = null;
    #endregion

    public Action[] OnSceneChanged;
    private SceneType currentScene;
    private SceneLoader()
    {
        OnSceneChanged = new Action[Enum.GetValues(typeof(SceneType)).Length];
        for (int i = 0; i < OnSceneChanged.Length; i++)
        {
            OnSceneChanged[i] = delegate { };
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void ChangeScene(SceneType type)
    {
        currentScene = type;
        SceneManager.LoadScene((int)type);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 씬 로드 이벤트 실행
        OnSceneChanged[(int)currentScene]?.Invoke();
    }

    /// <summary>
    /// 씬 실행후 실행되는 이벤트 할당
    /// </summary>
    /// <param name="type">전환되는 씬 타입</param>
    /// <param name="action">실행시킬 메서드 할당</param>
    public void AddAction(SceneType type, Action action)
    {
        OnSceneChanged[(int)type] += action;
    }
}
