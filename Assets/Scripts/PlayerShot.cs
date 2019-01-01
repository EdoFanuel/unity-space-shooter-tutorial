using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    public Transform SpawnPoint;
    public GameObject Bullet;
    public float FireRate;//Number of shots / second

    private float nextFireTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + 1.0f / (FireRate + Mathf.Epsilon);
            GameObject shotClone = Instantiate(Bullet, SpawnPoint.position, SpawnPoint.rotation);
            GetComponent<AudioSource>().Play();
        }
    }
}
