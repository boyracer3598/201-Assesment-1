using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// controls the HUD
/// </summary>
public class HUDScript : MonoBehaviour
{
    playerMovement player;
    [SerializeField] TextMeshProUGUI toyCountText;
    [SerializeField] TextMeshProUGUI powerUp;
    [SerializeField] Slider powerUpSlider;
    LevelContoller LevelContoller;
    int maxToys;

    // Start is called before the first frame update
    void Start()
    {
        LevelContoller = FindFirstObjectByType<LevelContoller>();
        maxToys = LevelContoller.GetNumberOfToys();
        player =FindFirstObjectByType<playerMovement>();
        powerUpSlider.maxValue = player.powerupDuration;
        Debug.Log("Max Toys: " + maxToys);
        toyCountText.text = "Toys: " + player.toyCount+"/"+maxToys;
    }

    private void OnEnable()
    {
        LevelContoller = FindFirstObjectByType<LevelContoller>();
        maxToys = LevelContoller.GetNumberOfToys();
        player = FindFirstObjectByType<playerMovement>();
        powerUpSlider.maxValue = player.powerupDuration;
        Debug.Log("Max Toys: " + maxToys);
        toyCountText.text = "Toys: " + player.toyCount + "/" + maxToys;
    }

    // Update is called once per frame
    void Update()
    {
        
        toyCountText.text = "Toys: " + player.toyCount + "/"+maxToys;
        powerUpSlider.value = player.powerupRemaining;
    }
}
