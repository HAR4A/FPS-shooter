using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookHead : MonoBehaviour
{
    [SerializeField] private float VerticalSens = 5.0f;
    [SerializeField] private float minimunVert = -45.0f;
    [SerializeField] private float maximumVert = 45.0f;
    private float _rotationX;
    private PlayerCharacter _playerCharacter;
    private CanvasController _canvasController;

    void Start()
    {
        _playerCharacter = GetComponentInParent<PlayerCharacter>();
        _canvasController = FindObjectOfType<CanvasController>(); 
    }

    void Update()
    {
        if (_playerCharacter.PlayerHealthGet() > 0 && !_canvasController.IsGamePaused()) 
        {
            _rotationX -= Input.GetAxis("Mouse Y") * VerticalSens;
            _rotationX = Mathf.Clamp(_rotationX, minimunVert, maximumVert);

            transform.localEulerAngles = new Vector3(_rotationX, 0, 0);
        }
    }

    

}
