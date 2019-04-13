using UnityEngine;

public enum ATKMode
{
	Default,
	Pig,
	Sardine,
	HarpyCat
}

public abstract class WeaponEntity : MonoBehaviour
{
	public ATKMode _atkMode;
	public int _attackPoint;

	protected PlayerATKStatus _playerATKStatus;
	protected bool _isEquipped;
}
