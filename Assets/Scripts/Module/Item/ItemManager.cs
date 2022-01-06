using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "Item", menuName = "CreateItem")]
public class ItemManager : ScriptableObject
{
    [SerializeField] Type type; // í—Ş
    [SerializeField] String infomation; // î•ñ
    [SerializeField] Sprite sprite; // ‰æ‘œ(’Ç‰Á)

    public enum Type
    {
        ConsumptionItems,
        ImportantItems,
    }

//   public Item(Item item)
//   {
//       this.type = item.type;
//       this.infomation = item.infomation;
//       this.sprite = item.sprite; // ‰æ‘œ(’Ç‰Á)
//   }
}
