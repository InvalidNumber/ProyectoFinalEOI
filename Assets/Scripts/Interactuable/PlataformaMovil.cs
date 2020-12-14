using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    public Transform[] puntosDestino;// El punto al que la plataforma se movera
    public float velocidad = 6.0f;// La velocidad a la que lo hara

    int curPos = 0;// Posicion desde la que se esta moviendo
    int nextPos = 1;// Posicion a la que se mueve

    bool moveNext = true;// Si esta variable es verdadera la plataforma se mueve a la siguiente posicion
    public float timeToNext = 2.0f;// Tiempo que tarda en empezar a moverse a la siguiente posicion

    private void FixedUpdate()
    {

        // Si la plataforma debe moverse
        if(moveNext)
        {
            // Cogemos la posicion de la plataforma y a la que nos deseamos mover dentro del array
            transform.position = Vector3.MoveTowards(transform.position, puntosDestino[nextPos].position, velocidad * Time.deltaTime);
        }

        // .Distance mide la distancia entre los dos vectores, esto comprueba si la plataforma ya llego al punto
        // al que debía ir
        if(Vector3.Distance(transform.position, puntosDestino[nextPos].position) <=0)
        {
            // Iniciamos el tiempo de pausa para moverse
            StartCoroutine(TimeMove());
            // La posicion a la que se dirije pasa a ser la siguiente(la actual[nextPos] +1) y la actual pasa a ser la anterior
            curPos = nextPos;
            nextPos++;

            // Comprobamos que la posicion siguiente es valida
            if(nextPos > puntosDestino.Length -1)
            {
                nextPos = 0;
            }
        }
    }

    IEnumerator TimeMove()
    {
        moveNext = false;// La ponemos a falsa para que la plataforma deje de moverse a la siguiente posicion
        yield return new WaitForSeconds(timeToNext);// Espera los segundos que hayamos puesto en timeToNext
        moveNext = true;// Despues de timeToNext segundos la plataforma comienza a moverse
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            other.transform.SetParent(this.gameObject.transform);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.SetParent(null);
        }
    }

}
