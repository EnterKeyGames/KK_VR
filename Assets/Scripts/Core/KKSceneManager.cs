using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KKSceneManager : MonoBehaviour
{
    public static KKSceneManager singleton; //  シーンをまたいでも1つだけ存在するようにする

    private static readonly string _scene_MainMenu = "main_menu";
    private static readonly string _scene_game = "game";
    public enum SceneType
    {
        Menu,
        Game,
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
            SceneChange(SceneType.Game);
        }
    }

    public void SceneChange(SceneType type)
    {
        switch (type)
        {
            case SceneType.Menu:    //  メインシーン
                {
                    SceneManager.LoadScene(_scene_MainMenu, LoadSceneMode.Single);
                }
                break;
            case SceneType.Game:    //  ゲームシーン
                {
                    SceneManager.LoadScene(_scene_game, LoadSceneMode.Single);
                }
                break;
        }
    }

}
