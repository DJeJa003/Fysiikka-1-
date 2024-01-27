using UnityEngine;
using UnityEngine.UI;

public class ChangeBackground : MonoBehaviour
{
    public Image backgroundImage;
    public Sprite newBackgroundImage;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            backgroundImage.sprite = newBackgroundImage;
        }
    }
}
