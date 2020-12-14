using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuerdaPuente : MonoBehaviour
{
    public bool quemada;

    private void Start()
    {
        quemada = false;
    }

    private void OnTriggerEnter(Collider fuego)
    {
    
        if (fuego.gameObject.CompareTag("PlayerFire") && quemada == false)
        {
            quemada = true;
            Debug.Log("La cuerda ha sido quemada." + quemada);
        }

        GetComponentInParent<CaerPuente>().TirarPuente();
    }
}
