using UnityEngine;

public class SyncCameraRotation : MonoBehaviour
{
	[SerializeField] CameraSwitch _cameraSwitch;

	void Update()
	{
		transform.rotation = _cameraSwitch.GetActiveCamera().transform.rotation;
	}
}
