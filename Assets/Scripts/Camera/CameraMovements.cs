using System.Collections;
using UnityEngine;

public class CameraMovements : MonoBehaviour
{
    private Coroutine _workCoroutine;
    [SerializeField] private float _speed;

    public void MovePosition(Vector3 position)
    {
        if(_workCoroutine != null)
        {
            StopCoroutine(_workCoroutine);
        }

        StartCoroutine(MovementCamera(position));
    }

    private IEnumerator MovementCamera(Vector3 position)
    {
        float epsilon = 0.01f;

        while (Vector3.Distance(transform.position, position) >= epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, position, _speed * Time.deltaTime);

            yield return new WaitForFixedUpdate();
        }
    }
}
