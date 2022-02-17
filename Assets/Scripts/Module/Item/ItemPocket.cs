using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPocket : MonoBehaviour
{
    //スクリプト
    [SerializeField] ItemBase itemBase;
    [SerializeField] InputAxisManager inputAxis;

    //オブジェクト
    [SerializeField] GameObject itemUI;
    public List<GameObject> pocketIcon;
    public List<GameObject> pocketL;

    //変数
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

        ItemUIShow();   //UIを表示する
//        ItemIconBig();  //選択中のUIを大きくする 未実装

        ItemUIHide();   //UIをすべて隠す
//        InputStickUpIconHide(); //スティックを離した時にIconを隠す
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

    // 入力をとる処理 8方向にスナップする
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
                Debug.Log("上入力");
            }
        }
        if (itemAbove)
        {
            if (!inputAxis.pushUp)
            {
                Debug.Log("上離した");
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
                Debug.Log("右入力");
            }
        }
        if (itemRight)
        {
            if (!inputAxis.pushRight)
            {
                Debug.Log("右離した");
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
                Debug.Log("左入力");
            }
        }
        if (itemLeft)
        {
            if (!inputAxis.pushLeft)
            {
                ItemUIIconHide();
                Debug.Log("左離した");
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
                Debug.Log("下入力");
            }
        }
        if (itemUnder)
        {
            if (!inputAxis.pushDown)
            {
                Debug.Log("下離した");
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
                Debug.Log("右上入力");
            }
        }
        if (itemRightAbove)
        {
            if (!inputAxis.pushRightUp)
            {
                Debug.Log("右上離した");
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
                Debug.Log("左上入力");
            }
        }
        if (itemLeftAbove)
        {
            if (!inputAxis.pushLeftUp)
            {
                Debug.Log("左上離した");
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
                Debug.Log("右下入力");
            }
        }
        if (itemRightUnder)
        {
            if (!inputAxis.pushRightDown)
            {
                Debug.Log("右下離した");
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
                Debug.Log("左下入力");
            }
        }
        if (itemLeftUnder)
        {
            if (!inputAxis.pushLeftDown)
            {
                Debug.Log("左下離した");
                ItemUIIconHide();
                itemLeftUnder = false;
            }
        }

    }

    //ナナメ---------------------------------------------------------------------



    //アイテム選択UIを隠す　スティックを離したとき
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

    //アイテム選択UIを表示する
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

    //UIアイコンをすべて隠す
    void ItemUIIconHide()
    {
        int i = 0;

        foreach (var val in pocketL)
        {            
            pocketL[i].SetActive(false);
            i++;
        }
    }


    //スティック入力をしている間、UIアイコンを大きく表示
    void ItemIconBig()
    {
        //オブジェクトのサイズを変更する
        //スプライトを交換する
    }

    //向いている方向のUIアイコンにフチをつける
    void ItemIconBorder()
    {
        //オブジェクトにアウトラインをつける
        //スプライトを交換する
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
