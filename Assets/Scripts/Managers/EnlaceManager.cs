using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Este Script se encarga de que el GameManager que es dontdestroyonload pueda seguir siendo usado para los botones, etc.
/// </summary>


public class EnlaceManager : MonoBehaviour
{
    GameObject panelGameOver;
    GameObject jugador;

    // Start is called before the first frame update
    void Start()
    {
        panelGameOver = GameObject.FindGameObjectWithTag("GameOver");
        panelGameOver.SetActive(false);
        jugador = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(jugador == null)
        {
            panelGameOver.SetActive(true);
        }
    }

    public void Salir()
    {
        FindObjectOfType<GameManager>().Salir();
    }

    public void Restart()
    {
        FindObjectOfType<GameManager>().Restart();
    }
}
