using TMPro;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Image))]

public class WorkbenchMenu : ObjectActivation
{
    [SerializeField] private GameObject _buttons;
    [SerializeField] private GameObject _texts;

    [SerializeField] private TMP_Text _textSparkPlug;
    [SerializeField] private TMP_Text _textBrake;
    [SerializeField] private TMP_Text _textBumper;
    [SerializeField] private TMP_Text _textBattery;

    [SerializeField] private TMP_Text _textOrder;

    [SerializeField] private Warehouse _warehouse;
    [SerializeField] private Balance _balance;

    private Order _order;

    private Image _image;

    private void Start()
    {
      _image = GetComponent<Image>();
    }

    public override void Activation()
    {
        _image.enabled = true;
        _buttons.SetActive(true);
        _texts.SetActive(true);

        ShowDetails();
        ShowOrder();
    }

    public void Exit()
    {
        _image.enabled = false;
        _buttons.SetActive(false);
        _texts.SetActive(false);
    }

    public void ReceiveOrder()
    {
        if (_order == null)
        {
            _order = new Order();

            ShowOrder();
        }
    }


    public void PassOrder()
    {
        if (_order != null)
        {
            if (_order.GetIsMade())
            {
                _balance.AddValue(_order.Price);

                _order = null;

                ShowOrder();
            }
        }
    }

    public void RefuseOrder() 
    {
        _order = null;

        ShowOrder();
    }

    private void ShowDetails()
    {
        _textSparkPlug.text = $"Свеча зажигания: {_warehouse.GetCounteDetail(TypeDetail.SparkPlug)}";
        _textBrake.text = $"Тормозные колотки: {_warehouse.GetCounteDetail(TypeDetail.Brake)}";
        _textBumper.text = $"Бампер: {_warehouse.GetCounteDetail(TypeDetail.Bumper)}";
        _textBattery.text = $"Аккумулятор: {_warehouse.GetCounteDetail(TypeDetail.Battery)}";
    }

    private void ShowOrder()
    {
        if (_order == null)
        {
            _textOrder.text = "отсутствует";

            return;
        }

        _textOrder.text = _order.Text;
        _textOrder.text += "\nОплата: " + _order.Price;

        if (_order.GetIsMade())
        {
            _textOrder.text += "\nВыполнено";
        }
        else
        {
            _textOrder.text += "\nНе выполнено";
        }
    }
}
