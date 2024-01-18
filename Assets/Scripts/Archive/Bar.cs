using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections;

public class Bar : MonoBehaviour
{
    private UIInputActions _input;
    private Image _barSprite;
    private float _chargeAmountPerSec = 0.5f;
    private bool _isCharging = false;

    private void Start()
    {
        _input = new UIInputActions();
        _input.UI.Enable();
        _input.UI.Charge.started += Charge_started;
        _input.UI.Charge.canceled += Charge_canceled;

        _barSprite = GetComponent<Image>();
        if( _barSprite == null)
        {
            Debug.Log("Bar Sprite is null");
        }
    }

    private void Charge_started(InputAction.CallbackContext context)
    {
        _isCharging = true;
        StartCoroutine(ChargeBarRoutine());
    }

    private void Charge_canceled(InputAction.CallbackContext context)
    {
        _isCharging = false;
        StartCoroutine(ChargeBarRoutine());
    }

    IEnumerator ChargeBarRoutine()
    {
        while (_isCharging == true)
        {
            _barSprite.fillAmount += _chargeAmountPerSec * Time.deltaTime;
            yield return null;
        }

        while (_barSprite.fillAmount > 0)
        {
            _barSprite.fillAmount -= _chargeAmountPerSec * Time.deltaTime;
            yield return null;
        }
    }
}
