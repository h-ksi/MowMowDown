using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UniRx;
using UniRx.Triggers;

public class HealthManager : MonoBehaviour
{
	[SerializeField] HPGauge _hpGauge;

	[SerializeField] float _maxHP = 100f;

	[SerializeField, Header("Way of Release() after death")]
	AfterDeath _afetrDeath = default;
	[SerializeField] GameObject _body;

	[SerializeField, Header("Time from death until Release() is called")]
	float _deathWaitTime = 0.0f;

	[SerializeField, Header("UnityEvent called when dying")]
	UnityEvent Die = new UnityEvent();


	enum AfterDeath
	{
		Destory,
		Inactivate
	}


	Health _health = new Health();


	void Reset()
	{
		if (_hpGauge == null)
			_hpGauge = GetComponentInChildren<HPGauge>();
	}


	void OnEnable()
	{
		_health = new Health(_maxHP);

		if (_hpGauge != null)
			_hpGauge.SetMaxHP(_maxHP);
	}


	void Start()
	{
		// Die event
		_health.HP
			.First(hp => hp <= 0f)
			.Subscribe(hp =>
				Die.Invoke()
			);

		// HP gauge
		_health.HP
			.Where(_ => _hpGauge != null)
			.Subscribe(hp =>
				_hpGauge.ReflectOnSlider(hp)
			);

		// After death process
		Die.AsObservable()
			.Delay(TimeSpan.FromSeconds(_deathWaitTime))
			.Subscribe(_ =>
				Release()
			);
	}


	void Release()
	{
		if (_body == null)
			_body = gameObject;

		if (_afetrDeath == AfterDeath.Destory)
		{
			Destroy(_body);
		}
		else
		{
			_body.SetActive(false);
		}
	}

	/// <summary>
	/// Initialization
	/// </summary>
	public void Init(float maxHP = 100f)
	{
		_health.Init(maxHP);
	}

	/// <summary>
	/// Subtract damage point from HP
	/// </summary>
	public void TakeDamage(float damage)
	{
		_health.TakeDamage(damage);
	}

	/// <summary>
	/// Add heal point to HP
	/// </summary>
	public void Recovery(float heal)
	{
		_health.Recovery(heal);
	}
}
