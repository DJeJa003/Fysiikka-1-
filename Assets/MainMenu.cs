using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReturnToMainMenuButtonScript : MonoBehaviour
{
    [SerializeField] private Button returnToMainMenuButton;
    [SerializeField] private string mainMenuSceneName;

    private void Start()
    {
        returnToMainMenuButton.onClick.AddListener(ReturnToMainMenu);
    }

    private void ReturnToMainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
