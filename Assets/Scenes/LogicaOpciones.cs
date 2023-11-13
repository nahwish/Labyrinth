using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaOpciones : MonoBehaviour
{
    public OptionController panelOpciones;
    private bool isPaused = false;

    void Start()
    {
        panelOpciones = GameObject.FindGameObjectWithTag("opciones").GetComponent<OptionController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame(); // Si ya está pausado, reanudar el juego.
            }
            else
            {
                MostrarOpciones(); // Si no está pausado, mostrar el menú de opciones.
            }
        }
    }

    public void MostrarOpciones()
    {
        panelOpciones.pantallaOpciones.SetActive(true);
        PauseGame(); // Pausar el juego al mostrar el menú de opciones.
    }

    public void PauseGame()
    {
        Time.timeScale = 0.0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
        panelOpciones.pantallaOpciones.SetActive(false); // Ocultar el menú de opciones al reanudar el juego.
    }
}
