using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
public class ItemManager : ScriptableObject
{
    [SerializeField] Type type; // 種類
    [SerializeField] String infomation; // 情報
    [SerializeField] Sprite sprite; // 画像(追加)

    public enum Type
    {
        ConsumptionItems,
        ImportantItems,
    }

//   public Item(Item item)
//   {
//       this.type = item.type;
//       this.infomation = item.infomation;
//       this.sprite = item.sprite; // 画像(追加)
//   }
}
