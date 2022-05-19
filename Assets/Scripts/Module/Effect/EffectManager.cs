using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public ParticleSystem testParticle;

    Vector3 size = new Vector3(10.0f, 10.0f, 10.0f);

    Gradient grad = new Gradient();


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            ParticleSize();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            ParticleColor();
        }
    }
    //エフェクトを表示
    //どのエフェクトか特定する
    //エフェクトリスト
    //オブジェクトに紐づける
    //イベントに番号をつける
    void EffctShow()
    {
        gameObject.SetActive(true);
    }

    //エフェクトを非表示
    void EffctHide()
    {
        gameObject.SetActive(false);
    }

    //エフェクトの大きさを変更
    void ParticleSize()
    {
        testParticle.transform.localScale = size;
    }
//
//    //エフェクトの色を変更
    void ParticleColor()
    {
        var col = testParticle.colorBySpeed;
//        col.enabled = ture;

        Gradient grad = new Gradient();
        grad.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.blue, 0.0f), new GradientColorKey(Color.red, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 1.0f), new GradientAlphaKey(1.0f, 1.0f) });
        col.color = grad;
    }


    //エフェクトの数を変更
    //エフェクトの種類を変更
    //エフェクトの形を変更
}
