/* Este es el Script donde hago las copias del script de movimiento que vou consiguiendo que funcionen. */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    Rigidbody rb;
    public float velocidadAvance = 4;
    public float fuerzaSalto;
    public float velocidadGiro = 1;
    CapsuleCollider capsule;
    public float laserLength = 0.025f;

    Vector3 inputPlayer;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        capsule = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        inputPlayer = Vector3.zero;
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

        if (salto != 0 && Grounded())
        {
            inputPlayer.y = salto;
            FuncSalto(inputPlayer);
        }
        else
        {
            inputPlayer.y = 0;
        }

        FuncMovimiento(movV);
    }

    void FixedUpdate()
    {

    }

    void FuncMovimiento(float movimiento)
    {
        rb.MovePosition(movimiento * velocidadAvance * transform.forward);
        //rb.AddForce(movimiento * velocidadAvance * transform.forward, ForceMode.Force);

    }

    void FuncRotar(float movH)
    {

        rb.AddRelativeTorque(Vector3.up * velocidadGiro * movH);
    }

    void FuncSalto(Vector3 movimiento)
    {
        rb.AddForce(movimiento.normalized * fuerzaSalto, ForceMode.Impulse);

    }
    bool Grounded()
    {
        //Laser length

        //Start point of the laser
        Vector3 startPosition = (Vector3)transform.position - new Vector3(0, (capsule.bounds.extents.y + 0.05f), 0);
        //Hit only the objects of Floor layer
        int layerMask = LayerMask.GetMask("Floor");
        //Check if the laser hit something
        RaycastHit hit;
        Physics.Raycast(startPosition, Vector3.down, out hit, laserLength, layerMask);
        if (hit.collider != null)
            Debug.Log("Grounded: " + hit.collider.name);
        return hit.collider != null;
    }
}