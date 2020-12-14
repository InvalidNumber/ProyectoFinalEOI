using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchController : MonoBehaviour
{

    public GameObject myFire;

    private void Awake()
    {
        //myFire.SetActive(false);
        myFire.GetComponent<ParticleSystem>().Stop();
    }

    
    public void SetOn()
    {
        //myFire.SetActive(true);
        myFire.GetComponent<ParticleSystem>().Play();

    }
    

    /// <summary>
    /// Cuando una de las bolas de fuego que lanza el jugador impacta con la antorcha la enciende
    /// </summary>
    /// <param name="fuego"></param>
    private void OnTriggerEnter(Collider fuego)
    {
        Debug.Log("Antorcha impactada ---> " + fuego.tag);

        if (fuego.gameObject.CompareTag("PlayerFire"))
        {
            Debug.Log("... por la bola de fuego ");

            myFire.GetComponent<ParticleSystem>().Play();

            GetComponent<MeshCollider>().enabled = false;

        }
    }


}
