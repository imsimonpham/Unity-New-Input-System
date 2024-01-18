using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
    private float _jumpForce = 300f;
    private Rigidbody _rb;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        if (_rb == null)
        {
            Debug.LogError("Rigidbody is null");
        }
    }

    void Update()
    {
        if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Force);
        }
    }
}
