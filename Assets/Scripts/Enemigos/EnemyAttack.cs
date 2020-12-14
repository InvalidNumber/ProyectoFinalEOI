using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    Animator anim;
    string tipoAtaque;

    public CapsuleCollider spearCollider;

    // El audio source que ejecutara los sonidos
    AudioSource audioSource;
    public AudioClip gritoAtaque;

    private void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }


    /*private void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("OnTriggerExit");
            anim.SetBool(tipoAtaque, false);

        }
    }*/



    private void OnTriggerStay(Collider other)
    //private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            ResetAttackAnimations(anim);

            int ataque = Random.Range(1, 4);    //generamos un aleatorio del 1 al 3
            //Debug.Log("OnTriggerEnter ||| ataque generado: " + ataque);

            tipoAtaque = "Ataque" + ataque;

            //anim.SetBool(tipoAtaque, true);
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
               
                anim.SetTrigger(tipoAtaque);
            }
        }
    }

    private void ResetAttackAnimations(Animator myAnimator)
    {
        myAnimator.ResetTrigger("Ataque1");
        myAnimator.ResetTrigger("Ataque2");
        myAnimator.ResetTrigger("Ataque3");
    }


    // Funciones que se usan como EVENTOS DENTRO DE LAS ANIMACIONES para activar y desactivar el collider de la lanza
    public void ActivateSpear()
    {
        audioSource.clip = gritoAtaque;
        audioSource.Play();
        spearCollider.enabled = true;
    }

    public void DeactivateSpear()
    {
        spearCollider.enabled = false;
    }
}
