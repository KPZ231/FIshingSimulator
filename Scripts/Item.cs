using UnityEngine;

// Deklaracja przestrzeni nazw "Fishing_Sim".
namespace Fishing_Sim
{
    // Deklaracja publicznego wyliczenia "ItemType" z ró¿nymi typami przedmiotów.
    public enum ItemType
    {
        Bait,   // Przynêta
        Food,   // Jedzenie
        Fish    // Ryba
    }

    // Deklaracja klasy "Item" dziedzicz¹cej po klasie "ScriptableObject".
    [CreateAssetMenu(fileName = "Item", menuName = "Fish/Item", order = 1)]
    public class Item : ScriptableObject
    {
        // Deklaracja publicznej zmiennej przechowuj¹cej nazwê przedmiotu.
        public string itemName = string.Empty;
        // Deklaracja publicznej zmiennej przechowuj¹cej wagê przedmiotu.
        public float itemWeight = 0.5f;
        // Deklaracja publicznej zmiennej przechowuj¹cej typ przedmiotu.
        public ItemType itemType = ItemType.Bait;
        // Deklaracja publicznej zmiennej przechowuj¹cej iloœæ przedmiotu.
        public int itemCount = 0;
        // Deklaracja publicznej zmiennej przechowuj¹cej koszt przedmiotu.
        public float itemCost = 0;
        // Deklaracja publicznej zmiennej przechowuj¹cej trwa³oœæ przedmiotu.
        public float itemDurability = 100.0f;
    }
}
