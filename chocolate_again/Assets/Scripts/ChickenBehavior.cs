using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenBehavior : MonoBehaviour
{

    private int _lives = 100;

    public int ChickenLives
    {
        get { return _lives; }
        private set
        {
            _lives = value;
            if (_lives <= 0)
            {
                Destroy(this.gameObject);
                Debug.Log("Enemy down.");
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            ChickenLives -= 1;
            Debug.Log("Critical hit!");
        }
    }

}
