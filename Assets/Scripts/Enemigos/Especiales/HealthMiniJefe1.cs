using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthMiniJefe1 : MonoBehaviour
{
    public GameObject bossManager;
    public GameObject jefe;

    private void Start()
    {
        bossManager = GameObject.FindGameObjectWithTag("BossManager");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bossManager.GetComponent<TheBoss>().jefeZona1Vivo = false;
            Destroy(jefe);
        }
    }
}
