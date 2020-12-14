using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morir : MonoBehaviour
{
    public GameObject enemigo;
    Animator anim;
    public GameObject nieblaMuerte;



    private void Start()
    {
        anim = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine("Morirse");
        }
    }


    IEnumerator Morirse()
    {
        enemigo.GetComponent<Collider>().enabled = false;
        if (nieblaMuerte)
        {
            GameObject niebla = Instantiate(nieblaMuerte, enemigo.transform.position, enemigo.transform.rotation) as GameObject;
            Destroy(niebla, 3.0f);
        }
        enemigo.GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(2);
        Destroy(enemigo);
    }
}