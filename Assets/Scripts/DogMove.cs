using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DogMove : MonoBehaviour
{
	[SerializeField] float speed = 7.0f;
	[SerializeField] float rotateSpeed = 250f;
	[SerializeField] GameObject Enemy;
	[SerializeField] AudioClip DieSE;
	Animator animator;

	bool dead = false;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		// (二足歩行の)犬のアニメーションを再生できるようにする
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		if (dead == false)
		{
			Vector3 direction = Vector3.zero;

			// 前進
			if (Keyboard.current.wKey.isPressed)
			{
				transform.position += transform.forward * speed * Time.deltaTime;
			}
			if (Keyboard.current.wKey.wasPressedThisFrame) { animator.SetBool("Run", true); }
			if (Keyboard.current.wKey.wasReleasedThisFrame) { animator.SetBool("Run", false); }

			// 後退
			if (Keyboard.current.sKey.isPressed)
			{
				direction = Vector3.back;

				if (direction != Vector3.zero)
				{
					//	Quaternion targetRotation = Quaternion.LookRotation(direction);
					//	transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
				}
				transform.position += -transform.forward * speed * Time.deltaTime;
			}
			if (Keyboard.current.sKey.wasPressedThisFrame) { animator.SetBool("Run", true); }
			if (Keyboard.current.sKey.wasReleasedThisFrame) { animator.SetBool("Run", false); }

			// 左回転
			if (Keyboard.current.aKey.isPressed)
			{
				direction = Quaternion.Euler(0, -30, 0) * transform.forward;

				if (direction != Vector3.zero)
				{
					Quaternion targetRotation = Quaternion.LookRotation(direction);
					transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
				}
			}

			// 右回転
			if (Keyboard.current.dKey.isPressed)
			{
				direction = Quaternion.Euler(0, 30, 0) * transform.forward;

				if (direction != Vector3.zero)
				{
					Quaternion targetRotation = Quaternion.LookRotation(direction);
					transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
				}
			}
		}
	}

	// 敵に当たるとやられる
	private async void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.CompareTag("Enemy"))
		{
			// 死亡アニメーションを再生(敵に当たっただけで死ぬとかいうとてもか弱い存在なので…。)
			dead = true;
			animator.SetBool("Die", true);
			AudioSource.PlayClipAtPoint(DieSE, transform.position);

			// やられたら自動的にシーン遷移
			await Task.Delay(3000);
			SceneManager.LoadScene("GameScene");
		}
	}
}
