using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAnamations : MonoBehaviour
{
    playerMovement player;
    Animator charAmimator;
    // Start is called before the first frame update
    void Start()
    {
        player = FindFirstObjectByType<playerMovement>();
        charAmimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
       
        if (player.isWalking)
        {
            charAmimator.SetBool("isWalking", true);
            //play walk sound
        }
        else
        {
            charAmimator.SetBool("isWalking", false);
        }

        if (player.isJumping)
        {
            charAmimator.SetBool("isJumping", true);
            //play jump sound
        }
        else
        {
            charAmimator.SetBool("isJumping", false);
        }

        if (player.isFalling)
        {
            charAmimator.SetBool("isFalling", true);
        }
        else
        {
            charAmimator.SetBool("isFalling", false);
        }

        if (player.isIdle)
        {
            //play idle sound
        }
        else
        {
            //stop idle sound
        }
    }
}
