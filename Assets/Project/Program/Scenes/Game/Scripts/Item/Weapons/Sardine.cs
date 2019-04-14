using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class Sardine : WeaponEntity
{
	[SerializeField] TargetFollower _targetFollower;

	void Awake()
	{
		_isEquipped = false;
		_atkMode = ATKMode.Sardine;
		_attackPoint = Constants.BULLET_SARDINE;
	}

	void Start()
	{
		this.OnTriggerEnterAsObservable()
			.Where(collider => collider.tag == "Player" && !_isEquipped)
			.Subscribe(collider =>
			{
				_playerATKStatus = collider.GetComponentInChildren<PlayerATKStatus>();
				_playerATKStatus.Equip(_atkMode);

				_targetFollower.enabled = true;
				_isEquipped = true;
			}).AddTo(gameObject);
	}
}
