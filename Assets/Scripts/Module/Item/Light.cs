using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    [SerializeField] ItemPocket itempocket;
    [SerializeField] GameObject lightobj;
    [SerializeField] ItemPickUp itempick;

    [SerializeField] bool isLight;

    // Update is called once per frame
    void Update()
    {
        //�v���C���[���I�����Ă���A�C�e�������̃A�C�e���ł��邩���ׂ�i�I�u�W�F�N�g���I���ɂȂ��Ă��鎞�_�ł����Ȃ��Ă���͂��Ȃ̂ŕK�v�Ȃ��H
        //�I���I�t
        //�����蔻��ɐG�ꂽ�Ƃ�

        LightChange();
    }


    void LightChange()
    {
        if (Input.GetButtonDown("Action"))  isLight = !isLight;
         
        if (!itempick.isPick)
        {
            if (isLight) lightobj.SetActive(true);
            if (!isLight) lightobj.SetActive(false);
        }
    }
}

 