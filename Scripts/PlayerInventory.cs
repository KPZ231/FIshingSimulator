using System.Collections.Generic;
using UnityEngine;

// Deklaracja przestrzeni nazw "Fishing_Sim".
namespace Fishing_Sim
{
    // Deklaracja klasy "PlayerInventory" dziedzicz¹cej po klasie "MonoBehaviour".
    public class PlayerInventory : MonoBehaviour
    {
        // Deklaracja statycznej w³aœciwoœci "instance" typu "PlayerInventory" - Singleton.
        public static PlayerInventory instance { get; private set; }

        // Lista przechowuj¹ca przedmioty w inwentarzu gracza.
        public List<Item> inventoryItems = new List<Item>();
        // Pojemnoœæ inwentarza gracza.
        public int inventoryCapacity = 100;
        // Wybrany przez gracza przedmiot.
        public Item itemSelected = null;

        // Flaga okreœlaj¹ca, czy inwentarz jest widoczny.
        private static bool isInventoryShown = false;

        // Metoda wywo³ywana przy starcie obiektu.
        private void Start()
        {
            instance = this; // Inicjalizacja Singletona.

            inventoryItems.Capacity = inventoryCapacity; // Ustawienie pojemnoœci inwentarza.
        }

        // Metoda wywo³ywana co klatkê.
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab)) // Jeœli naciœniêto klawisz "Tab".
            {
                if (isInventoryShown) // Jeœli inwentarz jest widoczny.
                {
                    //ShowInventory(); // Wywo³anie metody pokazuj¹cej inwentarz.
                }
                else // Jeœli inwentarz nie jest widoczny.
                {
                    //HideInventory(); // Wywo³anie metody ukrywaj¹cej inwentarz.
                }
            }
        }
    }
}
