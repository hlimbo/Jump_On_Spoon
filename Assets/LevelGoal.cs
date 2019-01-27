using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class LevelGoal : MonoBehaviour
{
    GameManager gm;
    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<RigidbodyFirstPersonController>())
            gm.LoadNextScene();
        Debug.Log("Triggered");
    }
}
