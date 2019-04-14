using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;
using Zenject;

public class CameraSwitch : MonoBehaviour
{
	[SerializeField, Header ("Camera")]
	Camera _TPSCamera;
	[SerializeField] Camera _FPSCamera;

	[Inject] UserInput _userInput;
	List<Camera> CameraArray;

	void Start()
	{
		CameraArray = new List<Camera>();
		CameraArray.Add(_TPSCamera);
		CameraArray.Add(_FPSCamera);

		_userInput.CameraSwitch.Where(x => x).Subscribe(_ => 
		{
			_TPSCamera.enabled = !_TPSCamera.enabled;
			_FPSCamera.enabled = !_FPSCamera.enabled;
		});
	}

	public Camera GetActiveCamera()
	{
		return CameraArray.FirstOrDefault(camera => camera.enabled);
	}
}
