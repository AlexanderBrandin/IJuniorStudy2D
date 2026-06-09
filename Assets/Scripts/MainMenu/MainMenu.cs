using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string _gameSceneName;
    [SerializeField] private GameObject _authorsPanel;

    public void Play()
    {
        SceneManager.LoadScene(_gameSceneName);
    }

    public void OpenAuthors()
    {
        _authorsPanel.SetActive(true);
    }

    public void CloseAuthors()
    {
        _authorsPanel.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
