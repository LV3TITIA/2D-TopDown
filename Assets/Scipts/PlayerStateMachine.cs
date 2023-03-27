using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum PlayerState
{
    LOCOMOTION,
    SPRINT,
    ROLL
}

public class PlayerStateMachine : MonoBehaviour
{
    #region Exposed

    [Header("Roll Parameters")]
    [SerializeField]
    private float _rollDuration = 0.5f;
    [SerializeField]
    private float _rollSpeed = 6f;

    [Header("Move Speed")]
    [SerializeField]
    private float _runSpeed = 2f;

    [SerializeField]
    private float _sprintSpeed = 4f;

    [SerializeField]
    private AnimationCurve _rollCurve;


  

    #endregion

  

    #region Unity Lifecycle  
    void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _rb2d = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        TransitionToState(PlayerState.LOCOMOTION);
    }

    void Update()
    {
        OnStateUpdate();
    }

    private void FixedUpdate()
    {
        _rb2d.velocity = _direction * _currentSpeed;
    }

    #endregion

    #region Methodes

    private void OnStateEnter()
    {
        switch (_currentState)
        {
            case PlayerState.LOCOMOTION:
                _currentSpeed = _runSpeed;

                break;
            case PlayerState.SPRINT:

                _currentSpeed = _sprintSpeed;
                _animator.SetBool("IsSprinting", true);

                break;
            case PlayerState.ROLL:

                _currentSpeed = _rollSpeed;
                _animator.SetBool("IsRolling", true); 
                _endRollTime = Time.time + _rollDuration;
                break;
            default:
                break;
        }
    }

    private void OnStateUpdate()
    {
        switch (_currentState)
        {
            case PlayerState.LOCOMOTION:

                SetDirection();

                if (Input.GetButtonDown("Fire3"))
                {
                    TransitionToState(PlayerState.ROLL);
                }
                break;
            case PlayerState.SPRINT:

                SetDirection();

                if (Input.GetButtonUp("Fire3"))
                { 
                    TransitionToState(PlayerState.LOCOMOTION);
                }

                break;
            case PlayerState.ROLL:

                if( Time.time  > _endRollTime)
                {
                    if (Input.GetButton("Fire3"))
                    {
                        TransitionToState(PlayerState.SPRINT);

                    }
                    else
                    {
                        TransitionToState(PlayerState.LOCOMOTION);

                    }
                }
                break;
            default:
                break;
        } 
    }

    private void OnStateExit()
    {
        switch (_currentState)
        {
            case PlayerState.LOCOMOTION:
                break;
            case PlayerState.SPRINT:

                _animator.SetBool("IsSprinting", false);

                break;
            case PlayerState.ROLL:

                _animator.SetBool("IsRolling", false);
                break;
            default:
                break;
        }
    }

    private void TransitionToState(PlayerState ToState)
    {
        OnStateExit();
        _currentState = ToState;
        OnStateEnter();
    }

    private void SetDirection()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.y = Input.GetAxis("Vertical");

        _animator.SetFloat("MoveSpeedX", _direction.x);
        _animator.SetFloat("MoveSpeedY", _direction.y);
    }
    #endregion

    #region Private & Protected

    private PlayerState _currentState;
    private Animator _animator; 
    private float _endRollTime;

    private Rigidbody2D _rb2d;
    private Vector2 _direction = new Vector2();
    private float _currentSpeed;

    #endregion
}
