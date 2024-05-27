using UnityEngine;

public class ButtonStartGame : MonoBehaviour
{
    [SerializeField] private Menu _menu;
    [SerializeField] private Tutroial _tutroial;

    public void RunGame()
    {
        _menu.Hide();
        _tutroial.Run();
    }
}
