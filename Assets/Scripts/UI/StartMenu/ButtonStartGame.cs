using UnityEngine;

public class ButtonStartGame : MonoBehaviour
{
    [SerializeField] private StartMenu _menu;
    [SerializeField] private Tutroial _tutroial;
    [SerializeField] private HUD _hud;

    [SerializeField] private Balance _balance;
    [SerializeField] private int _startBalance;

    public void RunGame()
    {
        _menu.Hide();
        _tutroial.Run();
        _hud.Open();
        _balance.AddValue(_startBalance);
    }
}
