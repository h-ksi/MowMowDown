using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class UserInput : MonoBehaviour
{
	// Singleton
	public static UserInput SingletonInstance { get; private set; }

	public ReactiveProperty<bool>[] MoveCmdArray { get; private set; } = new ReactiveProperty<bool>[6];

	// Commands
	public ReactiveProperty<bool> Forward { get; private set; } = new ReactiveProperty<bool>(false);
	public ReactiveProperty<bool> Backward { get; private set; } = new ReactiveProperty<bool>(false);
	public ReactiveProperty<bool> Left { get; private set; } = new ReactiveProperty<bool>(false);
	public ReactiveProperty<bool> Right { get; private set; } = new ReactiveProperty<bool>(false);
	
	public ReactiveProperty<bool> CanRun { get; private set; } = new ReactiveProperty<bool>(false);
	public ReactiveProperty<bool> Jump { get; private set; } = new ReactiveProperty<bool>(false);
	public ReactiveProperty<bool> Crouch { get; private set; } = new ReactiveProperty<bool>(false);
	
	public ReactiveProperty<bool> CameraSwitch { get; private set; } = new ReactiveProperty<bool>(false);
	public ReactiveProperty<bool> WeaponSwitch { get; private set; } = new ReactiveProperty<bool>(false);

	public ReactiveProperty<bool> Attack { get; private set; } = new ReactiveProperty<bool>(false);
	public ReactiveProperty<bool> Guard { get; private set; } = new ReactiveProperty<bool>(false);
	public ReactiveProperty<bool> Avoid { get; private set; } = new ReactiveProperty<bool>(false);
	public ReactiveProperty<bool> SpecialMove { get; private set; } = new ReactiveProperty<bool>(false);

	void Start()
	{
		SingletonInstance = this;

		// ユーザー入力
		this.UpdateAsObservable()
				.Subscribe(_ =>
			 {
					Forward.Value = Input.GetKey(KeyCode.W);
					Backward.Value = Input.GetKey(KeyCode.S);
					Left.Value = Input.GetKey(KeyCode.A);
					Right.Value = Input.GetKey(KeyCode.D);
					
					CanRun.Value = (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) ? true : false;
					Jump.Value = Input.GetKeyDown(KeyCode.Space);
					Crouch.Value = Input.GetKeyDown(KeyCode.C);

					CameraSwitch.Value = Input.GetKeyDown(KeyCode.T);
					WeaponSwitch.Value = Input.GetKeyDown(KeyCode.R);
					
					Attack.Value = Input.GetMouseButtonDown(0);
					Guard.Value = Input.GetKey(KeyCode.Z);
					Avoid.Value = Input.GetKeyDown(KeyCode.X);
					SpecialMove.Value = Input.GetKeyDown(KeyCode.Q);
				});

		// 値が変更されたらMoveCmdArrayの要素を更新
		Forward.Subscribe(_ => MoveCmdArray[0] = Forward);
		Backward.Subscribe(_ => MoveCmdArray[1] = Backward);
		Left.Subscribe(_ => MoveCmdArray[2] = Left);
		Right.Subscribe(_ => MoveCmdArray[3] = Right);
		CanRun.Subscribe(_ => MoveCmdArray[4] = CanRun);
		Jump.Subscribe(_ => MoveCmdArray[5] = Jump);
	}
}
