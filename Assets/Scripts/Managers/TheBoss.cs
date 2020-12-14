using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheBoss : MonoBehaviour
{
    public bool jefeZona1Vivo;
    public GameObject jefeZona1;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Start is called before the first frame update
    void Start()
    {
        jefeZona1Vivo = true;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        jefeZona1 = GameObject.FindGameObjectWithTag("MiniJefe1");
        if(jefeZona1 != null)
        {
            Debug.Log("El jefe existe.");
            if (jefeZona1Vivo == false)
            {
                jefeZona1.SetActive(false);
            }
        }
    }

}
