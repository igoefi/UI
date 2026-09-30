using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject _aboutPanel;
    [SerializeField] private GameObject _buttons;
     
    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        Debug.Log("Игра начата");
    }

    public void OpenAbout()
    {
        _aboutPanel.SetActive(true);
        _buttons.SetActive(false);
    }

    public void CloseAbout()
    {
        _aboutPanel.SetActive(false);
        _buttons.SetActive(true);
    }
}
