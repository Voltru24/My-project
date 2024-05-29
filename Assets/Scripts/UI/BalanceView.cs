using TMPro;
using UnityEngine;

public class BalanceView : MonoBehaviour
{
    [SerializeField] private Balance _balance;
    [SerializeField] private TMP_Text _viewText;

    private void OnEnable()
    {
        _balance.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _balance.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int vaule)
    {
        _viewText.text = $"Баланс: {vaule} руб.";
    }
}
