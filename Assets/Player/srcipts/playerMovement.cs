using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    public CatControlls controls;
    InputAction move;
    InputAction jump;
    CharacterController catController;
    [SerializeField] float catSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        catController = GetComponent<CharacterController>();
    }

    private void Awake()
    {
        controls = new CatControlls();
    }

    void OnEnable(){
        move = controls.Player.Move;
        jump = controls.Player.Jump;
        move.Enable();
        jump.Enable();
    }

    void OnDisable(){
        move.Disable();
        jump.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        catController.Move(new Vector3(move.ReadValue<Vector2>().x, 0, move.ReadValue<Vector2>().y) * Time.deltaTime * catSpeed);
    }
}
