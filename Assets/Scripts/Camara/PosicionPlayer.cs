using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosicionPlayer : MonoBehaviour
{
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            transform.position = player.position + new Vector3(0, 3, 0);

            transform.localRotation = player.rotation;
        }
        

    }


    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public Quaternion GetRotation()
    {
        return transform.localRotation;
    }

}
