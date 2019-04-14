using UnityEngine;
using UniRx;

public class EnemySearchForPlayer : MonoBehaviour
{
	public ReactiveProperty<bool> IsPlayerFound{get; private set;}
	Vector3 _playerPos;
	
	void Start()
	{
		IsPlayerFound = new ReactiveProperty<bool>(false);
	}
	
	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player")
		{
			Debug.Log("プレイヤー発見");
			IsPlayerFound.Value = true;
			_playerPos = col.transform.position;
		}
	}

	void OnTriggerExit()
	{
		IsPlayerFound.Value = false;
	}

	public Vector3 GetPlayerPosition()
	{
		return _playerPos;
	}
}
