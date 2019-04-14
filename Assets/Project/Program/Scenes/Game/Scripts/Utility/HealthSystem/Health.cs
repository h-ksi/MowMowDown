using UnityEngine;
using UniRx;

public class Health : IHealth
{
	public float MaxHP { get; private set; } = 100;

	public ReactiveProperty<float> HP { get; private set; } = new ReactiveProperty<float>();

	public float Rate
	{
		get
		{
			if (MaxHP <= 0)
				return 0f;
			return (float)HP.Value / (float)MaxHP;
		}
	}

	public Health(float maxHP = 100)
	{
		Init(maxHP);
	}

	/// <summary>
	/// Initialization
	/// </summary>
	public void Init(float maxHP = 100)
	{
		this.MaxHP = maxHP;
		this.HP = new ReactiveProperty<float>(MaxHP);
	}

	/// <summary>
	/// Subtract damage point from HP
	/// </summary>
	public void TakeDamage(float damage)
	{
		HP.Value -= damage;
	}

	/// <summary>
	/// Add heal point to HP
	/// </summary>
	public void Recovery(float heal)
	{
		HP.Value += heal;
	}
}
