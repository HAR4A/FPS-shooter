using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookBody : MonoBehaviour
{
    [SerializeField] private float HorizontalSens = 5.0f;
    private PlayerCharacter _playerCharacter;
    private float _rotationY = 0;
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
            _rotationY = transform.eulerAngles.y + Input.GetAxis("Mouse X") * HorizontalSens;

            transform.eulerAngles = new Vector3(0, _rotationY, 0);
        }
    }
}
