using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fishing_Sim
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance { get; private set; } //Singelton


        private void Start()
        {
            instance = this; //Inicjalizacja Singeltona W Metodzie Startu
        }
    }
}
