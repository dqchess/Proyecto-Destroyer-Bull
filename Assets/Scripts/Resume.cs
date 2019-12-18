using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;


    public void gameResume()
    {
        gameOverUI.SetActive(false);
        Time.timeScale = 1;
    }
}
