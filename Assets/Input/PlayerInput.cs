using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private PlayerInputActions _input;

    private void Start()
    {
        _input = new PlayerInputActions();
        _input.Dog.Enable();
        _input.Dog.Bark.performed += Bark_performed;
        _input.Dog.Bark.canceled += Bark_canceled;
    }

    private void Bark_performed(InputAction.CallbackContext context)
    {
        Debug.Log("Barking...");
    }

    private void Bark_canceled(InputAction.CallbackContext context)
    {
        Debug.Log("Done Barking!");
    }
}
