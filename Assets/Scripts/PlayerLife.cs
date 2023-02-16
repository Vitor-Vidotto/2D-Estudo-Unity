using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    public int vidaMaxima;
    public AudioSource HitSound;
    public int vidaAtual;

    // Start is called before the first frame update
    void Start()
    {
        vidaAtual = vidaMaxima;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReceberDano(){
        vidaAtual -= 1;
        HitSound.Play ();
        if(vidaAtual <= 0)
        {
            SceneManager.LoadScene("Death");
        }
    }
}
