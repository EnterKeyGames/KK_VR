using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField] ItemBase itembase;
    [SerializeField] ItemPocket itempocket;

    int itemNum;
    public GameObject pickObj;

    void Update()
    {
        PickUpAction();
    }

    //�R���C�_�[�ɂӂ�Ă���Ƃ��A�N�V�����{�^��
    //���������A�C�e�������X�g�ɒǉ�����@�@
    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Item")
        {
//            Debug.Log("oncollider");
            pickObj = collider.gameObject;
        }

        if (collider.gameObject.tag != "Item")
        {
            pickObj = null;
        }

        if (collider == null )
        {
            pickObj = null;
        }

        //       Debug.Log(pickObj);
        //        if (Input.GetButton("Action"))
        //        {
        //            int index = itembase.items.IndexOf(pickObj);
        //            Debug.Log(index);
        //            //�G�ꂽ�I�u�W�F�N�g���牽�Ԃ̃A�C�e���������ʂ���
        //            itempocket.pocketL[itemNum] = itembase.items[itemNum ].GetSprite();
        //        }

        //�G�ꂽ�I�u�W�F�N�g���牽�Ԃ̃A�C�e���������ʂ���
        //          for (int i = 0; i < itembase.items.Count; i++)
        //          {
        //              object obj =  itembase.items[i].ItemObjectGet();
        //              
        //          }
    }

    void PickUpAction()
    {
        if (Input.GetButtonDown("Action"))
        {
            int i = 0;
            Debug.Log("Action");

            foreach (Item item in itembase.items)
            {

                if (pickObj == null)
                {
                    Debug.Log("�k���k��");
                    break;
                }

                if (item.itemObject == pickObj)
                {
                    Debug.Log(i);
                    itempocket.pocketL.Add(itembase.items[i].itemIcon);
                    Debug.Log(itempocket.pocketL);
                    break;
                }

                i++;
            }
        }
    }
}

