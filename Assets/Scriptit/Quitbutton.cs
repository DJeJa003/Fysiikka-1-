using UnityEngine;
using UnityEngine.UI;

public class Quitbutton : MonoBehaviour
{
    private Button button;

    public void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(QuitGame);
        Debug.Log("QuitButton script is attached and listening for clicks");
    }

    public void QuitGame()
    {

        Debug.Log("Quitting the game...");

        Application.Quit();
    }
}
