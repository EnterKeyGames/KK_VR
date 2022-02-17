using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField] ItemBase itembase;
    [SerializeField] ItemPocket itempocket;
    public bool isPick;

    int itemNum;
    public GameObject pickObj;

    void Update()
    {
        PickUpAction();
    }

    //コライダーにふれているときアクションボタン
    //発見したアイテムをリストに追加する　　
    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Item")
        {
            pickObj = collider.gameObject;
            isPick = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Item")
        {
            pickObj = null;
            isPick = false;
        }
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
                    Debug.Log("ヌルヌル");
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

    void pickObjCheck()
    {
        //はじめて追加される場合
    }

    void PickObjAdd()
    {

    }
}

