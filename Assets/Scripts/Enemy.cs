using System;
using UnityEngine;

namespace Game.Enemy
{
	public class Enemy : MonoBehaviour
	{
		[SerializeField] private EnemySO _enemySettings;
		private Rigidbody2D[] _rigidbody;

		public static event Action EnemyDeathEvent;

		private void Awake()
		{
			_rigidbody = GetComponentsInChildren<Rigidbody2D>();
		}

		private void Start()
		{
			foreach (var rb in _rigidbody)
			{
				rb.isKinematic = true;
			}
		}

		private void OnTriggerEnter2D(Collider2D collision)
		{
			if (collision.CompareTag("Limbs"))
				return;

			ApplyForce(collision);
			Death();
		}

		private void ApplyForce(Collider2D collision)
		{
			Vector2 direction = transform.position - collision.transform.position;
			foreach (var rb in _rigidbody)
			{
				rb.bodyType = RigidbodyType2D.Dynamic;
				rb.AddForce(new Vector2(direction.x > 0 ? _enemySettings.DirectionX : -_enemySettings.DirectionX,
				direction.y > 0 ? _enemySettings.DirectionY : -_enemySettings.DirectionY), ForceMode2D.Impulse);
			}
		}

		private void Death()
		{
			if (gameObject.CompareTag("Death"))
				return;

			gameObject.tag = "Death";
			EnemyDeathEvent?.Invoke();
		}
	}

}
