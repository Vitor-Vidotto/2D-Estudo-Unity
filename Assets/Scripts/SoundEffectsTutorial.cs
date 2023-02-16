using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectsTutorial : MonoBehaviour
{   
    public AudioSource Gravitytutorial;
     public float SoundCD = 1.5f;
    public float SoundCDCurrent = 0.0f;
    public bool SoundReady;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E) && SoundReady)
        {
            Gravitytutorial.Play ();
            SoundCDCurrent = 0.0f;
        }

        if(SoundCDCurrent >= SoundCD){
            SoundReady = true;
        } 
        else{
            SoundCDCurrent = SoundCDCurrent + Time.deltaTime;
            SoundReady = false;
        }
    }
}
