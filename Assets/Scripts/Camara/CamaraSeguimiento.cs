using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraSeguimiento : MonoBehaviour
{
    // Esta variable sirve para que la camara sepa a que cosa tiene que seguir.
    public Transform player;
    // Esta variable nos sirve para obtener la posición(distancia camara/player)
    public Vector3 camOffset;

    // Suavidad del movimiento de la camara
    [Range(0.1f, 1.0f)]
    public float SmoothFactor = 0.1f;

    public bool rotacionActiva = true;
    public float velRotacion = 5.0f;

    // Esta variable nos dice cuando nuestra camara esta mirando al personaje
    public bool lookAtPlayer = false;

    void Start()
    {
        // camOffset es la posicion de nuestra camara - la posicion de nuestro player
        //camOffset = transform.position - player.GetComponent<CapsuleCollider>().center;
        camOffset = transform.position - player.position;

        // Si lo anterior da problemas usar esta de abajo y ajustar la camara, ya que la hes puesto que mire al collider
        // y hace algo raro(se pone siempre a la misma distancia o algo).
        // camOffset = transform.position - player.GetComponent<CapsuleCollider>().center;
    }

    void FixedUpdate()
    {
        // Si la rotacion esta activa se ejecuta el if
        if(rotacionActiva)
        {
            // Creamos un quaternio para crear el angulo de rotacion de nuestra camara
            Quaternion camTurnAngle =
                Quaternion.AngleAxis(Input.GetAxis("Mouse X") * velRotacion, Vector3.up); // canTurnAngle sera igual a nuestro
                // angulo de rotacion del raton en el eje x, lo multiplicamos por la velocidad de rotacion y vec3up
            camOffset = camTurnAngle * camOffset;
        }

        // Pasamos cada frame la posicion de nuestro player + camOffset
        Vector3 newPos = player.position + camOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);

        // Si mirar al jugador o la rotacion estan activas se ejecuta este if
        if (lookAtPlayer || rotacionActiva)
        {
            // La camara mira al player
            transform.LookAt(player);
        }

        // Si mantenemos presionado click derecho con el raton la rotacion estara activa
        if(Input.GetButton("Fire2"))
        {
            rotacionActiva = true;
        }
        else
        {
            rotacionActiva = false;
            transform.LookAt(player);
        }

        CheckWall();
    }

    public LayerMask wallLayer;
    void CheckWall()
    {
        RaycastHit hit;
        Vector3 start = player.position;
        Vector3 dir = transform.position - player.position;
        float dist = camOffset.z * -1;
        float xdist = camOffset.x * -1;
        Debug.DrawRay(player.position, dir, Color.green);
        if (Physics.Raycast(player.position, dir, out hit, dist, wallLayer))
        {
            float hitDist = hit.distance;
            Vector3 sphereCastCenter = player.position + (dir.normalized * hitDist);
            transform.position = sphereCastCenter;
        }

        if (Physics.Raycast(player.position, dir, out hit, xdist, wallLayer))
        {
            float hitDist = hit.distance;
            Vector3 sphereCastCenter = player.position + (dir.normalized * hitDist);
            transform.position = sphereCastCenter;
        }
    }
}
