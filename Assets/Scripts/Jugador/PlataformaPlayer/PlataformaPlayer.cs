using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaPlayer : MonoBehaviour
{
    Rigidbody playerBody;

    Vector3 groundPos; // Posicion Actual
    Vector3 lastGroundPos; // Ultima posicion
    Vector3 currentPos; // Posicion recalculada

    string groundName;
    string lastGroundName;

    public bool isJump; // Si esta variable es verdadera el personaje dejara de moverse junto a la plataforma

    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        isJump = GetComponent<MovimientoExperimento>().isGrounded;
    }

    
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Platform")
        {
            if(!isJump)
            {
                GameObject enSuelo = other.gameObject;// Almacenamos el objeto con el que colisionamos
                groundName = enSuelo.name;
                groundPos = enSuelo.transform.position; // Posicion del objeto sobre l que estamos

                if (groundPos != lastGroundPos && groundName == lastGroundName)
                {
                    currentPos = Vector3.zero; // Reseteamos la posicion que reseteara nuestro personaje
                    currentPos += groundPos - lastGroundPos; // Calculamos la posicion a la que debera moverse nuestro personaje
                    playerBody.MovePosition(currentPos); // Agregamos el movimiento calculado a nuestro personaje
                }
                lastGroundName = groundName;
                lastGroundPos = groundPos;
            }
        }
    }
}
