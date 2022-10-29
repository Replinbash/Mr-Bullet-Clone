using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/Enemy Settings")]
public class EnemySO : ScriptableObject
{
	[Header("Enemy Settings")]
	[SerializeField] private int _mass;

	[Header("Enemy Fall Settings")]
	[SerializeField] private float _directionX;
	[SerializeField] private float _directionY;

	[Header("TNT Take Damage")]
	[SerializeField] private float _tntPower;
	[SerializeField] private float _tntRadius;

	public int Mass { get => _mass; set => _mass = value; }
	public float DirectionX { get => _directionX; set => _directionX = value; }
	public float DirectionY { get => _directionY; set => _directionY = value; }
	public float TntPower { get => _tntPower; set => _tntPower = value; }
	public float TntRadius { get => _tntRadius; set => _tntRadius = value; }
}
