using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelContoller : MonoBehaviour
{
    public List<toyPickup> toyPickups = new List<toyPickup>();
    public static int numberOfToys;//number toys in level
    public playerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindFirstObjectByType<playerMovement>();
        numberOfToys = GameObject.FindGameObjectsWithTag("toy").Length;
    }

    

    // Update is called once per frame
    void Update()
    {
        if ( player.toyCount== numberOfToys)
        {
            Debug.Log("All toys collected");
            //TODO: end level
            //go to next level
        }
    }
}
