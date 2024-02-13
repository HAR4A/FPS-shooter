using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMoveInput : MonoBehaviour
{
    [SerializeField] private float _speed = 6.0f;
    private IControllable _controllable;

    private void Awake()
    {
        TryGetComponent<IControllable>(out _controllable);

        if (_controllable == null)
        {
            throw new System.ArgumentException("IControllable is mission on " + gameObject.name);
        }
    }

    private void Update()
    {
        MoveInput();
    }

    private void MoveInput()                                            
    {
        float deltaX = Input.GetAxis("Horizontal") * _speed;           
        float deltaZ = Input.GetAxis("Vertical") * _speed;               

        Vector3 movement = new Vector3(deltaX, 0, deltaZ);              
        movement = Vector3.ClampMagnitude(movement, _speed);           
        movement *= Time.deltaTime;                                    
        movement = transform.TransformDirection(movement);

        _controllable.Move(movement);
    }


    // transform.TransformDirection(Vector3 direction) - Преобразует вектор из локальной системы координат в глобальную.
}
