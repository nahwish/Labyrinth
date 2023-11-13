using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void EscenaJuego(){
        SceneManager.LoadScene("Laberinto"); //carga la escena del juego al pres
    }
    public void Salir(){
        Application.Quit();  //cierra el programa al presionar salir en menu principal
    }
}
