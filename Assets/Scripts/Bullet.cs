using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

namespace MrBullet.Bullet
{
	public class Bullet : MonoBehaviour
	{
		[SerializeField] private BulletSO _bulletSettings;
		[SerializeField] private GameObject _prefab;

		private IObjectPool<Bullet> _bulletPool;
		private Rigidbody2D _rigidbody;
		private Vector2 _lastVelocity;


		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody2D>();
		}
		
		private void OnEnable()
		{
			StartCoroutine(nameof(ReleaseBullet), _bulletSettings.ReleaseTime);
		}

		private void OnDisable()
		{
			_rigidbody.velocity = Vector3.zero;
			_rigidbody.angularVelocity = 0f;
			_rigidbody.Sleep();
		}

		private void FixedUpdate()
		{
			_lastVelocity = _rigidbody.velocity;
		}

		public void SetPool(IObjectPool<Bullet> pool)
		{
			_bulletPool = pool;
		}

		private IEnumerator ReleaseBullet(int timer)
		{
			yield return new WaitForSeconds(timer);
			_bulletPool.Release(this);
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
			Vector2 surfaceNormal = collision.contacts[0].normal;
			_rigidbody.velocity = Vector2.Reflect(_lastVelocity, surfaceNormal);
		}
	}
}
