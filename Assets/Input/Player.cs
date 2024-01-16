using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private PlayerInputActions _input;
    private float _speed = 5f;

    private void Start()
    {
        _input = new PlayerInputActions();
        _input.Player.Enable();
    }


    private void Update()
    {
       // check the input readings
       var move = _input.Player.Movement.ReadValue<Vector2>();
       transform.Translate(new Vector3(move.x, 0, move.y) * Time.deltaTime * _speed);
    }
}

    

