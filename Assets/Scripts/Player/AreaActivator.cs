using System.Collections;
using UnityEngine;

public class AreaActivator : MonoBehaviour
{
    public bool IsActive => _isActive;

    [SerializeField] private float _timeActive = 1f;

    private bool _isActive = false;

    public void OnArea()
    {
        if(_isActive == false)
        {
            StartCoroutine(DetainActive());
        }
    }

    private IEnumerator DetainActive()
    {
        _isActive = true;

        yield return new WaitForSeconds(_timeActive);

        _isActive = false;
    }
}
