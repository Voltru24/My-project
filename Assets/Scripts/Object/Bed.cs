using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bed : ObjectActivation
{
    //Говно код - нужно переписать

    private int _dayCount = 1;

    [SerializeField] private TMP_Text _textMeshPro;
    [SerializeField] private WorkbenchMenu _workbenchMenu;
    [SerializeField] private Balance _balance;
    [SerializeField] private GameObject _nextDay;

    private Coroutine _workCoroutine;

    public override void Activation()
    {
        if (_workCoroutine == null)
        {
            _workCoroutine = StartCoroutine(NextDay());
        }
    }

    private IEnumerator NextDay()
    {
        _dayCount++;

        _nextDay.SetActive(true);

        _balance.TakeValue(100);

        _workbenchMenu.ResetCarCount();

         yield return new WaitForSeconds(3f);

        _textMeshPro.text = "День: " + _dayCount;

        _nextDay.SetActive(false);

        _workCoroutine = null;
    }
}
