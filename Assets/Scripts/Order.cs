using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order 
{
    public int Price { get; }
    public TypeDetail Detail { get; }
    public string Text { get; }

    private bool _isMade = false;

    private int _minDetail = 0;
    private int _maxDetail = 4;


    private int _minPrice = 100;
    private int _maxPrice = 250;

    public Order()
    {
        Price = Random.Range(_minPrice, _maxPrice);

        Text = "����� ��������: ";

        Detail = (TypeDetail)Random.Range(_minDetail, _maxDetail);

        switch (Detail)
        {
            case TypeDetail.SparkPlug:
                Text += "����� ���������";
                break;
            case TypeDetail.Brake:
                Text += "��������� �������";
                break;
            case TypeDetail.Bumper:
                Text += "������";
                break;
            case TypeDetail.Battery:
                Text += "�����������";
                break;
        }
    }

    public void Made()
    {
        _isMade = true;
    }

    public bool GetIsMade()
    {
        return _isMade;
    }
}
