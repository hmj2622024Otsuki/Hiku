using System.IO;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
	[SerializeField] Transform Player;
	[SerializeField] float speed = 7.0f;

	Animator animator;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		animator = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
		if (Player == null) return;

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
