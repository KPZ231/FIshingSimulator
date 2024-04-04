// Deklaracja przestrzeni nazw "Fishing_Sim" oraz importowanie biblioteki Unity - "UnityEngine".
using UnityEngine;

// Deklaracja przestrzeni nazw "Fishing_Sim".
namespace Fishing_Sim
{
    // Deklaracja publicznego wyliczenia "FishSize" z r�nymi rozmiarami ryb.
    public enum FishSize
    {
        Enormus,        // Olbrzymi
        Large,          // Du�y
        Big,            // Wielki
        Medium,         // �redni
        Small,          // Ma�y
        ReallySmall     // Naprawd� ma�y
    }


    // Deklaracja publicznego wyliczenia "FishType" z r�nymi typami ryb.
    public enum FishType
    {
        Thropy,         // Trofeum
        Medal,          // Medal
        VeryRare,       // Bardzo rzadki
        Rare,           // Rzadki
        Uncomon,        // Niezwyk�y (b��dnie zapisane "Uncomon" zamiast "Uncommon")
        Common          // Powszechny
    }

    // Deklaracja klasy "Fish" dziedzicz�cej po klasie "ScriptableObject".
    [CreateAssetMenu(fileName = "Fish", menuName = "Fish/FishTemplate", order = 1)]
    public class Fish : ScriptableObject
    {
        // Deklaracja publicznej zmiennej przechowuj�cej nazw� ryby.
        public string fishName = string.Empty;
        // Deklaracja publicznej zmiennej przechowuj�cej opis ryby.
        public string fishDescription = string.Empty;
        // Deklaracja publicznej zmiennej przechowuj�cej typ ryby.
        public FishType fishType;
        // Deklaracja publicznej zmiennej przechowuj�cej rozmiar ryby.
        public FishSize fishSize;
        // Deklaracja publicznej zmiennej przechowuj�cej wag� ryby.
        public float fishWeight = 0.0f;
        // Deklaracja publicznej zmiennej przechowuj�cej ikon� ryby.
        public Sprite fishIcon = null;
    }
}
