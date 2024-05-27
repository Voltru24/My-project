using Unity.VisualScripting;
using UnityEngine;

public class EventActivator : MonoBehaviour
{
    [SerializeField] private ObjectActivation _objectActivation;


    private void OnTriggerStay2D(Collider2D collision)
    {
        AreaActivator areaActivator;

        if (collision.TryGetComponent(out areaActivator))
        {
            if (areaActivator.IsActive)
            {
                _objectActivation.Activation();

                Destroy(gameObject);
            }
        }
    }
}
