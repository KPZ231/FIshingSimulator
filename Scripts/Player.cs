using UnityEngine;

// Deklaracja przestrzeni nazw "Fishing_Sim".
namespace Fishing_Sim
{
    // Deklaracja publicznego wyliczenia "Method" z ró¿nymi metodami po³owu.
    public enum Method
    {
        Float,      // Sp³awikowa
        Feeder,     // Methoda zanêtowa
        Spining     // Spinningowa
    }

    // Deklaracja klasy "Player" dziedzicz¹cej po klasie "MonoBehaviour".
    public class Player : MonoBehaviour
    {
        // Deklaracja statycznej w³aœciwoœci "instance" typu "Player" - Singleton.
        public static Player instance { get; private set; }

        // Wybrana przez gracza metoda po³owu.
        public Method method;

        // Tablica przechowuj¹ca obiekty reprezentuj¹ce ró¿ne metody po³owu.
        [SerializeField] private GameObject[] methodObjects = { }; // 0 - Float, 1 - Feeder, 2 - Spinning

        // Metoda odpowiadaj¹ca za odtwarzanie animacji odpowiedniej dla wybranej metody po³owu.
        public void PlayAnim()
        {
            GameObject _float = methodObjects[0];     // Obiekt reprezentuj¹cy sp³awikow¹ metodê po³owu.
            GameObject _feeder = methodObjects[1];    // Obiekt reprezentuj¹cy metodê zanêtow¹.
            GameObject _spinning = methodObjects[2];   // Obiekt reprezentuj¹cy spinningow¹ metodê po³owu.

            // Sprawdzenie wybranej metody po³owu.
            if (method == Method.Float)
            {
                // Jeœli mo¿liwoœæ nawijania ¿y³ki jest wy³¹czona.
                if (CatchingBehaviour.instance.canReel == false)
                {
                    _float.GetComponent<Animator>().Play("Float_Bite"); // Odtworzenie animacji gryzienia sp³awika.
                    _float.GetComponent<Animator>().SetBool("CanReel", false); // Ustawienie parametru "CanReel" na false.
                }
                else // Jeœli mo¿liwoœæ nawijania ¿y³ki jest w³¹czona.
                {
                    _float.GetComponent<Animator>().SetBool("CanReel", true); // Ustawienie parametru "CanReel" na true.
                    _float.GetComponent<Animator>().Play("Float_Attack"); // Odtworzenie animacji ataku sp³awika.
                }
            }
        }

        // Metoda wywo³ywana przy starcie obiektu.
        private void Start()
        {
            instance = this; // Inicjalizacja Singletona.
        }
    }
}
