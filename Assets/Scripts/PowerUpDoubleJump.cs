using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpDoubleJump : MonoBehaviour
{
    // Start is called before the first frame update

    public int extrajmp = 1;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            other.gameObject.GetComponent<PlayerController>().MoreJump();
            Destroy(gameObject);
        }
    }
}
