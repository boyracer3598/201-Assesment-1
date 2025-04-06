using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    public CatControlls controls;
    [SerializeField] GameObject Crown;
    InputAction move;
    InputAction jump;
    CharacterController catController;
    [SerializeField] float catSpeed = 5f;
    [SerializeField] float catRotationSpeed = 0.1f;
    Transform cameraTransform;
    Vector3 rawdirection;
    float currentVelocity=0;
    public bool isAllTrashCollected = false;
    [SerializeField] float pushForce = 5.0f;

    [HideInInspector] public int toyCount = 0;
    [HideInInspector] public int trashCount = 0;

    //for jump
    [SerializeField] float jumpHeight;
    [SerializeField] float jumpHeightDefult = 5.0f;
    [SerializeField] float jumpHeightPowerup = 1.5f;
    public float powerupDuration = 5.0f;
    [HideInInspector] public float powerupRemaining = 0.0f;


    //for gravity
    private float gravity = 9.8f;
    [SerializeField] float gravityMultiplier = 1.0f;
    private float verticalVelocity = 0.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        jumpHeight = jumpHeightDefult;
        catController = GetComponent<CharacterController>();
        cameraTransform = FindFirstObjectByType<Camera>().transform;
        Crown.SetActive(false);
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
    void FixedUpdate()
    {
        moveCat();
        applyGravity();
        powerupTimer();
        catJumps();
        enableCrown();

    }

    private void enableCrown(){
        if(isAllTrashCollected){
            Crown.SetActive(true);
        }
       
    }


    /// <summary>
    /// function count down the powerup timer and applies the powerup effect
    /// </summary>
    private void powerupTimer() {
        
        if (powerupRemaining > 0.0f){
            powerupRemaining -= Time.deltaTime;
            jumpHeight = jumpHeightDefult * jumpHeightPowerup;
            //Debug.Log("Powerup remaining: " + (int)powerupRemaining);
        }
        else{
            powerupRemaining = 0.0f;
            jumpHeight = jumpHeightDefult;
        }
    }
    /// <summary>
    /// funtion to maake the cat jump
    /// </summary>
    private void catJumps(){
        if(catController.isGrounded && jump.ReadValue<float>() > 0.0f)
        {
            verticalVelocity = jumpHeight;
        }
    }
    /// <summary>
    /// applies gravity to the cat, as the chartcter controller does not have gravity by default
    /// </summary>
    private void applyGravity(){
        if (catController.isGrounded&&verticalVelocity <0.0f){
            verticalVelocity = -1.0f;
        }else{
            verticalVelocity -= gravity * gravityMultiplier * Time.deltaTime;
        }
        catController.Move(new Vector3(0, verticalVelocity, 0) * Time.deltaTime);

    }


    /// <summary>
    /// moves the cat, using the input from the player and dircetion for camera rotation
    /// </summary>
    private void moveCat()
    {
        rawdirection = new Vector3(move.ReadValue<Vector2>().x, 0, move.ReadValue<Vector2>().y).normalized;

        if (rawdirection.magnitude > 0)
        {
            float TargetAngle = Mathf.Atan2(rawdirection.x, rawdirection.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, TargetAngle, ref currentVelocity, catRotationSpeed);
            Vector3 moveDir = Quaternion.Euler(0, smoothAngle, 0) * Vector3.forward;
            transform.rotation = Quaternion.Euler(0, smoothAngle, 0);

            catController.Move(moveDir * Time.deltaTime * catSpeed);

        }
    }

    /// <summary>
    /// function to push objects when colliding with them
    /// </summary>
    /// <param name="hit"></param>
    private void OnControllerColliderHit(ControllerColliderHit hit){
        if (hit.rigidbody != null) {
            Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize();

            hit.rigidbody.AddForce(forceDirection * pushForce, ForceMode.Impulse);
        }
        
        
    }


    private void OnTriggerEnter(Collider other)
    {

        //check if collecting a toy
        if (other.tag == "toy"){
            toyCount++;
            Destroy(other.gameObject);
        }
        else if (other.tag == "powerup"){
            powerupRemaining = powerupDuration;
            Destroy(other.gameObject);
        }else if(other.tag == "trash"){
            trashCount++;
            Debug.Log("wow Trash collected");
            Destroy(other.gameObject);
        }

    }

}
