using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;

    PlayerLife player;
    
    void Start()
    {
        player = FindObjectOfType<PlayerLife>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = player.vidaAtual;
    }
}
