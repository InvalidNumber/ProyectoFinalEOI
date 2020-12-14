using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


/// <summary>
/// EnemyMovement: clase para gestionar el movimiento de los enemigos.
/// </summary>


public class EnemyThrowProjectile : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 targetPosition;
    protected float parabolicAnimation;


    // Update is called once per frame
    void Update()
    {
        MovingWithParabola(startPosition, targetPosition, 3);

        //this.transform.Rotate(new Vector3(1, 5, 1));

    }



    public void SetStartPosition(Vector3 newPosition)
    {
        startPosition = newPosition;
    }

    public void SetTargetPosition(Vector3 newPosition)
    {
        targetPosition = newPosition;
    }

    void MovingWithParabola(Vector3 origen, Vector3 end, float height)        //esta funcion mueve al enemigo de una posición X a otra posición Y realizando un movimiento parabolico
    {
        parabolicAnimation += Time.deltaTime;

        parabolicAnimation = parabolicAnimation % 5f;

        /*if (heightMin == 0 || heightMax == 0)
        {
            height = Random.Range(-10, 10);
        }*/
        //transform.position = MathParabolic.Parabola(POSICIÓN INICIAL, POSICIÓN FINAL, ALTURA DE LA PARÁBOLA (RECORDAR QUE LOS ELEMENTOS NEGATIVOS VAN A LA INVERSA) y TIEMPO 
        transform.position = MathParabolic.Parabola(origen, end, height, parabolicAnimation / 5);

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().ModifyHealth(-1);
           
        }

        //Destroy(this.gameObject, 0.2f);
    }


}
