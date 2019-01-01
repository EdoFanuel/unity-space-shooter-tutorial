using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    //When object with collision no longer touch / inside this object do...
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
