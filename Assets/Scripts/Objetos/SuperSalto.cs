using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSalto : MonoBehaviour
{
    private void OnTriggerEnter(Collider objeto)
    {
        if (objeto.tag == "Player")
        {
            //objeto.GetComponent<PlayerHealth>().puntosSalud += 2;

            objeto.GetComponent<MovimientoExperimento>().canChargeJump = true; // Cuando entramos en contacto con el jugador activamos una funcion dentro de el que le cura puntos

            //objeto.GetComponent<PlayerHealth>().corazon.fillAmount += 0.1f;//Estamos quitando un trocito al corazon

            Destroy(gameObject);
        }
    }
}
