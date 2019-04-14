using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
	Dead = 3,
	Idle = 0,
	Walk = 1,
	Run = 2,
	Born = 10,
	Knockback = 11,
	Attack01 = 20,
	Attack02 = 21,
	Attack03 = 22,
	Attack03_1 = 23
}

public class EnemyStateManager : MonoBehaviour
{
	

	[SerializeField] Animator _enemyAnimator;

	EnemyState _enemyState;

	public void SetState(EnemyState mode)
	{
		_enemyState = mode;

		switch (mode)
		{
			case EnemyState.Attack01:
				_enemyAnimator.SetTrigger(mode.ToString());
				break;
			case EnemyState.Walk:
				_enemyAnimator.SetFloat("Speed", Constants.ORC_WALK_SPEED);
				break;
			case EnemyState.Run:
				_enemyAnimator.SetFloat("Speed", Constants.ORC_RUN_SPEED);
				break;
			default:
				_enemyAnimator.SetInteger("EnemyState", (int)mode);
				break;
		}
	}
}
