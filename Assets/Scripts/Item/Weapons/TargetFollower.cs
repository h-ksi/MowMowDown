using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TargetFollower : MonoBehaviour
{
	[SerializeField] GameObject _target;
	[SerializeField] float _speed;
	
	Vector3 _velocityVector;

	void Update()
	{
		_velocityVector = (_target.transform.position - transform.position) * _speed;
		transform.position += _velocityVector * Time.deltaTime;
	}
}
