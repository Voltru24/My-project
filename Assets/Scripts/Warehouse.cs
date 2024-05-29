using System;
using Unity.VisualScripting;
using UnityEngine;

public class Warehouse : MonoBehaviour
{
    private const int TypeDetailCount = 4;

    private int[] _details = new int[TypeDetailCount];


    public void AddDetail(TypeDetail type)
    {
        _details[(int)type]++;
    }

    public bool TakeDetail(TypeDetail type)
    {
        if (_details[(int)type] > 0)
        {
            _details[(int)type]--;

            return true;
        }

        return false;
    }

    public int GetCounteDetail(TypeDetail type)
    {
        return _details[(int)type];
    }
}

public enum TypeDetail
{
    SparkPlug = 0,
    Brake = 1,
    Bumper = 2,
    Battery = 3
}