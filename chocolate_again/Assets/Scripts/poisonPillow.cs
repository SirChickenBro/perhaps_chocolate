using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class poisonPillow : MonoBehaviour
{
    // 1
    public GameBehavior GameManager;

    void start()
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
            Debug.Log("You've encountered the Perilous Pillow of Poison");

            GameManager.HP -= 5;
        }
    }
}