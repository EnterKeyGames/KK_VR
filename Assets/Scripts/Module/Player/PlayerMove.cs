using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // �ړ��X�s�[�h
    [SerializeField] float speed = 1;
    [SerializeField] Transform Camera;
    private Vector3 latestPos;  //�O���Position

    private Vector3 pos;


    //�Q�l�@https://3dcg-school.pro/unity-object-move-beginner/

    void FixedUpdate()
    {
        //       //�ړ����x�𒼐ڕύX����
        //       pos = this.transform.position;
        //       transform.position = new Vector3(pos.x + Input.GetAxis("Vertical") * speed * Time.deltaTime, 0, pos.z + Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        
        if (Camera.eulerAngles.y < 90)
        {
            //�ړ����x�𒼐ڕύX����
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
            //�ړ����x�𒼐ڕύX����
            pos = this.transform.position;
          transform.position = new Vector3(pos.x - Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, pos.z - Input.GetAxis("Vertical") * speed * Time.deltaTime);
       }
        else if (270 <= Camera.eulerAngles.y && Camera.eulerAngles.y < 360)
       {
            //           Debug.Log("<360");
            //�ړ����x�𒼐ڕύX����
            pos = this.transform.position;
          transform.position = new Vector3(pos.x - Input.GetAxis("Vertical") * speed * Time.deltaTime, 0, pos.z + Input.GetAxis("Horizontal") * speed * Time.deltaTime);
       }

        //�Q�l�@https://www.hanachiru-blog.com/entry/2019/02/20/183552
        Vector3 diff = transform.position - latestPos;   //�O�񂩂�ǂ��ɐi�񂾂����x�N�g���Ŏ擾
        latestPos = transform.position;  //�O���Position�̍X�V

        //�x�N�g���̑傫����0.01�ȏ�̎��Ɍ�����ς��鏈��������
        if (diff.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.LookRotation(diff); //������ύX����
        }
    }
}
