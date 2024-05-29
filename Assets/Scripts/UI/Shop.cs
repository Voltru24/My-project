using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class Shop : ObjectActivation
{
    private Animator _animator;

    [SerializeField] private int _price;
    [SerializeField] private TMP_Text _textPrice;
    [SerializeField] private Balance _balance;
    [SerializeField] private Warehouse _warehouse;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        _textPrice.text = $"÷ена: {_price} руб.";
    }

    public override void Activation()
    {
        _animator.SetBool(WindowTextAnimatorData.Params.isOpen, true);
    }

    public void Close()
    {
        _animator.SetBool(WindowTextAnimatorData.Params.isOpen, false);
    }

    public void ButtonBuySparkPlug()
    {
        Buy(TypeDetail.SparkPlug);
    }

    public void ButtonBuyBrake()
    {
        Buy(TypeDetail.Brake);
    }

    public void ButtonBuyBumper()
    {
        Buy(TypeDetail.Bumper);
    }

    public void ButtonBuyBattery()
    {
        Buy(TypeDetail.Battery);
    }

    private void Buy(TypeDetail type)
    {
        if (_balance.TakeValue(_price))
        {
            _warehouse.AddDetail(type);
        }
    }
}
