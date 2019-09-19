using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerGameOver : MonoBehaviour
{
    [SerializeField] private float _timeOutGameOver;
    [SerializeField] private UIChangeText _uIChangeText;

    public bool isGameOver
    {
        get => _timeOutGameOver>0;
    }

    public void PlayerHasEndGame()
    {
        _uIChangeText.FinishSetActive();
        this.enabled = false;
    }

    private void Update()
    {
        if (_timeOutGameOver > 0)
        {
            _timeOutGameOver -= Time.deltaTime;
            _uIChangeText.SetTextTimeIsGameOver(((int)_timeOutGameOver).ToString());
        }
        else
        {
            _uIChangeText.GameOverSetActive();
        }
    }
}
