using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Image))]

public class CarMenu : ObjectActivation
{
    [SerializeField] private GameObject _buttons;
    [SerializeField] private GameObject _texts;

    [SerializeField] private TMP_Text _logText;

    [SerializeField] private Warehouse _warehouse;
    [SerializeField] private WorkbenchMenu _workbenchMenu;

    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    public override void Activation()
    {
        if (_workbenchMenu.GetIsOrden())
        {
            _image.enabled = true;
            _buttons.SetActive(true);
            _texts.SetActive(true);

            _logText.text = "";
        }
    }

    public void Exit()
    {
        _image.enabled = false;
        _buttons.SetActive(false);
        _texts.SetActive(false);
    }

    public void ButtonReplaceSparkPlug()
    {
        Replace(TypeDetail.SparkPlug);
    }

    public void ButtonReplaceBrake()
    {
        Replace(TypeDetail.Brake);
    }

    public void ButtonReplaceBumper()
    {
        Replace(TypeDetail.Bumper);
    }

    public void ButtonReplaceBattery()
    {
        Replace(TypeDetail.Battery);
    }

    private void Replace(TypeDetail type)
    {
        if (_warehouse.TakeDetail(type))
        {
            switch (type)
            {
                case TypeDetail.SparkPlug:
                    _logText.text = "Вы успешно заменили: Свеча зажигания";
                    break;
                case TypeDetail.Brake:
                    _logText.text = "Вы успешно заменили: Тормозные колотки";
                    break;
                case TypeDetail.Bumper:
                    _logText.text = "Вы успешно заменили: Бампер";
                    break;
                case TypeDetail.Battery:
                    _logText.text = "Вы успешно заменили: Аккумулятор";
                    break;
            }

            if (_workbenchMenu.GetTypeDetailOrden() == type)
            {
                _workbenchMenu.MadeOrden();
            }
        }
        else
        {
            _logText.text = "У вас нет данной детали";
        }
    }
}

