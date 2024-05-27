using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Door : MonoBehaviour
{
    [SerializeField] private bool _isOpen;
    [SerializeField] private Rigidbody2D _passageRigidbody;
    [SerializeField] private bool _isPlayerCanOpen;
    [SerializeField] private float _timeOpen = 1.5f;

    private bool _isOpenTimer = false;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        SetStatus();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_isOpenTimer)
        {
            return;
        }

        if(_isPlayerCanOpen == true)
        {
            AreaActivator areaActivator;

            if (collision.TryGetComponent(out areaActivator))
            {
                if (areaActivator.IsActive)
                {
                    StartCoroutine(DetainOpen());

                    if (_isOpen)
                    {
                        _isOpen = false;
                    }
                    else
                    {
                        _isOpen = true;
                    }

                    SetStatus();
                }
            }
        }
    }


    public void SetIsPlayerCanOpen(bool isPlayerCanOpen)
    {
        _isPlayerCanOpen = isPlayerCanOpen;
    }

    private void SetStatus()
    {
        if (_isOpen)
        {
            Open(); 
        }
        else
        {
            Close();
        }
    }

    private void Open()
    {
        _animator.SetBool(DoorAnimatorData.Params.isOpen, true);
        _passageRigidbody.simulated = false;
    }

    private void Close()
    {
        _passageRigidbody.simulated = true;
        _animator.SetBool(DoorAnimatorData.Params.isOpen, false);
    }

    private IEnumerator DetainOpen()
    {
        _isOpenTimer = true;

        yield return new WaitForSeconds(_timeOpen);

        _isOpenTimer = false;
    }
}
