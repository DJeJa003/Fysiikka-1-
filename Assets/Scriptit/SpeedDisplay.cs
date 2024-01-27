using UnityEngine;
using TMPro;

public class SpeedDisplay : MonoBehaviour
{
    [SerializeField]
    public GameObject skiJumper;
    [SerializeField]
    public TextMeshProUGUI speedText;

    void Update()
    {
        float speed = skiJumper.GetComponent<Rigidbody>().velocity.magnitude;
        speedText.text = "Speed: " + speed.ToString("F1") + " m/s";
    }
}
