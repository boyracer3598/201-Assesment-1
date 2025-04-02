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
    int maxToys;

    // Start is called before the first frame update
    void Start()
    {
        
        maxToys = LevelContoller.numberOfToys;
        player =FindFirstObjectByType<playerMovement>();
        powerUpSlider.maxValue = player.powerupDuration;
        toyCountText.text = "Toys: " + player.toyCount+"/"+maxToys;
    }

    // Update is called once per frame
    void Update()
    {
        toyCountText.text = "Toys: " + player.toyCount + "/"+maxToys;
        powerUpSlider.value = player.powerupRemaining;
    }
}
