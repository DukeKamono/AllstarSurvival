using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    private int _playerHealth;
    private float _playerSpeed;
     private bool _isGrounded;
     private string _playerName;
     private Vector2 _playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        _playerHealth = 100;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
