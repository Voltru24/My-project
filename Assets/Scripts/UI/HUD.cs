using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[RequireComponent(typeof(Animator))]

public class HUD : MonoBehaviour
{
    private Animator _animation;

    private void Start()
    {
        _animation = GetComponent<Animator>();
    }
    public void Open()
    {
        _animation.SetBool(WindowTextAnimatorData.Params.isOpen, true);
    }
}
