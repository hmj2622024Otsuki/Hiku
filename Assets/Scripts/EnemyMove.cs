using System.IO;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
	[SerializeField] Transform Player;
	[SerializeField] float speed = 7.0f; // 敵の速度。初期値は6

	Animator animator;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		// アニメーションを再生できるようにする
		animator = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
		// プレイヤーが見つからない場合はreturn;で返す
		if (Player == null) return;

		// プレイヤーを追従する
		Vector3 direction = (Player.position - transform.position).normalized;
		direction.y = 0;

		if (direction != Vector3.zero)
		{
			Quaternion targetRotation = Quaternion.LookRotation(direction);
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed);
		}

		transform.position += direction * speed * Time.deltaTime;
    }
}
