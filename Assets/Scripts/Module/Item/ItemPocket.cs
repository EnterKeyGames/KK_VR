using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPocket : MonoBehaviour
{
    //�X�N���v�g
    [SerializeField] ItemBase itemBase;
    [SerializeField] InputAxisManager inputAxis;

    //�I�u�W�F�N�g
    [SerializeField] GameObject itemUI;
    public List<GameObject> pocketIcon;
    public List<GameObject> pocketL;

    //�ϐ�
    public int itemNum;

    [SerializeField] bool itemAbove;
    [SerializeField] bool itemRight;
    [SerializeField] bool itemLeft;
    [SerializeField] bool itemUnder;
    [SerializeField] bool itemRightAbove;
    [SerializeField] bool itemLeftAbove;
    [SerializeField] bool itemRightUnder;
    [SerializeField] bool itemLeftUnder;

    void Update()
    {
       PocketOn();

        ItemUIShow();   //UI��\������
//        ItemIconBig();  //�I�𒆂�UI��傫������ ������

        ItemUIHide();   //UI�����ׂĉB��
//        InputStickUpIconHide(); //�X�e�B�b�N�𗣂�������Icon���B��
//        OnePushTest();
    }

    void PocketOn()
    {
        PocketAbove();
        PocketRight();
        PocketLeft();
        PocketUnder();
        PocketRightAbove();
        PocketLeftAbove();
        PocketRightUnder();
        PocketLeftUnder();
    }

    // ���͂��Ƃ鏈�� 8�����ɃX�i�b�v����
    void PocketAbove()
    {
        if (inputAxis.pushUp)
        {
           if (!itemAbove)
            {
                itemAbove = true;
                itemNum = 0;
                ItemUIIconHide();
                pocketL[itemNum].SetActive(true);
                Debug.Log("�����");
            }
        }
        if (itemAbove)
        {
            if (!inputAxis.pushUp)
            {
                Debug.Log("�㗣����");
                ItemUIIconHide();
                itemAbove = false;
            }
        }
    }

    void PocketRight()
    {
        if (inputAxis.pushRight)
        {
            if(!itemRight)
            {
                itemRight = true;
                itemNum = 1;
                ItemUIIconHide();
                pocketL[itemNum].SetActive(true);
                Debug.Log("�E����");
            }
        }
        if (itemRight)
        {
            if (!inputAxis.pushRight)
            {
                Debug.Log("�E������");
                ItemUIIconHide();
                itemRight = false;
            }
        }
    }

    void PocketLeft()
    {
        if (inputAxis.pushLeft)
        {
           if (!itemLeft)
            {
                itemLeft = true;
                itemNum = 2;
                ItemUIIconHide();
                pocketL[itemNum].SetActive(true);
                Debug.Log("������");
            }
        }
        if (itemLeft)
        {
            if (!inputAxis.pushLeft)
            {
                ItemUIIconHide();
                Debug.Log("��������");
                itemLeft = false;
            }
        }
    }

    void PocketUnder()
    {
        if (inputAxis.pushDown)
        {
           if (!itemUnder)
            {
                itemUnder = true;
                itemNum = 3;
                ItemUIIconHide();
                pocketL[itemNum].SetActive(true);
                Debug.Log("������");
            }
        }
        if (itemUnder)
        {
            if (!inputAxis.pushDown)
            {
                Debug.Log("��������");
                ItemUIIconHide();
                itemUnder = false;
            }
        }
    }

    void PocketRightAbove()
    {
        if (inputAxis.pushRightUp)
        {
            if (!itemRightAbove)
            {
                itemRightAbove = true;
                itemNum = 4;
                ItemUIIconHide();
                pocketL[itemNum].SetActive(true);
                Debug.Log("�E�����");
            }
        }
        if (itemRightAbove)
        {
            if (!inputAxis.pushRightUp)
            {
                Debug.Log("�E�㗣����");
                ItemUIIconHide();
                itemRightAbove = false;
            }
        }
    }

    void PocketLeftAbove()
    {

        if (inputAxis.pushLeftUp)
        {
            if (!itemLeftAbove)
            {
                itemLeftAbove = true;
                itemNum = 5;
                ItemUIIconHide();
                pocketL[itemNum].SetActive(true);
                Debug.Log("�������");
            }
        }
        if (itemLeftAbove)
        {
            if (!inputAxis.pushLeftUp)
            {
                Debug.Log("���㗣����");
                ItemUIIconHide();
                itemLeftAbove = false;
            }
        }

    }
    void PocketRightUnder()
    {
        if (inputAxis.pushRightDown)
        {
            if (!itemRightUnder)
            {
                itemRightUnder = true;
                itemNum = 6;
                ItemUIIconHide();
                pocketL[itemNum].SetActive(true);
                Debug.Log("�E������");
            }
        }
        if (itemRightUnder)
        {
            if (!inputAxis.pushRightDown)
            {
                Debug.Log("�E��������");
                ItemUIIconHide();
                itemRightUnder = false;
            }
        }
    }
    void PocketLeftUnder()
    {
        if (inputAxis.pushLeftDown)
        {
            if (!itemLeftUnder)
            {
                itemLeftUnder = true;
                itemNum = 7;
                ItemUIIconHide();
                pocketL[itemNum].SetActive(true);
                Debug.Log("��������");
            }
        }
        if (itemLeftUnder)
        {
            if (!inputAxis.pushLeftDown)
            {
                Debug.Log("����������");
                ItemUIIconHide();
                itemLeftUnder = false;
            }
        }

    }

    //�i�i��---------------------------------------------------------------------



    //�A�C�e���I��UI���B���@�X�e�B�b�N�𗣂����Ƃ�
    void InputStickUpIconHide()
    {
        if (!inputAxis.on)
        {
//            if (!oneCall)
            {
//                oneCall = true;
                ItemUIIconHide();
            }
        }
    }

    //�A�C�e���I��UI��\������
    void ItemUIShow()
    {
        if (inputAxis.on)
        {
            itemUI.SetActive(true);
        }
    }

    void ItemUIHide()
    {
        if (!inputAxis.on)
        {
            itemUI.SetActive(false);
        }
    }

    //UI�A�C�R�������ׂĉB��
    void ItemUIIconHide()
    {
        int i = 0;

        foreach (var val in pocketL)
        {            
            pocketL[i].SetActive(false);
            i++;
        }
    }


    //�X�e�B�b�N���͂����Ă���ԁAUI�A�C�R����傫���\��
    void ItemIconBig()
    {
        //�I�u�W�F�N�g�̃T�C�Y��ύX����
        //�X�v���C�g����������
    }

    //�����Ă��������UI�A�C�R���Ƀt�`������
    void ItemIconBorder()
    {
        //�I�u�W�F�N�g�ɃA�E�g���C��������
        //�X�v���C�g����������
    }

//    void OnePushTest()
//    {
//        if (inputAxis.onePushUp)
//        {
//            Debug.Log("papa");
//        }
//
//    }
}
