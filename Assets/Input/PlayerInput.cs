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
        _input.Dog.Walk.performed += Walk_performed;
        _input.Dog.Run.performed += Run_performed;
        _input.Dog.Run.canceled += Run_canceled;
        _input.Dog.Die.performed += Die_performed;
    }

    private void Die_performed(InputAction.CallbackContext context)
    {
        Debug.Log("Dying... " + context);
    }

    private void Run_performed(InputAction.CallbackContext context)
    {
        Debug.Log("Running... " + context);
    }

    private void Run_canceled(InputAction.CallbackContext context)
    {
        Debug.Log("Canceled Running... " + context);
    }

    private void Bark_performed(InputAction.CallbackContext context)
    {
        Debug.Log("Barking... " + context);
    }

    private void Walk_performed(InputAction.CallbackContext context)
    {
        Debug.Log("Walking... " + context);
    }
}
