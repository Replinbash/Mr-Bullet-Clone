using Game.Enemy;
using UnityEngine;

public class Tnt : MonoBehaviour
{
	[SerializeField] private ParticleSystem _explosionVFX;
	[SerializeField] private EnemySO _tntSettings;
	private BoxCollider2D _collider;
	private SpriteRenderer _spriteRenderer;
	private Enemy _enemy;

	private void Awake()
	{
		_collider = GetComponent<BoxCollider2D>();	
		_spriteRenderer = GetComponent<SpriteRenderer>();	
		_enemy = FindObjectOfType<Enemy>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		ExplosionDamage(transform.position, _tntSettings.TntRadius, _tntSettings.TntPower);
		_collider.enabled = false;
		_spriteRenderer.enabled = false;
	}

	void ExplosionDamage(Vector3 center, float radius, float power)
	{
		Collider2D[] hitColliders = Physics2D.OverlapCircleAll(center, radius);

		_explosionVFX.Play();

		foreach (Collider2D collider in hitColliders)
		{
			if (collider.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb))
			{
				Vector2 explodeDirection = rb.transform.position - transform.position;
				rb.bodyType = RigidbodyType2D.Dynamic;
				rb.AddForce(power * explodeDirection, ForceMode2D.Impulse);
				_enemy.Death();				
			}		
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(transform.position, _tntSettings.TntRadius);
	}
}
