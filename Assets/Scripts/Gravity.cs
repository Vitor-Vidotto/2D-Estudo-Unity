using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    private Rigidbody2D rb;

    private bool top;
    public bool virado;
    public float gravityCD = 1.5f;
    public float gravityCDCurrent = 0.0f;
    public bool gravityReady;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && gravityReady){
            rb.gravityScale *= -1;
            gravityCDCurrent = 0.0f;
            Rotation();
        }


         if(gravityCDCurrent >= gravityCD){
            gravityReady = true;
        } 
        else{
            gravityCDCurrent = gravityCDCurrent + Time.deltaTime;
            gravityReady = false;
        }

    }

    void Rotation(){
        if(top == false){
            transform.eulerAngles = new Vector3 (0, 0, 180f);
            virado = true;
        } else {
            transform.eulerAngles = Vector3.zero;
            virado = false;
        }
        top = !top;
    }
}
