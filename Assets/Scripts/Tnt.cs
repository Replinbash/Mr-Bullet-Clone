using UnityEngine;

public class Tnt : MonoBehaviour
{
	[SerializeField] private ParticleSystem _explosionVFX;
	[SerializeField] private EnemySO _tntSettings;
	private BoxCollider2D _collider;
	private SpriteRenderer _spriteRenderer;

	private void Awake()
	{
		_collider = GetComponent<BoxCollider2D>();	
		_spriteRenderer = GetComponent<SpriteRenderer>();	
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
			Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
			if (rb != null)
			{
				Vector2 explodeDirection = rb.transform.position - transform.position;

				rb.bodyType = RigidbodyType2D.Dynamic;
				rb.AddForce(power * explodeDirection, ForceMode2D.Impulse);
			}
		}
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawSphere(transform.position, _tntSettings.TntRadius);
	}
}
