using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGame : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 0;
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
        Time.timeScale = 1;
    }
}
