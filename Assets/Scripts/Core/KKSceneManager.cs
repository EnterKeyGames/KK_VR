using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KKSceneManager : MonoBehaviour
{
    public static KKSceneManager singleton; //  シーンをまたいでも1つだけ存在するようにする

    private static readonly string _scene_Menu = "Menu";
    private static readonly string _scene_Main = "Main";
    public enum SceneType
    {
        Menu,
        Main,
    }

    void Awake()
    {
        //　スクリプトが設定されていなければゲームオブジェクトを残しつつスクリプトを設定
        if (singleton == null)
        {
            DontDestroyOnLoad(gameObject);
            singleton = this;
            //　既にGameStartスクリプトがあればこのシーンの同じゲームオブジェクトを削除
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

    }

    void Update()
    {
        //  呼び出しサンプル

        if (Input.GetKeyDown(KeyCode.M))
        {
            SceneChange(SceneType.Menu);
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            SceneChange(SceneType.Main);
        }
    }

    public void SceneChange(SceneType type)
    {
        switch (type)
        {
            case SceneType.Menu:    //  メインシーン
                {
                    SceneManager.LoadScene(_scene_Menu, LoadSceneMode.Single);
                }
                break;
            case SceneType.Main:    //  ゲームシーン
                {
                    SceneManager.LoadScene(_scene_Main, LoadSceneMode.Single);
                }
                break;
        }
    }

    public void GameSceneChangeButton()
    {
        SceneChange(SceneType.Main);

    }

    public void MenuSceneChangeButton()
    {
        SceneChange(SceneType.Menu);
    }


}
