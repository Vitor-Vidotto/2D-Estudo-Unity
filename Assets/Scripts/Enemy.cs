using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    public GameObject cubePrefab;

    public int maxHealth = 100;
    int currentHealth;
    Rigidbody2D rb2D;

    public void Start()
    {
        currentHealth = maxHealth;
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth < 0)
        {
            die();
        }


    }

    void die()
    {
        Instantiate(cubePrefab, transform.position, Quaternion.identity);
        rb2D.gravityScale -= -1;
        GetComponent<Collider2D>().enabled = true;
        Destroy(gameObject);
        /*rb2D.gravityScale -= -1;
        rb2D.constraints = RigidbodyConstraints2D.FreezePositionX;
        rb2D.constraints = RigidbodyConstraints2D.FreezePositionY;
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;*/
        Debug.Log("enemy died");
    }

    

}
