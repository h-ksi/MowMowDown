using System;
using System.Collections;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Zenject;
using Yumineko.Damage;

public class EnemyAttack : MonoBehaviour
{
	[SerializeField] float _timeBetweenAttacks = 0.8f;
	[SerializeField] EnemyStateManager _enemyStateManager;

	[Inject] Player _player;

	HealthManager _playerHealth;

	//EnemyHealth enemyHealth;
	public ReactiveProperty<bool> IsPlayerInAttackableRange { get; private set; } = new ReactiveProperty<bool>(false);
	float _timer;


	void Awake()
	{
		_playerHealth = _player.GetComponentInChildren<HealthManager>();
		//enemyHealth = GetComponent<EnemyHealth>();
	}

	void Start()
	{
		this.UpdateAsObservable().Subscribe(_ =>
		{
			_timer += Time.deltaTime;

			if (_timer >= _timeBetweenAttacks && IsPlayerInAttackableRange.Value/* && enemyHealth.currentHealth > 0*/)
			{
				Attack();
			}

			// if(playerHealth.currentHealth <= 0)
			// {
			//     anim.SetTrigger ("PlayerDead");
			// }
		});
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			IsPlayerInAttackableRange.Value = true;
		}
	}


	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			IsPlayerInAttackableRange.Value = false;
		}
	}


	void Attack()
	{
		_timer = 0f;

		_enemyStateManager.SetState(EnemyState.Attack01);
		_playerHealth.TakeDamage(Constants.ORC_DEFAULT_ATK);

		// if(playerHealth.currentHealth > 0)
		// {
		//     playerHealth.TakeDamage (attackDamage);
		// }
	}

}
