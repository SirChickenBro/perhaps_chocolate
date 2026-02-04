using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ChocoBehavior : MonoBehaviour
{
    // 1
    public GameBehavior GameManager;

    void Start()
    {
        GameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();

    }
    void OnCollisionEnter(Collision collision)
    {
        // 2
        if (collision.gameObject.name == "Player")
        {
            // 3
            Destroy(this.transform.gameObject);
            // 4
            Debug.Log("Tasty!");

            GameManager.Items += 1;
        }
    }
}