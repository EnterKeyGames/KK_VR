using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KKSceneManager : MonoBehaviour
{
    public static KKSceneManager singleton; //  �V�[�����܂����ł�1�������݂���悤�ɂ���

    private static readonly string _scene_MainMenu = "main_menu";
    private static readonly string _scene_game = "game";
    public enum SceneType
    {
        Menu,
        Game,
    }

    void Awake()
    {
        //�@�X�N���v�g���ݒ肳��Ă��Ȃ���΃Q�[���I�u�W�F�N�g���c���X�N���v�g��ݒ�
        if (singleton == null)
        {
            DontDestroyOnLoad(gameObject);
            singleton = this;
            //�@����GameStart�X�N���v�g������΂��̃V�[���̓����Q�[���I�u�W�F�N�g���폜
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
        //  �Ăяo���T���v��

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
            case SceneType.Menu:    //  ���C���V�[��
                {
                    SceneManager.LoadScene(_scene_MainMenu, LoadSceneMode.Single);
                }
                break;
            case SceneType.Game:    //  �Q�[���V�[��
                {
                    SceneManager.LoadScene(_scene_game, LoadSceneMode.Single);
                }
                break;
        }
    }

}
