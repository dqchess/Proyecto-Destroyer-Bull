using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGame : MonoBehaviour
{
    public delegate void OnGameStarted(bool decision);
    public static event OnGameStarted onGameStarded;

    private void Awake()
    {
        Time.timeScale = 0; // sacar pausa, poner velocidad del toro a 0 y realizar alguna accion como el fade
    }
    public void activateUI(GameObject UI)
    {
        UI.SetActive(true);
    }
    public void deactivateUI(GameObject UI)
    {
        UI.SetActive(false);
    }

    public void play()
    {      
        Time.timeScale = 1; // aca restaurariamos la velocidad del toro para empezar       
    }
}
