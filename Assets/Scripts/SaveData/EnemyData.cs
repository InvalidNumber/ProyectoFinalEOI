using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class EnemiesData
{
    public string[] tipoEnemigo; // 1-Zombunny 2-Zombear 3-Hellefant
    public int[] health;
    public float[][] position;
    public float[][] rotation;

    public EnemiesData(GameObject[] enemies)
    {
        tipoEnemigo = new string[enemies.Length];
        health = new int[enemies.Length];

        position = Enumerable
            .Range(0, enemies.Length)
            .Select(i => new float[3])
            .ToArray();
        rotation = Enumerable
            .Range(0, enemies.Length)
            .Select(i => new float[3])
            .ToArray();

        for (int i = 0; i < enemies.Length; i++)
        {
            tipoEnemigo[i] = enemies[i].name;
            //health[i] = enemies[i].gameObject.GetComponent<EnemyHealth>().currentHealth;
            position[i][0] = enemies[i].gameObject.transform.position.x;
            position[i][1] = enemies[i].gameObject.transform.position.y;
            position[i][2] = enemies[i].gameObject.transform.position.z;

            rotation[i][0] = enemies[i].gameObject.transform.rotation.x;
            rotation[i][1] = enemies[i].gameObject.transform.rotation.y;
            rotation[i][2] = enemies[i].gameObject.transform.rotation.z;

        }
    }
}