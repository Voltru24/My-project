using UnityEngine;
[RequireComponent(typeof(Animator))]

public class StartMenu : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void Hide()
    {
        _animator.SetBool(MenuAnimatorData.Params.isHide, true);
    }
}
