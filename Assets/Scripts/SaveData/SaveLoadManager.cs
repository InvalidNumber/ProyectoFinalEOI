using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager SLManager;
    bool loadGame = false;
    PlayerData playerData;
    EnemiesData enemiesData;

    private void Awake()
    {
        SLManager = this;
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        // Si pulsamos load game la variable load game estara a true
        if (loadGame)
        {
            loadGame = false;
            // Cargar datos guardados
            playerData = SaveSystem.LoadPlayer();
            if (playerData != null)
            {
                
                // Obtenemos la referencia del player
                
                if(GameManager.gestor.player == null)
                {
                    StartCoroutine(GameManager.gestor.jugadorExiste());
                }
                else
                {
                    PlayerEncontrado();
                }
                
            }
            else
            {
                Debug.Log("SaveLoadManager;;OnSceneLoaded::playerData NULL");
            }

            // Cargar 
            //EnemiesData enemiesData = SaveSystem.LoadEnemies();
            enemiesData = SaveSystem.LoadEnemies();
            if (enemiesData != null)
            {
                if(GameManager.gestor.enemigos == null)
                {
                    StartCoroutine(GameManager.gestor.enemigosExisten());
                }
                else
                {
                    enemigosEncontrados();
                }
            }
            else
            {
                Debug.Log("SaveLoadManager::OnSceneLoaded::enemiesData Null", this.gameObject);
            }

        }
    }

    public void SaveGame()
    {
        // Guardar Player
        GameObject player = GameObject.FindGameObjectWithTag("Player");


        // Guardar Camara
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");


        SaveSystem.SavePlayer(player, camera);

        // Guardar la informacion de los enemigos
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        SaveSystem.SaveEnemies(enemies);
    }
    public void LoadGame()
    {
        loadGame = true;
        GameObject.FindObjectOfType<GameManager>().LoadNextLevel();

    }

    public void PlayerEncontrado()
    {
        GameObject player = GameManager.gestor.player;

        // Cogemos el valor de vida guardado y lo escribimos en las variables relacionadas con la vida
        player.GetComponent<PlayerHealth>().puntosSalud = playerData.health;
        player.GetComponent<PlayerHealth>().maxPuntosSalud = playerData.health;
        GameObject.FindGameObjectWithTag("CorazonSalud").GetComponent<Image>().fillAmount = playerData.health;

        // Coger el valor de la posicion y la rotacion y se lo ponemos al Player
        player.gameObject.transform.position = new Vector3(playerData.position[0], playerData.position[1], playerData.position[2]);
        player.gameObject.transform.rotation = Quaternion.Euler(playerData.rotation[0], playerData.rotation[1], playerData.rotation[2]);


        // Cargar los valores de la camara
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");

        camera.gameObject.transform.position = new Vector3(playerData.positionCamera[0],
            playerData.positionCamera[1], playerData.positionCamera[2]);

        camera.gameObject.transform.rotation.Set(playerData.rotationCamera[0],
            playerData.rotationCamera[1], playerData.rotationCamera[2], playerData.rotationCamera[3]);
    }

    public void enemigosEncontrados()
    {
        //int numeroEnemigos = enemiesData.tipoEnemigo.Length;
        int numeroEnemigos = GameManager.gestor.enemigos.Length;

        for (int i = 0; i < numeroEnemigos; i++)
        {
            // Obtener una referencia a GameObject que quier instanciar, se encuentra en enemy manager
            GameObject[] enemiesFromEnemyManager = GameObject.FindObjectOfType<EnemyManager>().enemies;

            for (int j = 0; j < enemiesFromEnemyManager.Length; j++)
            {
                if (enemiesData.tipoEnemigo[i].Contains(enemiesFromEnemyManager[j].name))
                {
                    Instantiate(
                        enemiesFromEnemyManager[j],
                        new Vector3(enemiesData.position[i][0], enemiesData.position[i][1], enemiesData.position[i][2]),
                        Quaternion.Euler(enemiesData.rotation[i][0],
                        enemiesData.rotation[i][1],
                        enemiesData.rotation[i][2])
                    );
                }
            }
        }
    }
}
