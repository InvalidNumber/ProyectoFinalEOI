using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpBolaFuegoLocal : MonoBehaviour
{
    public GameObject fireParticles;
    //public Vector3 firePosition;
    public GameObject firePosition;
    public float maxShootTime = 2.0f;
    public float shootTime = 0.0f;

    public float sumX = 1f;
    public float sumY = 1f;
    public float sumZ = 1f;

    // Update is called once per frame
    private void Awake()
    {
        shootTime = maxShootTime;
    }

    void Update()
    {
        shootTime += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.N) && shootTime >= maxShootTime)
        {
            shootTime = 0f;
            //Vector3 newPosition = firePosition.GetComponent<PosicionPlayer>().GetPosition() + new Vector3(0, 0, 2);
            //Quaternion newRotation = firePosition.GetComponent<PosicionPlayer>().GetRotation(); 
            Vector3 newPosition = firePosition.transform.localPosition + new Vector3(0, 0.2f, 2);// Usa la posicion local del punto de disparo
            Quaternion newRotation = firePosition.transform.localRotation;
            newRotation = newRotation * new Quaternion(sumX, sumY, sumZ, 1);

            GameObject fireTemp = Instantiate(fireParticles, newPosition, newRotation) as GameObject;
            Destroy(fireTemp, 5.0f);
        }
    }

    // Si se le asigna posicionPlayer funciona igual que playerShoot(disparando hacia el lado)
    // pero si se le pone en bocaDragon lo que hace no tiene ningun sentido(se generan en un sitio, 
    // siempre en la misma direccion y no se mueven de ahi)
}
