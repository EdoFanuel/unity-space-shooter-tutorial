using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = transform.forward * Speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
