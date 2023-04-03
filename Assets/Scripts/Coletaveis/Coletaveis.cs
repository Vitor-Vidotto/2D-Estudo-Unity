using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Coletaveis : MonoBehaviour
{
    public static event Action OnCollected;
    public static int total;

    void Awake() => total++;
    
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            OnCollected?.Invoke();
            Destroy(gameObject);
        }
    }
}
