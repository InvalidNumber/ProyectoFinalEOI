using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosicionFuego : MonoBehaviour
{
    public Transform target;
    Vector3 offset;

    private void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            target.position = (target.forward * 2 );

            

            //transform.position = target.position + new Vector3(0, 0, 0);

            transform.localRotation = target.rotation;
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
