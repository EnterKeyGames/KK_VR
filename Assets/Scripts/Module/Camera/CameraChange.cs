using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    [SerializeField] Transform gameCamera;
    [SerializeField] List<Transform> cameraPosiList;


    private int nowCameraPosiL;

    private Vector3 CameraPosiVec;

    // Update is called once per frame
    void Update()
    {
        CameraPosiVec = new Vector3();

       if (Input.GetKeyDown(KeyCode.Q))
       {

            CameraPosiVec = cameraPosiList[nowCameraPosiL].position;

            gameCamera.position = CameraPosiVec;
      

            nowCameraPosiL++;
           Debug.Log("cameraPosiList");

       if(nowCameraPosiL == cameraPosiList.Count)
           {
                nowCameraPosiL = 0;
               Debug.Log("roop");
           }
       }



    }
}
