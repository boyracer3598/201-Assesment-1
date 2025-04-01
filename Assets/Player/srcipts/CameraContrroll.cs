using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class CameraContrroll : MonoBehaviour
{
    public CatControlls controls;
    InputAction look;
    [SerializeField] Transform player;
    float offset;
    [SerializeField] float cameraSpeedX, cameraSpeedY;
    [SerializeField] float maxPitch, minPitch;
    float yaw, pitch;
    Vector3 cameraDir;
    // Start is called before the first frame update
    private void Awake()
    {
        controls = new CatControlls();
    }

    void OnEnable(){
        look = controls.Player.Look;
        look.Enable();
    }

    void OnDisable(){
        look.Disable();
    }


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        offset = transform.position.y - player.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        cameraDir = new Vector3(look.ReadValue<Vector2>().x, look.ReadValue<Vector2>().y, 0).normalized;
        yaw += cameraDir.x * cameraSpeedX * Time.deltaTime;
        pitch += cameraDir.y * cameraSpeedY * Time.deltaTime;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
        transform.rotation = Quaternion.Euler(pitch, yaw, 0);
        transform.position = player.transform.position + new Vector3(0, offset, 0);
        
    }
}
