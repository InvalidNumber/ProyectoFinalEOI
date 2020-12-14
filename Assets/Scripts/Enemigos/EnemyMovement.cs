using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// EnemyMovement: clase para gestionar el movimiento de los enemigos.
/// </summary>

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]


public class EnemyMovement : MonoBehaviour
{

    public float attackRange = 15.0f; // Distancia máxima a la que puede estar un enemigo y atacar
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
        

        //Debug.Log("Distancia hasta el pj: " + Vector3.Distance(transform.position, player.transform.position));
        /*
        Debug.Log("EnemyMovement::Update:: distancia " + Vector3.Distance(transform.position, player.transform.position));
        Debug.Log("EnemyMovement::Update:: attackRange " + attackRange);
        Debug.Log("EnemyMovement::Update:: Player currentHealth " + player.GetComponent<PlayerHealth>().currentHealth);
        Debug.Log("EnemyMovement::Update:: Enemy currentHealth " + GetComponent<EnemyHealth>().currentHealth);
        */

        //Debug.DrawLine(transform.position, player.transform.position, Color.magenta, 0.01f); ESTA LINEA NOS SIRVE PARA QUE SE DIBUJE
        // UNA LINEA DESDE EL ENEMIGO HASTA EL PROTAGONISTA

        if(player != null)
        {
            if (Vector3.Distance(transform.position, player.transform.position) <= attackRange &&
                        Vector3.Distance(transform.position, player.transform.position) >= rotateRange)
            {
                nav.SetDestination(player.transform.position);
                anim.SetBool("Walk", true);
                Debug.Log("Estas cerca");
                //if (anim.GetBool("Walk")==false) ES ESTA LINEA NECESARIA PARA ALGO? Parece que no sirve

            }
            else if (Vector3.Distance(transform.position, player.transform.position) < rotateRange)
            {
                Vector3 giro = player.transform.position - transform.position;
                giro.y = 0;
                Quaternion rotation = Quaternion.LookRotation(giro);
                GetComponent<Rigidbody>().MoveRotation(rotation);
                //transform.LookAt(player.transform.position);
                Debug.Log("Estoy girando");
                anim.SetBool("Walk", false);
            }
            else
            {
                //PARO AL PERSONAJE
                anim.SetBool("Walk", false);
                //Debug.Log("Estas lejos demasiado lejos para seguirte.");

            }
        }
    }
}
