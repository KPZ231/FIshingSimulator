using UnityEngine;

// Deklaracja przestrzeni nazw "Fishing_Sim".
namespace Fishing_Sim
{
    // Deklaracja publicznego wyliczenia "Method" z r�nymi metodami po�owu.
    public enum Method
    {
        Float,      // Sp�awikowa
        Feeder,     // Methoda zan�towa
        Spining     // Spinningowa
    }

    // Deklaracja klasy "Player" dziedzicz�cej po klasie "MonoBehaviour".
    public class Player : MonoBehaviour
    {
        // Deklaracja statycznej w�a�ciwo�ci "instance" typu "Player" - Singleton.
        public static Player instance { get; private set; }

        // Wybrana przez gracza metoda po�owu.
        public Method method;

        // Tablica przechowuj�ca obiekty reprezentuj�ce r�ne metody po�owu.
        [SerializeField] private GameObject[] methodObjects = { }; // 0 - Float, 1 - Feeder, 2 - Spinning

        // Metoda odpowiadaj�ca za odtwarzanie animacji odpowiedniej dla wybranej metody po�owu.
        public void PlayAnim()
        {
            GameObject _float = methodObjects[0];     // Obiekt reprezentuj�cy sp�awikow� metod� po�owu.
            GameObject _feeder = methodObjects[1];    // Obiekt reprezentuj�cy metod� zan�tow�.
            GameObject _spinning = methodObjects[2];   // Obiekt reprezentuj�cy spinningow� metod� po�owu.

            // Sprawdzenie wybranej metody po�owu.
            if (method == Method.Float)
            {
                // Je�li mo�liwo�� nawijania �y�ki jest wy��czona.
                if (CatchingBehaviour.instance.canReel == false)
                {
                    _float.GetComponent<Animator>().Play("Float_Bite"); // Odtworzenie animacji gryzienia sp�awika.
                    _float.GetComponent<Animator>().SetBool("CanReel", false); // Ustawienie parametru "CanReel" na false.
                }
                else // Je�li mo�liwo�� nawijania �y�ki jest w��czona.
                {
                    _float.GetComponent<Animator>().SetBool("CanReel", true); // Ustawienie parametru "CanReel" na true.
                    _float.GetComponent<Animator>().Play("Float_Attack"); // Odtworzenie animacji ataku sp�awika.
                }
            }
        }

        // Metoda wywo�ywana przy starcie obiektu.
        private void Start()
        {
            instance = this; // Inicjalizacja Singletona.
        }
    }
}
