using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager gestor;

    #region Variables
    string nextLevel;

    public GameObject player;
    public GameObject[] enemigos;

    // Array de string donde guardar los nombres de las escenas
    public string[] scenes;

    // Variable para saber en qué escena/nivel me encuentro
    static int escenaActual;

    // Bool para controlar el fadeIn de entrada de escena
    bool primeraVez;

    #endregion

    private void Awake()
    {
        gestor = this;
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            StartCoroutine(jugadorExiste());
        }

        escenaActual = SceneManager.GetActiveScene().buildIndex;
        primeraVez = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Comenzar()
    {
        SceneManager.LoadScene(1);
    }

    public void Salir()
    {
        Application.Quit();
    }
    public void LoadNextLevel()
    {
        StartCoroutine(esperaFadeLoadNext());
    }
    IEnumerator esperaFadeLoadNext()
    {
        yield return new WaitForSeconds(4);
        escenaActual += 1;
        if (escenaActual >= scenes.Length)
        {
            escenaActual = 0;
        }
        SceneManager.LoadScene(escenaActual);
    }

    public IEnumerator jugadorExiste()
    {
        while (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            yield return new WaitForEndOfFrame();
        }
        SaveLoadManager.SLManager.PlayerEncontrado();

    }

    private bool IsArrayEmpty()
    {
        if (enemigos == null || enemigos.Length == 0) return true;
        return false;
    }

    public IEnumerator enemigosExisten()
    {

        while (IsArrayEmpty())
        {
            enemigos = GameObject.FindGameObjectsWithTag("Enemy");
            yield return new WaitForEndOfFrame();
        }
    }
}
