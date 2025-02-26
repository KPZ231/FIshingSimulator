using UnityEngine;

// Deklaracja przestrzeni nazw "Fishing_Sim".
namespace Fishing_Sim
{
    // Deklaracja publicznego wyliczenia "ItemType" z różnymi typami przedmiotów.
    public enum ItemType
    {
        Bait,   // Przynęta
        Food,   // Jedzenie
        Fish    // Ryba
    }

    // Deklaracja klasy "Item" dziedziczącej po klasie "ScriptableObject".
    [CreateAssetMenu(fileName = "Item", menuName = "Fish/Item", order = 1)]
    public class Item : ScriptableObject
    {
        // Deklaracja publicznej zmiennej przechowującej nazwę przedmiotu.
        public string itemName = string.Empty;
        // Deklaracja publicznej zmiennej przechowującej wagę przedmiotu.
        public float itemWeight = 0.5f;
        // Deklaracja publicznej zmiennej przechowującej typ przedmiotu.
        public ItemType itemType = ItemType.Bait;
        // Deklaracja publicznej zmiennej przechowującej ilość przedmiotu.
        public int itemCount = 0;
        // Deklaracja publicznej zmiennej przechowującej koszt przedmiotu.
        public float itemCost = 0;
        // Deklaracja publicznej zmiennej przechowującej trwałość przedmiotu.
        public float itemDurability = 100.0f;
    }
}
