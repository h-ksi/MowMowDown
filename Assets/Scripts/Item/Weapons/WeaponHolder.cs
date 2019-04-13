using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using Zenject;

public class WeaponHolder : MonoBehaviour
{
	[SerializeField] PlayerATKStatus _playerATKStatus;

	[Inject] UserInput _userInput;


	void Awake()
	{

	}


	void Start()
	{
		_userInput.WeaponSwitch.Where(x => x).Subscribe(_ =>
		{
			_playerATKStatus.ChangeATKMode();
		});

		this.OnTriggerEnterAsObservable().Subscribe(other =>
		{
			if (other.tag == "Weapon")
			{

			}
		});

		this.UpdateAsObservable().Subscribe(_ =>
		{

		});
	}

	public void Attack()
	{
		switch (_playerATKStatus.SelectedATKMode)
		{
			case ATKMode.Default:

				break;
			case ATKMode.Pig:
				
				break;
			case ATKMode.Sardine:
				
				break;
			case ATKMode.HarpyCat:
				
				break;
		}

		// _lifeObject.ApplyDamage(_attackDamage);
	}
}
