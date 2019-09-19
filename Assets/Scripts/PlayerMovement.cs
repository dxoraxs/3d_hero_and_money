using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speedPlayer;
    [SerializeField] private Vector3 _rotationSpeed;
    [SerializeField] private Joystick variableJoystick;
    [SerializeField] private PlayerCoin _playerCoin;
    [SerializeField] private TimerGameOver _timerGameOver;
    private Animator _animation;
    private Vector3 _lastPosition;

    private PlayerState _stateAnimator
    {
        set { _animation.SetInteger("state", (int)value);}
    }

    private void Start()
    {
        _animation = transform.GetComponent<Animator>();
        _lastPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (!_timerGameOver.isGameOver) return;
        float distanceFromLastPosition = Vector3.Distance(_lastPosition, transform.position) * 10;
        SetAnimation(distanceFromLastPosition);
        _lastPosition = transform.position;

        if (Mathf.Abs(variableJoystick.Horizontal) > 0.6f)
            TranslateRun(0.6f * (variableJoystick.Horizontal < 0 ? -1 : 1), transform.right);
        else
            TranslateRun(variableJoystick.Horizontal, transform.right);

        if (variableJoystick.Vertical < -0.3f)
            TranslateRun(- 0.3f, transform.forward);
        else
            TranslateRun(variableJoystick.Vertical, transform.forward);
    }

    private void SetAnimation(float multiply)
    {
        if (Mathf.Abs(multiply) > 0.5f)
        {
            _stateAnimator = PlayerState.Run;
            return;
        }
        else if (Mathf.Abs(multiply) < 0.5f && Mathf.Abs(multiply) > 0.1f)
        {
            _stateAnimator = PlayerState.Walk;
            return;
        }
        else if (Mathf.Abs(multiply) < 0.1f)
        {
            _stateAnimator = PlayerState.Idle;
            return;
        }
    }

    private void TranslateRun(float multiply, Vector3 position)
    {
        transform.Translate(position * Time.deltaTime * multiply * _speedPlayer, Space.World);
    }

    public void RotationPlayer(int angleRotation)
    {
        Debug.Log(angleRotation);
        transform.Rotate(_rotationSpeed * angleRotation * Time.deltaTime);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.transform.tag == "Coin")
    //    {
    //        Destroy(collision.transform.parent.gameObject);
    //        _playerCoin.AddOneCoin();
    //    }
    //}

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Coin")
        {
            Destroy(collision.transform.parent.gameObject);
            _playerCoin.AddOneCoin();
        }
        if (collision.transform.tag == "Finish")
        {
            _timerGameOver.PlayerHasEndGame();
        }
    }
}

enum PlayerState
{
    Idle,
    Run,
    Walk
}