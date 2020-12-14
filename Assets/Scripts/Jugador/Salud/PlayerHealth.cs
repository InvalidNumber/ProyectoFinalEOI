using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxPuntosSalud; 
    public int puntosSalud; // Puntos de vida
    public Image corazon;//variable que hace referencia a la imagen del corazon

    // Start is called before the first frame update
    void Awake()
    {
        puntosSalud = maxPuntosSalud;
    }

    // Update is called once per frame
    void Update()
    {
        // Nos aseguramos que el jugador no puede tener mas de la vida maxima ni menos de 0
        if (puntosSalud > maxPuntosSalud) 
        {
            puntosSalud = maxPuntosSalud; 
        }

        if (puntosSalud <= 0)
        {
            puntosSalud = 0;
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        //Si entra en el colider con la etiqueta EnemyAttack le quitamos vida
        if (other.tag == "EnemyAttack")
        {
            //damage(1);
            ModifyHealth(-1);
            //puntosSalud--;
            //corazon.fillAmount -= 0.1f;//Estamos quitando un trocito al corazon

            //corazon.fillAmount = (puntosSalud / maxPuntosSalud); 

            /*if (puntosSalud <= 0)
            {
                Destroy(gameObject);
            }*/
        }


    }


    /*public void Damage(float amount)
     {
         puntosSalud -= amount;

     }
     public void Heal(float amount)
     {
         puntosSalud += amount;
     }*/

    // Funcion que nos permite alterar la salud del protagonista y es usada por otros objetos
    public void ModifyHealth(int amount)
    {
        puntosSalud += amount;

        float fillamount = (float)puntosSalud / (float)maxPuntosSalud;
        Debug.Log("--------------" + fillamount);
        corazon.fillAmount = fillamount;
    }

}
