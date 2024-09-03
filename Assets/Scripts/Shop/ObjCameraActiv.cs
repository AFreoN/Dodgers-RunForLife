using UnityEngine;

public class ObjCameraActiv : MonoBehaviour
{
    public GameObject depthCamera;

	void Start ()
    {
        depthCamera.SetActive(false);
        depthCamera.SetActive(true);
	}

    private void OnEnable()
    {
        depthCamera.SetActive(false);
        depthCamera.SetActive(true);
    }

}
