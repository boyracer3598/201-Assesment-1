using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    [SerializeField] GameObject[] levels;
    int currentLevel = 0;
    //[SerializeField] GameObject level1, level2, level3, level4;


    // Start is called before the first frame update
    void Start()
    {
        levels[0].SetActive(true);
        levels[1].SetActive(false);
        levels[2].SetActive(false);
        levels[3].SetActive(false);
        //levels = new GameObject[4];
        //levelSelectSetup();
    }

    /// <summary>
    /// funtion called when the next level button is pressed
    /// </summary>
    public void nextLevel()
    {

        if (currentLevel >= levels.Length-1){
            currentLevel = 0;
        }else{
            currentLevel++;
        }

        for (int i = 0; i < levels.Length; i++){
            if (i == currentLevel){
                levels[i].SetActive(true);
            }
            else{
                levels[i].SetActive(false);
            }
        }

    }


    /// <summary>
    /// function called when the previous level button is pressed
    /// </summary>
    public void previousLevel(){
        if (currentLevel <= 0){
            currentLevel = levels.Length - 1;
        }else{
            currentLevel--;
        }
        
        for (int i = 0; i < levels.Length; i++)
        {
            if (i == currentLevel){
                levels[i].SetActive(true);
            }else{
                levels[i].SetActive(false);
            }
        }
    }


    /// <summary>
    /// function called when the play button is pressed
    /// </summary>
    public void playLevel(){
        SceneManager.LoadScene(currentLevel + 1);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
