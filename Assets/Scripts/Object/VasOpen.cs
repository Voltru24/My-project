using System.Collections;
using UnityEngine;

public class VasOpen : ObjectActivation
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _spriteOpen;
    [SerializeField] private WindowText _windowText;

    private Coroutine _workCoroutine;

    public override void Activation()
    {
        if (_workCoroutine == null)
        {
            _workCoroutine = StartCoroutine(ShowMessage());

            Open();
        }
    }

    private void Open()
    {
        _spriteRenderer.sprite = _spriteOpen;
    }

    private IEnumerator ShowMessage()
    {
        _windowText.Open();

        while (_windowText.isOpen() == false)
        {
            yield return new WaitForFixedUpdate();
        }

        _windowText.SetText("Задача: Видите данные в устройство.\n" +
            "На столе есть подсказка.");

        while (_windowText.isWorkShowText() == true)
        {
            yield return new WaitForFixedUpdate();
        }

        float timeShow = 2f;
        
        yield return new WaitForSeconds(timeShow);

        _windowText.Close();
    }
}
