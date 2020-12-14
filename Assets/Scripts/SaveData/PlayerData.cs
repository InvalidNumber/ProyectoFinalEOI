using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    // Datos player
    public int health;
    public float[] position;
    public float[] rotation;

    // Datos del ScoreManager relacionados con el player
    public int score;


    // Datos de la camara - MainCamera
    public float[] positionCamera;
    public float[] rotationCamera;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="player"></param>
    public PlayerData(GameObject player, GameObject Camera)
    {

        // Conversion dentro del player
        health = player.gameObject.GetComponent<PlayerHealth>().puntosSalud;

        position = new float[3];
        position[0] = player.gameObject.transform.position.x;
        position[1] = player.gameObject.transform.position.y;
        position[2] = player.gameObject.transform.position.z;

        rotation = new float[3];
        rotation[0] = player.gameObject.transform.rotation.x;
        rotation[1] = player.gameObject.transform.rotation.y;
        rotation[2] = player.gameObject.transform.rotation.z;

        // Coversion datos de la posicion
        positionCamera = new float[3];
        positionCamera[0] = Camera.gameObject.transform.position.x;
        positionCamera[1] = Camera.gameObject.transform.position.y;
        positionCamera[2] = Camera.gameObject.transform.position.z;

        rotationCamera = new float[4];
        rotationCamera[0] = Camera.gameObject.transform.rotation.x;
        rotationCamera[1] = Camera.gameObject.transform.rotation.y;
        rotationCamera[2] = Camera.gameObject.transform.rotation.z;
        rotationCamera[3] = Camera.gameObject.transform.rotation.w;
    }
}
