using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private PlayerInputActions _input;
    [SerializeField] private MeshRenderer _render;

    private float _rotSpeed = 200f;
    private float _driveSpeed = 10f;

    private bool _isDriving = false;
   
    private byte _r;
    private byte _b;
    private byte _g;
    private byte _a;

    private void Start()
    {
        _input = new PlayerInputActions();
        _input.Player.Enable();
        _input.Player.ChangeColor.performed += ChangeColor_performed;
        _input.Player.SwitchToDriving.performed += SwitchActionMap_performed;
        _input.Vehicle.SwitchToPlayer.performed += SwitchActionMap_performed;
    }

    void Update()
    {
        if (_isDriving)
        {
            _input.Player.Disable();
            _input.Vehicle.Enable();
        } else
        {
            _input.Player.Enable();
            _input.Vehicle.Disable();
        }
        Rotate();
        Drive();
    }

    private void SwitchActionMap_performed(InputAction.CallbackContext context)
    {
        _isDriving = !_isDriving;
    }


    private void ChangeColor_performed(InputAction.CallbackContext context)
    {
        _r = System.Convert.ToByte(Random.Range(0, 256));
        _b = System.Convert.ToByte(Random.Range(0, 256));
        _g = System.Convert.ToByte(Random.Range(0, 256));
        _a = System.Convert.ToByte(Random.Range(0, 256));
        _render.material.color = new Color32(_r, _b, _g, _a);
    }   

    private void Rotate()
    {
        var rotate = _input.Player.Rotate.ReadValue<float>();
        transform.Rotate(0f, rotate * Time.deltaTime * _rotSpeed, 0f);
    }

    private void Drive()
    {
        var drive = _input.Vehicle.Drive.ReadValue<Vector2>();
        transform.Translate(new Vector3(drive.x, 0, drive.y) * Time.deltaTime * _driveSpeed);
    }
}

    

