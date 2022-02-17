using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAxisManager : MonoBehaviour
{
    [SerializeField] public Vector2 axisVec;

    [SerializeField] public float axisV;
    [SerializeField] public float axisH;
    [SerializeField] public float angle;

    [SerializeField] public float lastAxisV;
    [SerializeField] public float lastAxisH;

    [SerializeField] public float allV;
    [SerializeField] public float allH;
    [SerializeField] public float allAxis;

    [SerializeField] public float allLastV;
    [SerializeField] public float allLastH;
    [SerializeField] public float allLastAxis;

    [SerializeField] public bool on;

    [SerializeField] public bool pushUp;
    [SerializeField] public bool pushDown;
    [SerializeField] public bool pushRight;
    [SerializeField] public bool pushLeft;
    [SerializeField] public bool pushRightUp;
    [SerializeField] public bool pushRightDown;
    [SerializeField] public bool pushLeftUp;
    [SerializeField] public bool pushLeftDown;

    [SerializeField] public bool inclineOn;
    [SerializeField] bool notIncline;

    //一回だけ呼び出す用の変数、試作途中なのでコメDiscribeントアウト
//    [SerializeField] public bool oneCallUp;
//    [SerializeField] bool oneCallDown;
//    [SerializeField] bool oneCallRight;
//    [SerializeField] bool oneCallLeft;
//    [SerializeField] bool oneCallRightUp;
//    [SerializeField] bool oneCallLeftUp;
//    [SerializeField] bool oneCallRightDown;
//    [SerializeField] bool oneCallLeftDown;
//
//    [SerializeField] public bool onePushUp;
//    [SerializeField] public bool onePushDown;
//    [SerializeField] public bool onePushRight;
//    [SerializeField] public bool onePushLeft;
//    [SerializeField] public bool onePushRightUp;
//    [SerializeField] public bool onePushRightDown;
//    [SerializeField] public bool onePushLeftUp;
//    [SerializeField] public bool onePushLeftDown;
//
//    [SerializeField] public bool oneReleaseUp;
//    [SerializeField] public bool oneReleaseDown;
//    [SerializeField] public bool oneReleaseRight;
//    [SerializeField] public bool oneReleaseLeft;
//    [SerializeField] public bool oneReleaseRightUp;
//    [SerializeField] public bool oneReleaseRightDown;
//    [SerializeField] public bool oneReleaseLeftUp;
//    [SerializeField] public bool oneReleaseLeftDown;

    // Update is called once per frame
    void Update()
    {
        InputAxis();        //GetAxis
        AxisPushRelease();  //タテヨコナナメ８方向の入力を変数で取得
        AllAxis();          //なにかしら押しているか調べる　合計値を取得 bool float

        AxisOnOff();        //なにかしらおしているかどうかboolで返す

//        OneCall();        //GetKeyDown、GetKeyUpのように押した瞬間、離した瞬間を一度だけ取得　試作途中

        StartCoroutine(LastInputAxis());    //直前のフレームの変数を取得する
        StartCoroutine(LastInputAllAxis()); //直前のフレームの変数の合計値を取得 bool float
        LineCheck();                        //H,Vの連続入力とナナメの入力を判定して制限するためのチェック

        //syokika();                        //初期化　すべての変数を初期値にする
    }

    void InputAxis()
    {
        axisVec.x = Mathf.RoundToInt(Input.GetAxis("ItemPocketH") * 10);
        axisVec.y = Mathf.RoundToInt(Input.GetAxis("ItemPocketV") * 10);

        axisV = Mathf.RoundToInt(Input.GetAxis("ItemPocketV") * 10);
        axisH = Mathf.RoundToInt(Input.GetAxis("ItemPocketH") * 10);

        angle = Mathf.RoundToInt(Mathf.Atan2(axisVec.y, axisVec.x) * Mathf.Rad2Deg);
    }



    IEnumerator LastInputAxis()
    {
        for (int i = 0; i < 1000; i++)
        {
            yield return null;
        }

        lastAxisV = axisV;
        lastAxisH = axisH;
    }

    void AllAxis()
    {
        allV = axisV * axisV;
        allH = axisH * axisH;
        allAxis = axisV * axisV + axisH * axisH;
    }

    IEnumerator LastInputAllAxis()
    {
        for (int i = 0; i < 1000; i++)
        {
            yield return null;
        }

        allLastV = lastAxisV * lastAxisV;
        allLastH = lastAxisH * lastAxisH;
        allLastAxis = lastAxisV * lastAxisV + lastAxisH * lastAxisH;
    }

    void AxisOnOff()
    {
        //        if (allAxis > allLastAxis)
        //        {
        //            if (!on)
        //            {
        //                on = true;
        //            }
        //
        //        }
        if (pushUp || pushRight || pushLeft || pushDown || pushRightUp || pushLeftUp || pushRightDown || pushLeftDown)
        {
            if (!on) on = true;
        }

        //        if (allAxis < allLastAxis)
        //        {
        //            if (allAxis < 100)
        //            {
        //                if (on)
        //                {
        //                    on = false;
        //                }
        //            }
        //        }
        if (!pushUp && !pushRight && !pushLeft && !pushDown && !pushRightUp && !pushLeftUp && !pushRightDown && !pushLeftDown)
        {
            if (on) on = false;
        }
    }


    void AxisPushRelease()
    {
        Line();
        Incline();
    }
    
    void Line()
    {
        InclineOn();        //斜めに押しているか調べる bool
        if (!inclineOn)
        {
            AxisUp();
            AxisRight();
            AxisLeft();
            AxisDown();
        }
    }

    void Incline()
    {
        if (!notIncline)
        {
            AxisRightUp();
            AxisLeftUp();
            AxisRightDown();
            AxisLeftDown();
        }
    }

    void AxisUp()
    {
        if (axisV > 0)
        {
            if (axisV > lastAxisV || axisV == 10)
            {
                if (!pushUp)
                    pushUp = true;
            }
        }
        if (axisV >= 0)
        {
            if (axisV < lastAxisV)
            {
                if (pushUp)
                    pushUp = false;
            }
        }
    }

    void AxisRight()
    {
        if (axisH > 0)
        {
            if (axisH > lastAxisH || axisH == 10)
            {
                if (!pushRight)
                    pushRight = true;
            }
        }
        if (axisH >= 0)
        {
            if (axisH < lastAxisH)
            {
                if (pushRight)
                    pushRight = false;
            }
        }
    }

    void AxisLeft()
    {
        if (axisH < 0)
        {
            if (axisH < lastAxisH || axisH == -10)
            {
                if (!pushLeft)
                    pushLeft = true;
            }
        }
        if (axisH <= 0)
        {
            if (axisH > lastAxisH)
            {
                if (pushLeft)
                    pushLeft = false;
            }
        }
    }

    void AxisDown()
    {
        if (axisV < 0)
        {
            if (axisV < lastAxisV || axisV == -10)
            {
                if (!pushDown)
                    pushDown = true;
            }
        }
        if (axisV <= 0)
        {
            if (axisV > lastAxisV)
            {
                if (pushDown)
                    pushDown = false;
            }
        }
    }

    void AxisRightUp()
    {
        if (axisV > 0 && axisH > 0)
        {
//            if (notIncline)
//            {
                if (axisV > lastAxisV || axisH > lastAxisH)
                {
                    if (!pushRightUp)
                    {
                        pushRightUp = true;
                        pushUp = false;
                        pushRight = false;
                    }
                } 
//            }
        }
        if (axisV >= 0 && axisH >= 0)
        {
            if (axisV < lastAxisV || axisH < lastAxisH)
            {
                if (pushRightUp)
                {
                    pushRightUp = false;
                }
            }
        }
    }

    void AxisLeftUp()
    {
        if (axisV > 0 && axisH < 0)
        {
            if (axisV > lastAxisV || axisH < lastAxisH)
            {
                if (!pushLeftUp)
                {
                    pushLeftUp = true;
                    pushUp = false;
                    pushLeft = false;
                }
            }
        }
        if (axisV >= 0 && axisH <= 0)
        {
            if (axisV < lastAxisV || axisH > lastAxisH)
            {
                if (pushLeftUp)
                {
                    pushLeftUp = false;
                }
            }
        }
    }

    void AxisRightDown()
    {
        if (axisV < 0 && axisH > 0)
        {
            if (axisV < lastAxisV || axisH > lastAxisH)
            {
                if (!pushRightDown)
                {
                    pushRightDown = true;
                    pushDown = false;
                    pushRight = false;
                }
            }
        }
        if (axisV <= 0 && axisH >= 0)
        {
            if (axisV > lastAxisV || axisH < lastAxisH)
            {
                if (pushRightDown)
                {
                    pushRightDown = false;
                }
            }
        }
    }

    void AxisLeftDown()
    {
        if (axisV < 0 && axisH < 0)
        {
            if (axisV < lastAxisV || axisH < lastAxisH)
            {
                if (!pushLeftDown)
                {
                    pushLeftDown = true;
                    pushDown = false;
                    pushLeft = false;
                }
            }
        }
        if (axisV <= 0 && axisH <= 0){
            if (axisV > lastAxisV || axisH > lastAxisH){
                if (pushLeftDown)
                {
                    pushLeftDown = false;
                }
            }
        }
    }

    void InclineOn()
    {
        if (pushRightUp || pushRightDown || pushLeftUp || pushLeftDown)     inclineOn = true;
        if (!pushRightUp && !pushRightDown && !pushLeftUp && !pushLeftDown) inclineOn = false;
    }

    void LineCheck()
    {
        if (allH < allLastH || allV < allLastV) notIncline = true;

        if (allH == 0 || allV == 0) notIncline = false;

//        if (notIncline) Debug.Log("a");
    }




//    void OneCall()
//    {
//        StartCoroutine(OnePushUp());
//        StartCoroutine(OnePushRight());
//        StartCoroutine(OnePushLeft());
//        StartCoroutine(OnePushDown());
//        StartCoroutine(OnePushRightUp());
//        StartCoroutine(OnePushLeftUp());
//        StartCoroutine(OnePushRightDown());
//        StartCoroutine(OnePushLeftDown());        

//        StartCoroutine(OneReleaseUp());
//        StartCoroutine(OneReleaseRight());
//        StartCoroutine(OneReleaseLeft());
//        StartCoroutine(OneReleaseDown());
//        StartCoroutine(OneReleaseRightUp());
//        StartCoroutine(OneReleaseLeftUp());
//        StartCoroutine(OneReleaseRightDown());
//        StartCoroutine(OneReleaseLeftDown());
//    }

//    IEnumerator OnePushUp()
//    {
//        if (pushUp)
//        {
//            if (!oneCallUp)
//            {
//                onePushUp = true;
//                Debug.Log("OnePushUp");
//                Debug.Log(onePushUp);
//                yield return null;
//                oneCallUp = true;
//            }
//        }
//        onePushUp = false;
//        yield return null;
//    }

//    IEnumerator OnePushRight()
//    {
//        if (pushRight)
//        {
//            if (!oneCallRight)
//            {
//                oneCallRight = true;
//                onePushRight = true;
//                Debug.Log("OnePushRight");
//                Debug.Log(onePushRight);
//                yield return null;
//            }
//        }
//        onePushRight = false;
//    }

//    IEnumerator OneReleaseUp()
//    {
//        if (oneCallUp)
//        {
//            if (!pushUp)
//            {
//                    oneCallUp = false;
//                    oneReleaseUp = true;
//                    Debug.Log("OneCallReleaseUp");
//                    Debug.Log(oneReleaseUp);
//                yield return null;
//            }            
//        }
//        oneReleaseUp = false;
//    }

//    IEnumerator OnePushRightUp()
//    {
//        if (pushRightUp)
//        {
//            if (!oneCallRightUp)
//            {
//                oneCallRightUp = true;
//                onePushRightUp = true;
//                Debug.Log("OneCallPushRightUp");
//                Debug.Log(onePushRightUp);
//                yield return null;
//            }
//        }
//        onePushRightUp = false;
//    }

//    IEnumerator OneReleaseRightUp()
//    {
//        if (oneCallRightUp)
//        {
//            if (!pushRightUp)
//            {
//                onePushRightUp = true;
//                oneCallRightUp = false;
//                Debug.Log("OneCallReleaseRightUp");
//                Debug.Log(onePushRightUp);
//                yield return null;
//            }
//        }
//        onePushRightUp = false;
//    }

    void syokika()
    {
        axisV = 0;
        axisH = 0;

        lastAxisV = 0;
        lastAxisH = 0;

        allV = 0;
        allH = 0;
        allAxis = 0;

        allLastV = 0;
        allLastH = 0;
        allLastAxis = 0;

        on = false;

        pushUp = false;
        pushDown = false;
        pushRight = false;
        pushLeft = false;
        pushRightUp = false;
        pushRightDown = false;
        pushLeftUp = false;
        pushLeftDown = false;

        inclineOn = false;

//        oneCallUp = false;
//        oneCallDown = false;
//        oneCallRight = false;
//        oneCallLeft = false;
//        oneCallRightUp = false;
//        oneCallLeftUp = false;
//        oneCallRightDown = false;
//        oneCallLeftDown = false;
//
//        onePushUp = false;
//        onePushDown = false;
//        onePushRight = false;
//        onePushLeft = false;
//        onePushRightUp = false;
//        onePushRightDown = false;
//        onePushLeftUp = false;
//        onePushLeftDown = false;
//
//        oneReleaseUp = false;
//        oneReleaseDown = false;
//        oneReleaseRight = false;
//        oneReleaseLeft = false;
//        oneReleaseRightUp = false;
//        oneReleaseRightDown = false;
//        oneReleaseLeftUp = false;
//        oneReleaseLeftDown = false;
    }
}