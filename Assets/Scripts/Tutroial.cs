using System.Collections;
using UnityEngine;

public class Tutroial : MonoBehaviour
{
    [SerializeField] private WindowText _windowText;
    [SerializeField] private ButtonMove _buttonsMove;
    [SerializeField] private ButtonActivator _batttonActivator;
    [SerializeField] private Door _door;

    private Coroutine _workCoroutine;

    public void Run()
    {
        if(_workCoroutine == null)
        {
            _workCoroutine = StartCoroutine(Training());
        }
    }

    private IEnumerator Training()
    {
        _windowText.Open();

        while (_windowText.isOpen() == false)
        {
            yield return new WaitForFixedUpdate();
        }

        _windowText.SetText("Обучение: Для передвижения используйте стрелочки...");

        while (_windowText.isWorkShowText() == true)
        {
            yield return new WaitForFixedUpdate();
        }

        _buttonsMove.Activ();

        while (_buttonsMove.IsMoving == false)
        {
            yield return new WaitForFixedUpdate();
        }

        _windowText.SetText("Обучение: Для активации обьектов нажмите на кнопку виде руки...");

        while (_windowText.isWorkShowText() == true)
        {
            yield return new WaitForFixedUpdate();
        }

        _batttonActivator.Activ();

        yield return new WaitForSeconds(1f);
        
        _windowText.SetText("Задача: Откройте дверь и войдите в другую комнату.");

        while (_windowText.isWorkShowText() == true)
        {
            yield return new WaitForFixedUpdate();
        }

        yield return new WaitForSeconds(1f);

        _windowText.Close();

        _door.SetIsPlayerCanOpen(true);
    }
}
