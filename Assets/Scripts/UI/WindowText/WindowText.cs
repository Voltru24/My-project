using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class WindowText : MonoBehaviour
{
    private const string IdleOpen = nameof(IdleOpen);

   [SerializeField] private TMP_Text _textMeshPro;
   [SerializeField] private float _speedShowText;

    private Animator _animator;

    private Coroutine _workCoroutine;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void StopShowText()
    {
        if(_workCoroutine != null)
        {
            StopCoroutine(_workCoroutine);

            _workCoroutine = null;
        }
    }

    public void SetText(string text)
    {
        _workCoroutine = StartCoroutine(ShowText(text));
    }

    public bool isOpen()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName(IdleOpen))
        {
            return true;
        }

        return false;
    }

    public bool isWorkShowText()
    {
        if (_workCoroutine != null)
        {
            return true;
        }

        return false;
    }

    public void Open()
    {
        _textMeshPro.text = "";

        _animator.SetBool(WindowTextAnimatorData.Params.isOpen, true);
    }

    public void Close()
    {
        _animator.SetBool(WindowTextAnimatorData.Params.isOpen, false);
    }

    private IEnumerator ShowText(string text)
    {
        _textMeshPro.text = "";

        for (int i = 0; i < text.Length; i++)
        {
            _textMeshPro.text += text[i];
            
            yield return new WaitForSeconds(_speedShowText);
        }

        StopShowText();
    }
}
