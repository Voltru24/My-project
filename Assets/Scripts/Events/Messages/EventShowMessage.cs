using System.Collections;
using UnityEngine;

public class EventShowMessage : MonoBehaviour
{
    [SerializeField] private string _text;
    [SerializeField] private float _timeShow;
    [SerializeField] private WindowText _windowText;
    [SerializeField] private bool _showOnce;

    private Coroutine _workCoroutine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            if (_workCoroutine == null)
            {
                _workCoroutine = StartCoroutine(ShowMessage());
            }
        }
    }

    private IEnumerator ShowMessage()
    {
        _windowText.Open();

        while (_windowText.isOpen() == false)
        {
            yield return new WaitForFixedUpdate();
        }

        _windowText.SetText(_text);

        while (_windowText.isWorkShowText() == true)
        {
            yield return new WaitForFixedUpdate();
        }

        yield return new WaitForSeconds(_timeShow);

        _windowText.Close();

        if (_showOnce)
        {
            Destroy(gameObject);
        }
    }
}
