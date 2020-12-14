using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;


/// <summary>
/// EnemyMovement: clase para gestionar el movimiento de los enemigos.
/// </summary>

[RequireComponent(typeof(Animator))]


public class EnemyBeesMovement : MonoBehaviour
{

    protected float parabolicAnimation;
    bool moving = false;
    public float heightMin, heightMax; 

    public float searchRange = 20.0f;
    public float attackRange = 5.0f; // Distancia máxima a la que puede estar un enemigo y atacar
    public float rotateRange = 4.0f;

    [SerializeField]
    public struct NamesValues
    {
        public string name;
        public int value;
    }

    public NamesValues[] namesValues;

    [Tooltip("Nombre del parámetro para gestionar animación. Animación de moviento si es false. Animación Idle si es true.")]
    public string animationParameter = "";  // Nombre del parámetro de la animación.

    GameObject player; // posición del player
    NavMeshAgent nav; // referencia al componente NavMeshAgent
    Animator anim; // referencia al Animator Controller
    

        // Start is called before the first frame update
    
    void Awake()
    //void Start()
    {
        // Bucamos el gameobject con Tag Player y obtenemos su posición.
        player = GameObject.FindGameObjectWithTag("Player");

         // Obtenemos el NavMeshAgent del gameObject al que este script está asociado como componente. 
        nav = GetComponent<NavMeshAgent>();

        // Obtenermos el Animator Controller del gamObject
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        BeesAI();
        
        if (moving)
        {
            float height = Random.Range(heightMin, heightMax);
            MovingWithParabola(transform.position, GetPlayerPosition(), height);
        }

    }


    void BeesAI()
    {
        /* están en una posición de patrullar

        //si un personaje entra en su zona de patrullar:
        --> buscan al personaje 
            --> si está a la distancia de ataque
                --> realizan el movimiento parabolico hacia él
                    --> si están cerca del personaje 
                        --> atacar
        */
        

        if (GetPlayerDistance() > searchRange)
        {
            PatrolMovement();
        }
        else
        {
            if (GetPlayerDistance() > attackRange)
            {
                //MovingWithParabola(transform.position, GetPlayerPosition(), height);
                moving = true;
            }
            else
            {
                moving = false;
                Attack();

            }

        }

    }


    void PatrolMovement()
    {
        //función de patrullar
    }



    void Attack()
    {
        //funcion para atacar
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
        transform.position = MathParabolic.Parabola(origen, end, 1, parabolicAnimation / 10);

    }


    //esta función devuelve la posición de la victima
    Vector3 GetPlayerPosition() 
    {
        if (player)
            return player.transform.position;
        return new Vector3(0,0,0);
    }

    //esta funcion devuelve la distancia entre nosotros y la victima
    float GetPlayerDistance()
    {
        return Vector3.Distance(transform.position, GetPlayerPosition());
    }




}
