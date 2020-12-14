using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{

    /*private void OnTriggerEnter(Collider other)
    {

        Debug.Log("choca");
        /*
        if (other.tag=="Torch")        
        {
            Debug.Log("con la antorcha");
            other.GetComponent<TorchController>().SetOn();
        }
         * /
    }*/


    private void Update()
    {
        //this.transform.Translate(transform.localRotation.eulerAngles * 1.0f * Time.deltaTime);
        this.transform.Translate(Vector3.right * 1.0f * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider fuego)
    {
        Debug.Log("bola de fuego impacta sobre ---> " + fuego.tag);

        if (fuego.gameObject.CompareTag("Torch"))
        {
            fuego.GetComponent<TorchController>().SetOn();
        }
    }

}
