using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthLancero : MonoBehaviour
{
    public GameObject enemigo;
    Animator anim;
    public GameObject nieblaMuerte;
    AudioSource audioSource;
    public AudioClip gritoMuerte;

    private void Start()
    {
        audioSource = GetComponentInParent<AudioSource>();
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
        GetComponentInParent<EnemyMovement>().enabled = false;
        GetComponentInParent<CapsuleCollider>().enabled = false;
        anim.SetTrigger("Morir");
        audioSource.clip = gritoMuerte;
        audioSource.Play();
        if (nieblaMuerte)
        {
            GameObject niebla = Instantiate(nieblaMuerte, enemigo.transform.position, enemigo.transform.rotation) as GameObject;
            Destroy(niebla, 3.0f);
        }
        yield return new WaitForSeconds(2);
        Destroy(enemigo);
    }
    

}