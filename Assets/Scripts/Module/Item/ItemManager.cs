using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
public class ItemManager : ScriptableObject
{
    [SerializeField] Type type; // ���
    [SerializeField] String infomation; // ���
    [SerializeField] Sprite sprite; // �摜(�ǉ�)

    public enum Type
    {
        ConsumptionItems,
        ImportantItems,
    }

//   public Item(Item item)
//   {
//       this.type = item.type;
//       this.infomation = item.infomation;
//       this.sprite = item.sprite; // �摜(�ǉ�)
//   }
}
