using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumblingEffect : MonoBehaviour
{
    public float TumbleSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.angularVelocity = Random.insideUnitSphere * TumbleSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
