using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float Speed;
    public float Tilt;
    public Boundary Boundary;

    //FixedUpdate could be called 0, 1, or more / frame based on physics fps
    private void FixedUpdate()
    {
        float movHorizontal = Input.GetAxis("Horizontal");
        float movVertical = Input.GetAxis("Vertical");

        Rigidbody rigidBody = GetComponent<Rigidbody>();
        if (Input.GetButton("Focus"))
        {
            Debug.Log("LeftShift pressed");
            rigidBody.velocity = new Vector3(movHorizontal, 0, movVertical) * (Speed / 3.0f);
        }
        else
        {
            Debug.Log("LeftShift not pressed");
            rigidBody.velocity = new Vector3(movHorizontal, 0, movVertical) * Speed;
        }
        rigidBody.position = new Vector3
        (
            Mathf.Clamp(rigidBody.position.x, Boundary.LeftBorder, Boundary.RightBorder), 
            0, 
            Mathf.Clamp(rigidBody.position.z, Boundary.BottomBorder, Boundary.TopBorder)
        );
        rigidBody.rotation = Quaternion.Euler(0, 0, rigidBody.velocity.x * -Tilt);
    }
}

[System.Serializable]
public class Boundary
{
    public float LeftBorder, RightBorder, TopBorder, BottomBorder;
}
