using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VoltarMenu : MonoBehaviour{
    public void PlayGame(){
        Application.LoadLevel("Cenario1");
    }
    public void Voltar(){
        Application.LoadLevel("menu");
    }
}
