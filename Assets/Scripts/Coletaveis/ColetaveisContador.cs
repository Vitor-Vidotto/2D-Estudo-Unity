using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ColetaveisContador : MonoBehaviour
{ 
    TMPro.TMP_Text text;
    public int count;
    public static int counttotal;

    void Awake(){
        text = GetComponent<TMPro.TMP_Text>();
    }

    void Start() => UpdateCount();

    void OnEnable() => Coletaveis.OnCollected += OnColetaveisCollected;
    void OnDisable() => Coletaveis.OnCollected -= OnColetaveisCollected;


    void OnColetaveisCollected(){
        count++;
        UpdateCount();
    }


    void UpdateCount()
    {

        text.text = $"{count} Coins";

        if(count == 6){
            SceneManager.LoadScene("Vitoria");
        }
    }

    void Update(){
        counttotal = count;
        UpdateCount();
    }
}
