using UnityEngine;
using UnityEngine.InputSystem;

public class Ball : MonoBehaviour
{
    private PlayerInputActions _input;
    private float _jumpForce = 300f;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        if( _rb == null)
        {
            Debug.LogError("Rigidbody is null");
        }

        _input = new PlayerInputActions();
        _input.Ball.Enable();
        _input.Ball.Bounce.canceled += Bounce_canceled;
    }

    private void Bounce_canceled(InputAction.CallbackContext context)
    {
        Debug.Log(context.duration);
        float holdTime = (float)context.duration;
        if( holdTime < 0.5f )
        {
            holdTime = 0.5f;
        } else if (holdTime > 2f)
        {
            holdTime = 2f;
        }
        _rb.AddForce(new Vector3(0, 1, 0) * _jumpForce * holdTime, ForceMode.Force);
    }
}
