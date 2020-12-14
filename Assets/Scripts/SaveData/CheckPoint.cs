using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider jugadorEntrante)
    {
        // Si el GameObject que ha disparado el triguues es el player se guarda el juego
        if(jugadorEntrante.gameObject.tag == "Player")
        {
            Debug.Log("CheckPoint::OnTriggerEnter:: Juego salvado");
            GameObject.FindObjectOfType<SaveLoadManager>().SaveGame();
        }
    }
}
