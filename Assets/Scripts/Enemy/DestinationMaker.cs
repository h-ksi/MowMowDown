using UnityEngine;

public class DestinationMaker : MonoBehaviour
{
	[SerializeField] float _circleRadius = 16f;
	//初期位置
	Vector3 _startPosition;
	//目的地
	Vector3 _destination;
	Transform _target;
 
	void Start () {
		//　初期位置を設定
		_startPosition = transform.position;
		SetDestination(transform.position);
	}
 
	//　ランダムな位置の作成
	public void CreateRandomPosition() {
		//　ランダムなVector2の値を得る
		var rand_destination = Random.insideUnitCircle * _circleRadius;
		//　現在地にランダムな位置を足して目的地とする
		SetDestination(_startPosition + new Vector3(rand_destination.x, 0, rand_destination.y));
	}
 
	//　目的地を設定する
	public void SetDestination(Vector3 position) {
		_destination = position;
	}
 
	//　目的地を取得する
	public Vector3 GetDestination() {
		return _destination;
	}
}
