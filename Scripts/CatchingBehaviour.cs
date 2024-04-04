using UnityEngine;
using UnityEngine.UI;

// Deklaracja przestrzeni nazw "Fishing_Sim".
namespace Fishing_Sim
{
    // Deklaracja klasy "CatchingBehaviour" dziedzicz�cej po klasie "MonoBehaviour".
    public class CatchingBehaviour : MonoBehaviour
    {
        // Deklaracja statycznej w�a�ciwo�ci "instance" typu "CatchingBehaviour" - Singleton.
        public static CatchingBehaviour instance { get; private set; }

        // Deklaracja tablicy przechowuj�cej obiekty typu "Fish".
        [Header("Fish")]
        public Fish[] _fish = { };
        // Deklaracja zmiennej przechowuj�cej czas do ataku.
        public float _timeToAttack = 1f;
        [HideInInspector] private int timesToClick = 0;
        private int randomFishIndex = 0;

        // Metoda wywo�ywana przy starcie obiektu.
        private void Start()
        {
            instance = this; // Inicjalizacja Singletona.
            Reel(); // Rozpocz�cie nawijania �y�ki.
        }

        // Zmienna kontroluj�ca, czy ryba zosta�a sprawdzona.
        private bool isChecked = false;
        [HideInInspector] public bool canReel = false;

        // Metoda wywo�ywana przy ataku ryby.
        public void Bite()
        {
            if (!isChecked) // Je�li ryba nie zosta�a jeszcze sprawdzona.
            {
                _timeToAttack = Random.Range(0f, 25f); // Losowanie czasu do ataku.
                isChecked = true; // Ustawienie flagi sprawdzenia na true.
                timesToClick = Random.Range(0, 50); // Wylosowanie liczby klikni��.
                Player.instance.PlayAnim(); // Odtworzenie animacji gracza.
                randomFishIndex = Random.Range(0, _fish.Length); // Wylosowanie indeksu ryby z tablicy.
                AnalizeTimeToClick(_fish[randomFishIndex]); // Analiza liczby klikni�� do nawini�cia �y�ki.
            }
        }

        // Metoda wywo�ywana co klatk�.
        private void Update()
        {
            if (isChecked == true) // Je�li ryba zosta�a sprawdzona.
            {
                _timeToAttack -= Time.deltaTime; // Odliczanie czasu do ataku.
                if (_timeToAttack < 0f) // Je�li czas do ataku up�yn��.
                {
                    isChecked = false; // Resetowanie flagi sprawdzenia.
                    canReel = true; // Ustawienie mo�liwo�ci nawijania �y�ki na true.
                    Player.instance.PlayAnim(); // Odtworzenie animacji gracza.
                    Reel(); // Rozpocz�cie nawijania �y�ki.
                }
            }
        }

        // Metoda analizuj�ca parametry ryby.
        public void AnalizeFish(Fish fish)
        {
            fish.fishType = FishType.Common; // Ustawienie typu ryby na "Common".

            if (fish != null) // Je�li ryba istnieje.
            {
                if (fish.fishWeight < 0) // Je�li waga ryby jest mniejsza od 0.
                {
                    fish.fishWeight = Random.Range(0f, 1f); // Losowanie wagi ryby.
                    Debug.LogAssertion("Ryba Ma Wage Poni�ej 0"); // Wy�wietlenie ostrze�enia w konsoli.
                }
                else if (fish.fishWeight >= 0.1f && fish.fishWeight < 1.5f) // Je�li waga ryby mie�ci si� w przedziale.
                {
                    fish.fishSize = FishSize.ReallySmall; // Ustawienie rozmiaru ryby na "ReallySmall".
                }
                else if (fish.fishWeight >= 1.5f && fish.fishWeight < 3f)
                {
                    fish.fishSize = FishSize.Small;
                }
                else if (fish.fishWeight >= 3f && fish.fishWeight < 5f)
                {
                    fish.fishSize = FishSize.Medium;
                }
                else if (fish.fishWeight >= 5f && fish.fishWeight < 8f)
                {
                    fish.fishSize = FishSize.Big;
                }
                else if (fish.fishWeight >= 8f && fish.fishWeight < 18f)
                {
                    fish.fishSize = FishSize.Large;
                }
                else if (fish.fishWeight >= 18)
                {
                    fish.fishSize = FishSize.Enormus;
                }

                // Ustawianie wagi ryby w zale�no�ci od jej nazwy.
                switch (fish.fishName)
                {
                    case "Carp":
                        fish.fishWeight = Random.Range(1.5f, 20f);
                        break;
                    case "Roach":
                        fish.fishWeight = Random.Range(0.1f, 2f);
                        break;
                }

                // Wy�wietlanie informacji o rybie w konsoli.
                Debug.Log("Fish Name: " + fish.fishName);
                Debug.Log("Fish Weight: " + fish.fishWeight);
                //
            }
        }

        // Metoda analizuj�ca czas potrzebny do nawini�cia �y�ki.
        private void AnalizeTimeToClick(Fish fish)
        {
            if (_fish != null)
            {
                if (fish.fishWeight < 0) // Je�li waga ryby jest mniejsza od 0.
                {
                    fish.fishWeight = Random.Range(0f, 1f); // Losowanie wagi ryby.
                    Debug.LogAssertion("Ryba Ma Wage Poni�ej 0"); // Wy�wietlenie ostrze�enia w konsoli.
                }
                else if (fish.fishWeight >= 0.1f && fish.fishWeight < 1.5f) // Je�li waga ryby mie�ci si� w przedziale.
                {
                    timesToClick = Random.Range(2, 8); // Wylosowanie liczby klikni��.
                }
                else if (fish.fishWeight >= 1.5f && fish.fishWeight < 3f)
                {
                    timesToClick = Random.Range(5, 18);
                }
                else if (fish.fishWeight >= 3f && fish.fishWeight < 5f)
                {
                    timesToClick = Random.Range(8, 30);
                }
                else if (fish.fishWeight >= 5f && fish.fishWeight < 8f)
                {
                    timesToClick = Random.Range(15, 45);
                }
                else if (fish.fishWeight >= 8f && fish.fishWeight < 18f)
                {
                    timesToClick = Random.Range(20, 70);
                }
                else if (fish.fishWeight >= 18)
                {
                    timesToClick = Random.Range(30, 120);
                }

                Debug.Log("Times To Reel: " + timesToClick); // Wy�wietlenie liczby klikni�� w konsoli.
            }
        }

        // Zmienna przechowuj�ca liczb� klikni��.
        int clicked = 0;

        // Metoda odpowiadaj�ca za nawijanie �y�ki.
        public void Reel()
        {
            clicked++; // Zwi�kszenie liczby klikni��.

            if (canReel) // Je�li mo�liwe jest nawijanie �y�ki.
            {
                Button reel = GameObject.Find("Reel").GetComponent<Button>(); // Pobranie przycisku nawijania �y�ki.
                reel.interactable = true; // Ustawienie mo�liwo�ci interakcji z przyciskiem.

                if (clicked >= timesToClick) // Je�li liczba klikni�� jest wi�ksza lub r�wna liczbie klikni�� potrzebnych do nawini�cia.
                {
                    clicked = 0; // Zresetowanie liczby klikni��.
                    AnalizeFish(_fish[randomFishIndex]); // Analiza wylosowanej ryby.
                    canReel = false; // Wy��czenie mo�liwo�ci nawijania �y�ki.
                }
            }
            else // Je�li niemo�liwe jest nawijanie �y�ki.
            {
                Button reel = GameObject.Find("Reel").GetComponent<Button>(); // Pobranie przycisku nawijania �y�ki.
                reel.interactable = false; // Wy��czenie mo�liwo�ci interakcji z przyciskiem.
            }
        }
    }
}
