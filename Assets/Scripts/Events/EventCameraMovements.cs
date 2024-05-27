using UnityEngine;

public class EventCameraMovements : MonoBehaviour
{
    [SerializeField] private Transform _position;
    [SerializeField] private CameraMovements _cameraMovements;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<AreaActivator>())
        {
            _cameraMovements.MovePosition(_position.position);
        }
    }

}
