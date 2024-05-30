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

    [SerializeField] private SpriteRenderer _carImage;

    private int _countCar;
    private int _minCountCar = 2;
    private int _maxCountCar = 6;

    private Order _order;

    private Image _image;

    private void Start()
    {
       _image = GetComponent<Image>();

        ResetCarCount();
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
        if (_countCar <= 0)
        {
            return;
        }


        if (_order == null)
        {
            _countCar--;

            _order = new Order();

            _carImage.enabled = true;

            ShowOrder();
        }
    }

    public bool GetThereIsOrder()
    {
        if (_order != null)
        {
            return true;
        }
        else 
        { 
            return false; 
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

                _carImage.enabled = false;

                ShowOrder();
            }
        }
    }

    public bool GetIsOrden()
    {
        if (_order != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public TypeDetail GetTypeDetailOrden()
    {
        return _order.Detail;
    }

    public void MadeOrden()
    {
        _order.Made();
    }

    public void RefuseOrder() 
    {
        _order = null;

        ShowOrder();
    }

    public void ResetCarCount()
    {
        _countCar = Random.Range(_minCountCar, _maxCountCar);
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
