using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogController : MonoBehaviour
{

    //Возможно удаление
    [SerializeField] private List<string> _texts;

    [SerializeField] private WindowText _windowText;

 
    private void Start()
    {
        StartCoroutine(BeginningDialog());
    }

    private IEnumerator BeginningDialog()
    {
        yield return new WaitForSeconds(2);

        _windowText.Open();

        while (_windowText.isOpen() == false)
        {
            yield return new WaitForFixedUpdate();
        }

        _windowText.SetText(_texts[0]);
    }

}
