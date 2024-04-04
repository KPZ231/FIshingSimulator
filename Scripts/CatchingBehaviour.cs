using UnityEngine;
using UnityEngine.UI;

// Deklaracja przestrzeni nazw "Fishing_Sim".
namespace Fishing_Sim
{
    // Deklaracja klasy "CatchingBehaviour" dziedzicz¹cej po klasie "MonoBehaviour".
    public class CatchingBehaviour : MonoBehaviour
    {
        // Deklaracja statycznej w³aœciwoœci "instance" typu "CatchingBehaviour" - Singleton.
        public static CatchingBehaviour instance { get; private set; }

        // Deklaracja tablicy przechowuj¹cej obiekty typu "Fish".
        [Header("Fish")]
        public Fish[] _fish = { };
        // Deklaracja zmiennej przechowuj¹cej czas do ataku.
        public float _timeToAttack = 1f;
        [HideInInspector] private int timesToClick = 0;
        private int randomFishIndex = 0;

        // Metoda wywo³ywana przy starcie obiektu.
        private void Start()
        {
            instance = this; // Inicjalizacja Singletona.
            Reel(); // Rozpoczêcie nawijania ¿y³ki.
        }

        // Zmienna kontroluj¹ca, czy ryba zosta³a sprawdzona.
        private bool isChecked = false;
        [HideInInspector] public bool canReel = false;

        // Metoda wywo³ywana przy ataku ryby.
        public void Bite()
        {
            if (!isChecked) // Jeœli ryba nie zosta³a jeszcze sprawdzona.
            {
                _timeToAttack = Random.Range(0f, 25f); // Losowanie czasu do ataku.
                isChecked = true; // Ustawienie flagi sprawdzenia na true.
                timesToClick = Random.Range(0, 50); // Wylosowanie liczby klikniêæ.
                Player.instance.PlayAnim(); // Odtworzenie animacji gracza.
                randomFishIndex = Random.Range(0, _fish.Length); // Wylosowanie indeksu ryby z tablicy.
                AnalizeTimeToClick(_fish[randomFishIndex]); // Analiza liczby klikniêæ do nawiniêcia ¿y³ki.
            }
        }

        // Metoda wywo³ywana co klatkê.
        private void Update()
        {
            if (isChecked == true) // Jeœli ryba zosta³a sprawdzona.
            {
                _timeToAttack -= Time.deltaTime; // Odliczanie czasu do ataku.
                if (_timeToAttack < 0f) // Jeœli czas do ataku up³yn¹³.
                {
                    isChecked = false; // Resetowanie flagi sprawdzenia.
                    canReel = true; // Ustawienie mo¿liwoœci nawijania ¿y³ki na true.
                    Player.instance.PlayAnim(); // Odtworzenie animacji gracza.
                    Reel(); // Rozpoczêcie nawijania ¿y³ki.
                }
            }
        }

        // Metoda analizuj¹ca parametry ryby.
        public void AnalizeFish(Fish fish)
        {
            fish.fishType = FishType.Common; // Ustawienie typu ryby na "Common".

            if (fish != null) // Jeœli ryba istnieje.
            {
                if (fish.fishWeight < 0) // Jeœli waga ryby jest mniejsza od 0.
                {
                    fish.fishWeight = Random.Range(0f, 1f); // Losowanie wagi ryby.
                    Debug.LogAssertion("Ryba Ma Wage Poni¿ej 0"); // Wyœwietlenie ostrze¿enia w konsoli.
                }
                else if (fish.fishWeight >= 0.1f && fish.fishWeight < 1.5f) // Jeœli waga ryby mieœci siê w przedziale.
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

                // Ustawianie wagi ryby w zale¿noœci od jej nazwy.
                switch (fish.fishName)
                {
                    case "Carp":
                        fish.fishWeight = Random.Range(1.5f, 20f);
                        break;
                    case "Roach":
                        fish.fishWeight = Random.Range(0.1f, 2f);
                        break;
                }

                // Wyœwietlanie informacji o rybie w konsoli.
                Debug.Log("Fish Name: " + fish.fishName);
                Debug.Log("Fish Weight: " + fish.fishWeight);
                //
            }
        }

        // Metoda analizuj¹ca czas potrzebny do nawiniêcia ¿y³ki.
        private void AnalizeTimeToClick(Fish fish)
        {
            if (_fish != null)
            {
                if (fish.fishWeight < 0) // Jeœli waga ryby jest mniejsza od 0.
                {
                    fish.fishWeight = Random.Range(0f, 1f); // Losowanie wagi ryby.
                    Debug.LogAssertion("Ryba Ma Wage Poni¿ej 0"); // Wyœwietlenie ostrze¿enia w konsoli.
                }
                else if (fish.fishWeight >= 0.1f && fish.fishWeight < 1.5f) // Jeœli waga ryby mieœci siê w przedziale.
                {
                    timesToClick = Random.Range(2, 8); // Wylosowanie liczby klikniêæ.
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

                Debug.Log("Times To Reel: " + timesToClick); // Wyœwietlenie liczby klikniêæ w konsoli.
            }
        }

        // Zmienna przechowuj¹ca liczbê klikniêæ.
        int clicked = 0;

        // Metoda odpowiadaj¹ca za nawijanie ¿y³ki.
        public void Reel()
        {
            clicked++; // Zwiêkszenie liczby klikniêæ.

            if (canReel) // Jeœli mo¿liwe jest nawijanie ¿y³ki.
            {
                Button reel = GameObject.Find("Reel").GetComponent<Button>(); // Pobranie przycisku nawijania ¿y³ki.
                reel.interactable = true; // Ustawienie mo¿liwoœci interakcji z przyciskiem.

                if (clicked >= timesToClick) // Jeœli liczba klikniêæ jest wiêksza lub równa liczbie klikniêæ potrzebnych do nawiniêcia.
                {
                    clicked = 0; // Zresetowanie liczby klikniêæ.
                    AnalizeFish(_fish[randomFishIndex]); // Analiza wylosowanej ryby.
                    canReel = false; // Wy³¹czenie mo¿liwoœci nawijania ¿y³ki.
                }
            }
            else // Jeœli niemo¿liwe jest nawijanie ¿y³ki.
            {
                Button reel = GameObject.Find("Reel").GetComponent<Button>(); // Pobranie przycisku nawijania ¿y³ki.
                reel.interactable = false; // Wy³¹czenie mo¿liwoœci interakcji z przyciskiem.
            }
        }
    }
}
