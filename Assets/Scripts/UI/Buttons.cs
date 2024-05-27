using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(Animator))]

public class Buttons : MonoBehaviour
{
    [SerializeField] private ButtonMove _buttonMove;
    [SerializeField] private ButtonActivator _buttonActivator;

    private Animator _animation;

    private void Start()
    {
        _animation = GetComponent<Animator>();
    }

    public void SetHide(bool isHide)
    {
        _animation.SetBool(MenuAnimatorData.Params.isHide, isHide);
    }
}
