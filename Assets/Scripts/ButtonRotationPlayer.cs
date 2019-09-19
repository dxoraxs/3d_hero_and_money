using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonRotationPlayer : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private int _turningSide;
    private bool _onClickButton = false;

    private void Update()
    {
        if (Input.touches.Length > 0 && _onClickButton)
        {
            _player.RotationPlayer(_turningSide);
        }
    }
        
    public void OnPointerDown(PointerEventData eventData)
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        _onClickButton = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _onClickButton = false;
    }
}
