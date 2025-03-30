using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUI : MonoBehaviour
{
    [SerializeField] GameObject HUD;
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject SettingsMenu;
    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
        HUD.SetActive(true);
        SettingsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (PauseMenu.activeSelf){
                PauseMenu.SetActive(false);
                SettingsMenu.SetActive(false);
                Time.timeScale = 1;
            }
            else{
                PauseMenu.SetActive(true);
                SettingsMenu.SetActive(false);
                Time.timeScale = 0;
            }
        }
    }

    /// <summary>
    /// brings up settings menu
    /// </summary>
    public void settings(){
        PauseMenu.SetActive(false);
        SettingsMenu.SetActive(true);
    }

    /// <summary>
    /// goes back from settings menu
    /// </summary>
    public void back(){
        SettingsMenu.SetActive(false);
        PauseMenu.SetActive(true);
    }

    public void mainMenu(){
        SceneManager.LoadScene("Main Menu");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
