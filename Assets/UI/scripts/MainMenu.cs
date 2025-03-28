using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject roomSelectMenu;
    [SerializeField] GameObject settingsMenu;
    // Start is called before the first frame update
    void Start()
    {
        mainMenu.SetActive(true);
        roomSelectMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// loads the first level of the game, set all counts to 0
    /// </summary>
    public void newGame(){

    }
    /// <summary>
    /// loads the last saved game
    /// </summary>
    public void loadGame(){

    }
    /// <summary>
    /// exits the game
    /// </summary>
    public void exitGame(){
        Application.Quit();
    }
    /// <summary>
    /// loads the room selection screen
    /// </summary>
    public void roomSelect(){
        mainMenu.SetActive(false);
        roomSelectMenu.SetActive(true);
    }
    /// <summary>
    /// loads the settings screen
    /// </summary>
    public void settings() {
        settingsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
}
