using UnityEngine;

public class CameraSelector : MonoBehaviour
{
    public Camera cameraToActivate; // reference to the camera to activate

    void Start()
    {
        // disable all other cameras
        foreach (Camera camera in Camera.allCameras)
        {
            if (camera != cameraToActivate)
            {
                camera.enabled = false;
            }
        }

        // activate the MakihyppyKamera
        cameraToActivate.enabled = true;
    }
}
