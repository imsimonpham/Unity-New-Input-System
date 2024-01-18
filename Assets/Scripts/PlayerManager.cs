using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] Player_1 _player_1;
    private GameInputs_1 _gameInput_1;

    private void Start()
    {
        InitializeInputs();
    }

    private void Update()
    {
        var move = _gameInput_1.Player.Movement.ReadValue<Vector2>();
        _player_1.Move(move);
    }

    void InitializeInputs()
    {
        _gameInput_1 = new GameInputs_1();
        _gameInput_1.Player.Enable();

        _gameInput_1.Player.Fire.performed += Fire_performed;
    }

    private void Fire_performed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        _player_1.Fire();
    }
}
