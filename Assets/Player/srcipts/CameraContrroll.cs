using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class CameraContrroll : MonoBehaviour
{
    public CatControlls controls;
    InputAction look;
    [SerializeField] Transform player;
    Vector3 offset;
    [SerializeField] float camSpeed = 100f;
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
        
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;
        transform.Rotate(new Vector3(look.ReadValue<Vector2>().y, look.ReadValue<Vector2>().x, 0)*Time.deltaTime*camSpeed);
    }
}
