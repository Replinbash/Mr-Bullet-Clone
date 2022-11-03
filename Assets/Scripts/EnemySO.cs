using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/Enemy Settings")]
public class EnemySO : ScriptableObject
{
	[Header("Enemy Death Settings")]
	[SerializeField] private float _directionX;
	[SerializeField] private float _directionY;
	[SerializeField] private AudioClip _deathSound;

	[Header("TNT Damage Settings")]
	[SerializeField] private float _tntPower;
	[SerializeField] private float _tntRadius;

	public AudioClip DeathSound { get => _deathSound; }
	public float DirectionX { get => _directionX; set => _directionX = value; }
	public float DirectionY { get => _directionY; set => _directionY = value; }
	public float TntPower { get => _tntPower; set => _tntPower = value; }
	public float TntRadius { get => _tntRadius; set => _tntRadius = value; }
}
