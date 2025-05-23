using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LevelUI : MonoBehaviour
{
    [SerializeField] GameObject HUD;
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject SettingsMenu;
    public CatControlls controls;
    InputAction Pause;

    

    // Start is called before the first frame update
    void Start()
    {

        PauseMenu.SetActive(false);
        HUD.SetActive(true);
        SettingsMenu.SetActive(false);
        
    }

  


    private void Awake()
    {
        controls = new CatControlls();
    }
    void OnEnable()
    {
        Pause = controls.Player.Pause;
        Pause.Enable();
    }

    void OnDisable()
    {
        Pause.Disable();
    }

    // Update is called once per frame
    void Update(){
        
        if (Pause.triggered&& Pause.ReadValue<float>() >0){
            if (PauseMenu.activeSelf){
                //unpause game
                PauseMenu.SetActive(false);
                SettingsMenu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1;
            }
            else{
                //pasue game
                PauseMenu.SetActive(true);
                SettingsMenu.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
            }
        }
    }


    public void resumeGame(){
        PauseMenu.SetActive(false);
        SettingsMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
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
