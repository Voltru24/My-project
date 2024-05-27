using UnityEngine;
[RequireComponent(typeof(Animator))]

public class ButtonActivator : MonoBehaviour
{
    [SerializeField] AreaActivator _areaActivator;
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void OnClick()
    {
        _areaActivator.OnArea();
    }

    public void Activ()
    {
        _animator.SetBool(ButtonMoveAnimatorData.Params.isActiv, true);
    }

}
