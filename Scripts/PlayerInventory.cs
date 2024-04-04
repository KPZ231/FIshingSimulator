using System.Collections.Generic;
using UnityEngine;

// Deklaracja przestrzeni nazw "Fishing_Sim".
namespace Fishing_Sim
{
    // Deklaracja klasy "PlayerInventory" dziedzicz�cej po klasie "MonoBehaviour".
    public class PlayerInventory : MonoBehaviour
    {
        // Deklaracja statycznej w�a�ciwo�ci "instance" typu "PlayerInventory" - Singleton.
        public static PlayerInventory instance { get; private set; }

        // Lista przechowuj�ca przedmioty w inwentarzu gracza.
        public List<Item> inventoryItems = new List<Item>();
        // Pojemno�� inwentarza gracza.
        public int inventoryCapacity = 100;
        // Wybrany przez gracza przedmiot.
        public Item itemSelected = null;

        // Flaga okre�laj�ca, czy inwentarz jest widoczny.
        private static bool isInventoryShown = false;

        // Metoda wywo�ywana przy starcie obiektu.
        private void Start()
        {
            instance = this; // Inicjalizacja Singletona.

            inventoryItems.Capacity = inventoryCapacity; // Ustawienie pojemno�ci inwentarza.
        }

        // Metoda wywo�ywana co klatk�.
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Tab)) // Je�li naci�ni�to klawisz "Tab".
            {
                if (isInventoryShown) // Je�li inwentarz jest widoczny.
                {
                    //ShowInventory(); // Wywo�anie metody pokazuj�cej inwentarz.
                }
                else // Je�li inwentarz nie jest widoczny.
                {
                    //HideInventory(); // Wywo�anie metody ukrywaj�cej inwentarz.
                }
            }
        }
    }
}
