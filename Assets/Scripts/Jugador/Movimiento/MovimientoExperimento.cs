using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoExperimento : MonoBehaviour
{
    Rigidbody rb;
    public float velocidadAvance = 4;
    public float fuerzaSalto;
    public float velocidadGiro = 1;
    CapsuleCollider capsule;
    public float laserLength = 0.025f;
    bool jump = false;
    public bool isGrounded = false;

    //saltoCargado
    public float maxJumpTime = 2.0f;
    public float jumpTime = 0.0f;
    public bool chargedJump;
    public bool canChargeJump = true;
    public bool canGlide = true;
    public ConstantForce gravity;

    Vector3 inputPlayer;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        capsule = GetComponent<CapsuleCollider>();
        gravity = gameObject.AddComponent<ConstantForce>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Dejando la tecla espacio presionada cuando estamos en el suelo cargamos un temporizador(jumpTime)
        // que nos dira si podemos hacer el salto cargado
        if (rb.mass != 10)
            rb.mass = 10;
        if (Input.GetKey(KeyCode.Space) && isGrounded && canChargeJump)
        {
            jumpTime += Time.deltaTime;
            if (jumpTime >= maxJumpTime)
            {
                chargedJump = true;
            }            
        }
        else 
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                jump = true;
            }
            chargedJump = false;
            jumpTime = 0.0f;
        }

        if (Input.GetKey(KeyCode.Space) && !isGrounded && canGlide)
        {
            gravity.force = new Vector3(0.0f, 40f, 0.0f);
        }
        else
        {
            gravity.force = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }



    void FixedUpdate()
    {
        //inputPlayer = Vector3.zero;
        float movH = Input.GetAxis("Horizontal");
        float movV = Input.GetAxis("Vertical");
        float salto = Input.GetAxis("Jump");


        if (movH != 0)
        {

            FuncRotar(movH);
            //inputPlayer.x = movH;
        }


        if (movV != 0)
        {
            // inputPlayer.z = movV;

        }
        else
        {
            // inputPlayer.z = 0;
        }

        //Check if the player ray is touching the ground and jump is enable
        if (jump && isGrounded)
        {
            FuncSalto();
        }
        //Disable the jump
        jump = false;

        // Si el salto cargado esta listo y estas en el suelo ejecuta esto
        if (chargedJump && isGrounded)
        {
            FuncSaltoCargado();
        }
        //Disable the jump
        chargedJump = false;

        FuncMovimiento(movV);
    }

    void FuncMovimiento(float movimiento)
    {
        //rb.MovePosition(transform.position + transform.forward);
        rb.AddForce(movimiento * velocidadAvance * transform.forward , ForceMode.Force);

    }

    void FuncRotar(float movH)
    {

        rb.AddRelativeTorque(Vector3.up * velocidadGiro * movH);
    }

    void FuncSalto()
    {
        //isGrounded = false;
        rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);

    }
    void FuncSaltoCargado ()
    {
        rb.AddForce(Vector3.up * fuerzaSalto * 2, ForceMode.Impulse);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 8 || other.gameObject.layer == 9)    //floor = 8
        {
            isGrounded = true;
        }
        //else isGrounded = false;
    }


    private void OnTriggerExit(Collider other)
    {
        isGrounded = false;
    }

}
