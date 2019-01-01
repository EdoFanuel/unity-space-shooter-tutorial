using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject DeathVFX;
    private GameController gameController;

    private void Start()
    {
        GameObject controllerObject = GameObject.FindWithTag("GameController");
        if (controllerObject != null)
        {
            gameController = controllerObject.GetComponent<GameController>();
        }
        else
        {
            Debug.Log("Failed to find GameController object");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hostile")
        {
            Instantiate(DeathVFX, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(other.gameObject);
            gameController.GameOver();
        }
    }
}
