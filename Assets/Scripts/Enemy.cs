using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace Game.Enemy
{
	public class Enemy : MonoBehaviour
	{
		[SerializeField] private EnemySO _enemySettings;
		[SerializeField] private GameObject _bloodVFX;
		private Rigidbody2D[] _rigidbody;
		private Vector3 _direction;

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

		private void ApplyForce(Collider2D target)
		{
			_direction = target.transform.position - transform.position;
			_direction = _direction.normalized;

			foreach (var rb in _rigidbody)
			{
				rb.bodyType = RigidbodyType2D.Dynamic;				

				rb.AddForce(new Vector2(_direction.x > 0 ? -_enemySettings.DirectionX : _enemySettings.DirectionX, 
				_enemySettings.DirectionY), ForceMode2D.Impulse);
			}
		}

		private void Death()
		{
			if (gameObject.CompareTag("Death"))
				return;

			Quaternion rotation = Quaternion.Euler(new Vector2(0f, _direction.x > 0 ? -90f : 90f));
			Instantiate(_bloodVFX, transform.position, rotation, transform);

			gameObject.tag = "Death";
			EnemyDeathEvent?.Invoke();
		}		
	}
}
