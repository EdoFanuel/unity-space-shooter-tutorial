using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactReaction : MonoBehaviour
{
    public GameObject ExplosionVFX;
    public int ScoreValue;

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
        if (other.tag == "Boundary")
        {
            return;
        }
        Destroy(other.gameObject);
        Destroy(gameObject);
        Instantiate(ExplosionVFX, transform.position, transform.rotation);
        gameController.IncrementScore(ScoreValue);
    }
}
