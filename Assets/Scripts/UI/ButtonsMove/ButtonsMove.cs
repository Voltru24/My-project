using UnityEngine;
[RequireComponent(typeof(Animator))]

public class ButtonMove : MonoBehaviour
{
    [SerializeField] private PlayerMovement _player;
    public bool IsMoving => _isMoving;

    private int _horizontalMove;
    private bool _isMoving = false;
    private bool _isMove = false;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (_isMove)
        {
            _player.Move(_horizontalMove);
        }
    }

    public void Activ()
    {
        _animator.SetBool(ButtonMoveAnimatorData.Params.isActiv, true);
    }

    public void OnMove(int horizontal)
    {
        _horizontalMove = horizontal;
        _player.OnAnimatorRun();
        _isMove = true;
    }

    public void OffMove()
    {
        _horizontalMove = 0;
        _player.OffAnimatorRun();
        _isMove = false;

        if (_isMoving == false)
        {
            _isMoving = true;
        }
    }
}
