using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toyPickup : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0,  1*rotationSpeed,0);
    }

    //void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("collided with " + other.tag);
    //    if (other.tag == "Player")
    //    {
    //        other.GetComponent<playerMovement>().toyCount++;
    //        Destroy(gameObject);
    //    }
    //}

}
