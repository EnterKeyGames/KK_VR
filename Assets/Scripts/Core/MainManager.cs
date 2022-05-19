using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    //Manager
    [SerializeField] private KKSceneManager kksceneManager = null;
    [SerializeField] private OVR.AudioManager ovrAudioManagaer = null;
    //    [SerializeField] private KanKikuchi.AudioManager.AudioManager<T> kAudiomanager = null;
    [SerializeField] private EffectManager effectManager = null;

    //
    [SerializeField] private UIManagerÅ@uIManager = null;
    [SerializeField] private InputManager inputManager = null;
    //    [SerializeField] private ItemManager itemManager = null;
    //    [SerializeField] private PlayerManager playerManger = null;

    //Controller
    [SerializeField] private CameraController cameraController = null;
//    [SerializeField] private MapController mapController = null;
//    [SerializeField] private GameController gameController = null;

    // Start is called before the first frame update
    void Start()
    {
        kksceneManager = new KKSceneManager();
        ovrAudioManagaer = new OVR.AudioManager();
        effectManager = new EffectManager();
        uIManager = new UIManager();
        inputManager = new InputManager();
        cameraController = new CameraController();

//        playerManger = new PlayerManager();
//        gameController = new GameController();
//        mapController = new MapController();
//        cameraController = new CameraController();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}