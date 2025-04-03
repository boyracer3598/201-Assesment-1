using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelContoller : MonoBehaviour
{
    public List<toyPickup> toyPickups = new List<toyPickup>();
    public static int numberOfToys;//number toys in level
    public static int numberOfTrash;//number trash in level
    public playerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindFirstObjectByType<playerMovement>();
        numberOfToys = GameObject.FindGameObjectsWithTag("toy").Length;
        numberOfTrash = GameObject.FindGameObjectsWithTag("trash").Length;
    }

    

    // Update is called once per frame
    void Update()
    {
        if ( player.toyCount== numberOfToys){
            Debug.Log("All toys collected");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        //check if all trash is collected   
        if (player.trashCount == numberOfTrash){
            if(player.isAllTrashCollected){
                //do nothing
            }
            else {
                Debug.Log("All trash collected");
                player.isAllTrashCollected = true;
            }
        }
    }
}
