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
    public void ReceberDanoInimigo(){
        vidaAtual -= 20;
        HitSound.Play ();
        if(vidaAtual <= 0)
        {
            SceneManager.LoadScene("Death");
        }
    }
    public void ReceberDanoArmadilha(){
        vidaAtual -= 10;
        HitSound.Play ();
        if(vidaAtual <= 0)
        {
            SceneManager.LoadScene("Death");
        }
    }
}
