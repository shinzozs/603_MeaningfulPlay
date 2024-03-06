using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public GameObject SettingsMenuUI;
    public GameObject PauseMenuUI;
    PauseMenu PauseMenu;

    private void Start()
    {
        PauseMenu = GetComponent<PauseMenu>();
    }

    public void Settings()
    {
        PauseMenuUI.SetActive(false);
        SettingsMenuUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        PauseMenu.GameIsPaused = true;
    }
}
