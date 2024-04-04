// Deklaracja przestrzeni nazw "Fishing_Sim" oraz importowanie biblioteki Unity - "UnityEngine".
using UnityEngine;

// Deklaracja przestrzeni nazw "Fishing_Sim".
namespace Fishing_Sim
{
    // Deklaracja publicznego wyliczenia "FishSize" z ró¿nymi rozmiarami ryb.
    public enum FishSize
    {
        Enormus,        // Olbrzymi
        Large,          // Du¿y
        Big,            // Wielki
        Medium,         // Œredni
        Small,          // Ma³y
        ReallySmall     // Naprawdê ma³y
    }


    // Deklaracja publicznego wyliczenia "FishType" z ró¿nymi typami ryb.
    public enum FishType
    {
        Thropy,         // Trofeum
        Medal,          // Medal
        VeryRare,       // Bardzo rzadki
        Rare,           // Rzadki
        Uncomon,        // Niezwyk³y (b³êdnie zapisane "Uncomon" zamiast "Uncommon")
        Common          // Powszechny
    }

    // Deklaracja klasy "Fish" dziedzicz¹cej po klasie "ScriptableObject".
    [CreateAssetMenu(fileName = "Fish", menuName = "Fish/FishTemplate", order = 1)]
    public class Fish : ScriptableObject
    {
        // Deklaracja publicznej zmiennej przechowuj¹cej nazwê ryby.
        public string fishName = string.Empty;
        // Deklaracja publicznej zmiennej przechowuj¹cej opis ryby.
        public string fishDescription = string.Empty;
        // Deklaracja publicznej zmiennej przechowuj¹cej typ ryby.
        public FishType fishType;
        // Deklaracja publicznej zmiennej przechowuj¹cej rozmiar ryby.
        public FishSize fishSize;
        // Deklaracja publicznej zmiennej przechowuj¹cej wagê ryby.
        public float fishWeight = 0.0f;
        // Deklaracja publicznej zmiennej przechowuj¹cej ikonê ryby.
        public Sprite fishIcon = null;
    }
}
