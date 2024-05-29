using System;
using UnityEngine;

public class Balance : MonoBehaviour
{
    public int Count => _count;

    [SerializeField] private int _count;

    public event Action<int> ScoreChanged;

    public void AddValue(int value)
    {
        _count += value;

        ScoreChanged?.Invoke(_count);
    }

    public bool TakeValue(int value)
    {
        if (_count >= value)
        {
            _count -= value;

            ScoreChanged?.Invoke(_count);

            return true;
        }
        else
        {
            return false;
        }
    }
}
