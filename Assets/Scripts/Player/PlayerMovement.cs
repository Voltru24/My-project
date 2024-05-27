using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;


    private Rigidbody2D _rigidbody2d;
    private Animator _animator;

    private void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    public void Move(float horizontal)
    {
        if (horizontal != 0) 
        {
            Rotate(horizontal);

            _rigidbody2d.AddForce(_moveSpeed * Vector2.right * horizontal);
        }
    }

    public void OnAnimatorRun()
    {
        _animator.SetBool(PlayerAnimatorData.Params.isRun, true);
    }

    public void OffAnimatorRun()
    {
        _animator.SetBool(PlayerAnimatorData.Params.isRun, false);
    }

    private void Rotate(float horizontal) 
    {
        int degreeReversal;

        if (horizontal < 0)
        {
             degreeReversal = 180;
        }
        else
        {
            degreeReversal = 0;
        }

        transform.rotation = Quaternion.Euler(Vector2.up * degreeReversal);
    }
}
