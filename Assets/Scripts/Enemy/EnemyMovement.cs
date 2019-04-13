// https://gametukurikata.com/program/enemychasechara
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UniRx;
using UniRx.Triggers;
using Zenject;

public class EnemyMovement : MonoBehaviour
{
	[SerializeField] float _observableRadius = 15f;
	[SerializeField] NavMeshAgent _agent;
	[SerializeField] float _waitTime = 5f;
	[SerializeField] Transform _enemyTransform;
	[SerializeField] Animator _enemyAnimator;
	[SerializeField] DestinationMaker _destinationMaker;
	[SerializeField] EnemyStateManager _enemyStateManager;
	[SerializeField] EnemyAttack _enemyAttack;

	[Inject] Player _player;

	bool _canAttack = true;
	bool _canIdle = true;
	ReactiveProperty<bool> IsArrived = new ReactiveProperty<bool>(false);
	float _arrivalRadius = 0.5f;
	float _attackInterval = 1.5f;
	bool _isPlayerFound = false;

	void Awake()
	{
		_destinationMaker.CreateRandomPosition();
		_agent.destination = _destinationMaker.GetDestination();
	}

	void Start()
	{	
		IsArrived.Where(x => x && !_isPlayerFound).Subscribe(_ =>
		{
			_enemyStateManager.SetState(EnemyState.Idle);

			Observable.Return(Unit.Default)
				.Delay(TimeSpan.FromSeconds(_waitTime))
				.Subscribe(__ =>
				{
					_destinationMaker.CreateRandomPosition();
					_agent.destination = _destinationMaker.GetDestination();
					_agent.speed = Constants.ORC_WALK_SPEED;
					_enemyStateManager.SetState(EnemyState.Walk);
				}).AddTo(gameObject);
		});

		this.UpdateAsObservable().Subscribe(_ =>
		{
			IsArrived.Value = Vector3.Distance(_enemyTransform.position, _agent.destination) < _arrivalRadius;

			if (_isPlayerFound && !_enemyAttack.IsPlayerInAttackableRange.Value)
			{
				_agent.destination = _player.transform.position;
				_agent.speed = Constants.ORC_RUN_SPEED;
				_enemyStateManager.SetState(EnemyState.Run);
			}
		}).AddTo(gameObject);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			_isPlayerFound = true;
		}
	}


	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			_isPlayerFound = false;
		}
	}

}
