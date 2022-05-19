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
    //�G�t�F�N�g��\��
    //�ǂ̃G�t�F�N�g�����肷��
    //�G�t�F�N�g���X�g
    //�I�u�W�F�N�g�ɕR�Â���
    //�C�x���g�ɔԍ�������
    void EffctShow()
    {
        gameObject.SetActive(true);
    }

    //�G�t�F�N�g���\��
    void EffctHide()
    {
        gameObject.SetActive(false);
    }

    //�G�t�F�N�g�̑傫����ύX
    void ParticleSize()
    {
        testParticle.transform.localScale = size;
    }
//
//    //�G�t�F�N�g�̐F��ύX
    void ParticleColor()
    {
        var col = testParticle.colorBySpeed;
//        col.enabled = ture;

        Gradient grad = new Gradient();
        grad.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.blue, 0.0f), new GradientColorKey(Color.red, 1.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 1.0f), new GradientAlphaKey(1.0f, 1.0f) });
        col.color = grad;
    }


    //�G�t�F�N�g�̐���ύX
    //�G�t�F�N�g�̎�ނ�ύX
    //�G�t�F�N�g�̌`��ύX
}
