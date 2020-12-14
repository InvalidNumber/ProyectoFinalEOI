using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireball : MonoBehaviour
{
    Animator anim;
    public GameObject nieblaMuerte;
    public int currHealth;
    public int maxHealth;



    private void Start()
    {

        currHealth = maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerFire"))
        {
            currHealth = currHealth - 1;
        }
        if (currHealth <= 0)
            StartCoroutine("Morirse");
    }


    IEnumerator Morirse()
    {

        GetComponent<Collider>().enabled = false;
        if (nieblaMuerte)
        {
            GameObject niebla = Instantiate(nieblaMuerte, transform.position, transform.rotation) as GameObject;
            Destroy(niebla, 3.0f);
        }
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}