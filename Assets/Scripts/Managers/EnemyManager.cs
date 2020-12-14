using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] enemies;
    public float spawnTime = 2.0f;
    public Transform[] spawnPoints;
    public PlayerHealth playerHealth;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0.0f)
        {
            //Spamea los enemigos
            //Spawn();

            // Inicializo el timer
            timer = spawnTime;

        }
    }

    void Spawn()
    {
        if (playerHealth.puntosSalud > 0)
        {
            // Seleccionar de forma aleatoria el enemigo que va a aparecer
            GameObject enemy = enemies[Random.Range(0, enemies.Length)];

            //Seleccionar de forma aleatoria la posicion en la que va a aparecer el enemigo
            Transform enemyPosition = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // Instanciamos el enemigo
            Instantiate(enemy, enemyPosition.position, enemyPosition.rotation);
        }
    }
}
