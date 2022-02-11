using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 移動スピード
    [SerializeField] float speed = 1;
    [SerializeField] Transform Camera;
    private Vector3 latestPos;  //前回のPosition

    private Vector3 pos;


    //参考　https://3dcg-school.pro/unity-object-move-beginner/

    void FixedUpdate()
    {
        //       //移動速度を直接変更する
        //       pos = this.transform.position;
        //       transform.position = new Vector3(pos.x + Input.GetAxis("Vertical") * speed * Time.deltaTime, 0, pos.z + Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        
        if (Camera.eulerAngles.y < 90)
        {
            //移動速度を直接変更する
//        Debug.Log("<90");
            pos = this.transform.position;
            transform.position = new Vector3(pos.x + Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, pos.z + Input.GetAxis("Vertical") * speed * Time.deltaTime);
        }
        else if (90 <= Camera.eulerAngles.y && Camera.eulerAngles.y < 180)
       {
            //            Debug.Log("<180");
            pos = this.transform.position;
          transform.position = new Vector3(pos.x + Input.GetAxis("Vertical") * speed * Time.deltaTime, 0, pos.z - Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        }
        else if (180 <= Camera.eulerAngles.y && Camera.eulerAngles.y < 270)
       {
            //            Debug.Log("<270");
            //移動速度を直接変更する
            pos = this.transform.position;
          transform.position = new Vector3(pos.x - Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, pos.z - Input.GetAxis("Vertical") * speed * Time.deltaTime);
       }
        else if (270 <= Camera.eulerAngles.y && Camera.eulerAngles.y < 360)
       {
            //           Debug.Log("<360");
            //移動速度を直接変更する
            pos = this.transform.position;
          transform.position = new Vector3(pos.x - Input.GetAxis("Vertical") * speed * Time.deltaTime, 0, pos.z + Input.GetAxis("Horizontal") * speed * Time.deltaTime);
       }

        //参考　https://www.hanachiru-blog.com/entry/2019/02/20/183552
        Vector3 diff = transform.position - latestPos;   //前回からどこに進んだかをベクトルで取得
        latestPos = transform.position;  //前回のPositionの更新

        //ベクトルの大きさが0.01以上の時に向きを変える処理をする
        if (diff.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(diff); //向きを変更する
        }
    }
}
