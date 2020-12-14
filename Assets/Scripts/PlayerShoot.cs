using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject fireParticles;
    //public Vector3 firePosition;
    public GameObject firePosition;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            //Vector3 newPosition = firePosition.GetComponent<PosicionPlayer>().GetPosition() + new Vector3(0, 0, 2);
            //Quaternion newRotation = firePosition.GetComponent<PosicionPlayer>().GetRotation(); 
            Vector3 newPosition = firePosition.transform.position + new Vector3(0,0.2f,2);
            Quaternion newRotation = firePosition.transform.localRotation;

            GameObject fireTemp = Instantiate(fireParticles, newPosition, newRotation) as GameObject;
            Destroy(fireTemp, 5.0f);
        }
    }

    // Si lo ponemos en posicionPlayer se giran pero se chocan con el dragon segun en que posicion este porque no se ponen delante de la boca(aunque ->
    // -> el punto del que salen sigue al dragon, lo hacen siempre desde la misma posicion de este
    // Si lo ponemos en bocaDragon no se giran las bolas de fuego con el dragon y van siempre en la misma direccion
}
