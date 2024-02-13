using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private float _horizontalSens = 5.0f;
    [SerializeField] private float _verticalSens = 5.0f;
    [SerializeField] private float _minVerticalAngle = -45.0f;
    [SerializeField] private float _maxVerticalAngle = 45.0f;
    [SerializeField] private bool _invertYAxis = false;

    private float _cameraVerticalAngle = 0f;
    private IControllable _controllable;
   
    private PlayerCharacter _playerCharacter;

    private float _rotationY = 0;
    private float _rotationX = 0;


    void Start()
    {
        _playerCharacter = GetComponentInParent<PlayerCharacter>();
    }



    private void Awake()
    {
        // TryGetComponent<>() отличается от GetComponent<>() тем,
        // что при его использовании не выделяется память для хранения переменной если компонент не найден

        TryGetComponent<IControllable>(out _controllable);

        if (_controllable == null)
        {
            throw new System.ArgumentException("IControllable is mission on " + gameObject.name);
        }
    }

    void Update()
    {
       LookVertical();
       LookHorizontal();

        //if (_playerCharacter.PlayerHealthGet() > 0)
        //{
           // _rotationY = transform.eulerAngles.y + Input.GetAxis("Mouse X") * _horizontalSens;
           // _rotationX -= Input.GetAxis("Mouse Y") * _verticalSens;
            //_rotationX = Mathf.Clamp(_rotationX, _minVerticalAngle, _maxVerticalAngle);

            //transform.localEulerAngles = new Vector3(_rotationX, 0, 0);
           // transform.eulerAngles = new Vector3(0, _rotationY, 0);
        //}
        //else
        //{

       // }
    }

    private void LookVertical()
    {
        _cameraVerticalAngle += Input.GetAxis("Mouse Y") * _verticalSens * (_invertYAxis ? 1f : -1f);
        _cameraVerticalAngle = Mathf.Clamp(_cameraVerticalAngle, _minVerticalAngle, _maxVerticalAngle);

        Vector3 verticalInput = new Vector3(_cameraVerticalAngle, 0, 0);

        _controllable.LookVertical(verticalInput);
    }

    private void LookHorizontal()                                                                 
    {
        Vector3 horizontsInput = new Vector3(0f, Input.GetAxis("Mouse X") * _horizontalSens, 0f); 

        _controllable.LookHorizontal(horizontsInput);                                             
    }

}
