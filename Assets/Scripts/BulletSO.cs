using UnityEngine;

[CreateAssetMenu(fileName = "Bullet", menuName = "Bullet/Bullet Settings")]
public class BulletSO : ScriptableObject
{
	[Header("Bullet Settings")]
	[SerializeField] float _bulletSpeed;

	[Header("Bullet Audio Settings")]
	[SerializeField] private AudioClip _pistolShoot;
	[SerializeField] private AudioClip _groundHit;
	[SerializeField] private AudioClip _tntHit;

	[Header("Bullet Spawn Settings")]
	[SerializeField] private int _initialSize;
	[SerializeField] private int _maxSize;
	[SerializeField] private float _releaseTime;	

	public AudioClip PistolShoot { get => _pistolShoot; }
	public AudioClip GroundHit { get => _groundHit; }
	public AudioClip TntHit { get => _tntHit; }
	public int InitialSize { get => _initialSize; set => _initialSize = value; }	
	public int MaxSize { get => _maxSize; set => _maxSize = value; }	
	public float ReleaseTime { get => _releaseTime; set => _releaseTime = value; }
	public float BulletSpeed { get => _bulletSpeed; set => _bulletSpeed = value; }
	
}
