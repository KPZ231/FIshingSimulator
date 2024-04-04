using UnityEngine;

// Deklaracja przestrzeni nazw "Fishing_Sim".
namespace Fishing_Sim
{
    // Deklaracja publicznego wyliczenia "ItemType" z r�nymi typami przedmiot�w.
    public enum ItemType
    {
        Bait,   // Przyn�ta
        Food,   // Jedzenie
        Fish    // Ryba
    }

    // Deklaracja klasy "Item" dziedzicz�cej po klasie "ScriptableObject".
    [CreateAssetMenu(fileName = "Item", menuName = "Fish/Item", order = 1)]
    public class Item : ScriptableObject
    {
        // Deklaracja publicznej zmiennej przechowuj�cej nazw� przedmiotu.
        public string itemName = string.Empty;
        // Deklaracja publicznej zmiennej przechowuj�cej wag� przedmiotu.
        public float itemWeight = 0.5f;
        // Deklaracja publicznej zmiennej przechowuj�cej typ przedmiotu.
        public ItemType itemType = ItemType.Bait;
        // Deklaracja publicznej zmiennej przechowuj�cej ilo�� przedmiotu.
        public int itemCount = 0;
        // Deklaracja publicznej zmiennej przechowuj�cej koszt przedmiotu.
        public float itemCost = 0;
        // Deklaracja publicznej zmiennej przechowuj�cej trwa�o�� przedmiotu.
        public float itemDurability = 100.0f;
    }
}
