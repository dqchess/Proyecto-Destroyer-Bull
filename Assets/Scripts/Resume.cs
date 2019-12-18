using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    [SerializeField] private GameObject gameOverUI;

    public delegate void OnGameResume();
    public static event OnGameResume onGameResume;

    public void gameResume()
    {
        gameOverUI.SetActive(false);
        onGameResume();
        Time.timeScale = 1;
    }
}
