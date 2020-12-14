using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanceroLanzador : MonoBehaviour
{
    public GameObject projectile;
    public GameObject player;
    private Vector3 playerPosition;


    GameObject newProjectile = null;

    // Start is called before the first frame update
    void Start()
    {
        playerPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("no hago na");
        if (newProjectile == null)
        {
            //Debug.Log("instanciar proyectil");
            newProjectile = Instantiate(projectile, this.transform.position, Quaternion.identity) as GameObject;
            Destroy(newProjectile, 3.0f);
        }
    }
}
