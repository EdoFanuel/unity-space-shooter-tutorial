using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attach to VFX to remove them right after they spawn
public class CleanVFX : MonoBehaviour
{
    public float LifeTime;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, LifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
