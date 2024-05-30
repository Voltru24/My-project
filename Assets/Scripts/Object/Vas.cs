using System.Collections;
using UnityEngine;

public class Vas : ObjectActivation
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private WorkbenchMenu _workbenchMenu;

    public override void Activation()
    {
        if (_workbenchMenu.GetThereIsOrder())
        {

        }
    }
}
