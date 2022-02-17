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
        //プレイヤーが選択しているアイテムがこのアイテムであるか調べる（オブジェクトがオンになっている時点でそうなっているはずなので必要ない？
        //オンオフ
        //当たり判定に触れたとき

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

 