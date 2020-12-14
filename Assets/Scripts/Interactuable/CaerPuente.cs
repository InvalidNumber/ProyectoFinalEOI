using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaerPuente : MonoBehaviour
{
    public GameObject cruze;
    public GameObject[] cuerdasDelPuente;
    int numeroCuerdasQuemadas;
    int numeroCuerdas;

    private void Start()
    {
        numeroCuerdas = cuerdasDelPuente.Length;
        Debug.Log("Numero de cuerdas a quemar: " + cuerdasDelPuente.Length);
    }

    
    public void TirarPuente()
    {
        foreach (GameObject item in cuerdasDelPuente)
        {
            if (item.GetComponent<CuerdaPuente>().quemada == true)
            {
                numeroCuerdasQuemadas++;
                Debug.Log("El numero de cuerdas quemadas es: " + numeroCuerdasQuemadas);
            }
            else
            {
                numeroCuerdasQuemadas = 0;
            }

            if (numeroCuerdasQuemadas == numeroCuerdas)
            {
                Debug.Log("Rigidbody metido");
                cruze.gameObject.AddComponent<Rigidbody>();
                StartCoroutine(Desaparecer());
            }
        }
            /*
            for (int i = 0; i < cuerdasDelPuente.Length; i++)
            {
                if(cuerdasDelPuente[i].GetComponent<CuerdaPuente>().quemada == true)
                {
                    numeroCuerdasQuemadas++;
                    Debug.Log("Numero cuerdas quemadas: " + i);
                }
                else
                {
                    numeroCuerdasQuemadas = 0;
                }


                if(numeroCuerdasQuemadas == numeroCuerdas)
                {
                    Debug.Log("Rigidbody metido");
                    cruze.gameObject.AddComponent<Rigidbody>();
                }

            }
            //tablasPuente.AddComponent<Rigidbody>();
            */
        }

    IEnumerator Desaparecer()
    {
        yield return new WaitForSeconds(8);
        Destroy(this.gameObject);
    }
    
}
