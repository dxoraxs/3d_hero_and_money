using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugGameController : MonoBehaviour
{
    [SerializeField] PlayerMovement _player;
    private Vector3 _playerMovement;
    void Update()
    {
        _playerMovement = Vector3.zero;
        if (Input.GetButton("Horizontal"))
        {
            if (Mathf.Abs(Input.GetAxis("Horizontal"))> 0.6f)
                _playerMovement.x += 0.6f * (Input.GetAxis("Horizontal") < 0 ? -1 : 1);
            else
                _playerMovement.x += Input.GetAxis("Horizontal");
        }

        if (Input.GetButton("Vertical"))
        {
            if (Input.GetAxis("Vertical") < -0.3f)
                _playerMovement.z += -0.3f;
            else 
                _playerMovement.z += Input.GetAxis("Vertical");
        }
        //_player.RunToVector(_playerMovement);
    }
}
