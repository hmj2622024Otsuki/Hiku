using UnityEngine;
using UnityEngine.InputSystem;

public class DogMove : MonoBehaviour
{
	[SerializeField] float speed = 7.0f;
	[SerializeField] float rotateSpeed = 250f;
	[SerializeField] GameObject Enemy;
	Animator animator;

	bool dead = false;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		if (dead == false)
		{
			Vector3 direction = Vector3.zero;
			// è„
			if (Keyboard.current.wKey.isPressed)
			{
				transform.position += transform.forward * speed * Time.deltaTime;
			}
			if (Keyboard.current.wKey.wasPressedThisFrame) { animator.SetBool("Run", true); }
			if (Keyboard.current.wKey.wasReleasedThisFrame) { animator.SetBool("Run", false); }

			// â∫
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

			// ç∂
			if (Keyboard.current.aKey.isPressed)
			{
				direction = Quaternion.Euler(0, -30, 0) * transform.forward;

				if (direction != Vector3.zero)
				{
					Quaternion targetRotation = Quaternion.LookRotation(direction);
					transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
				}
			}

			// âE
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

	private void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.CompareTag("Enemy"))
		{
			dead = true;
			animator.SetBool("Die", true);
		}
	}
}
