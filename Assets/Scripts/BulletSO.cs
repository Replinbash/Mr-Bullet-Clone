using UnityEngine;

[CreateAssetMenu(fileName = "Bullet", menuName = "Bullet/Bullet Settings")]
public class BulletSO : ScriptableObject
{
	[Header("Bullet Settings")]
	[SerializeField] float _bulletSpeed;

	[Header("Bullet Spawn Settings")]
	[SerializeField] private int _initialSize;
	[SerializeField] private int _maxSize;
	[SerializeField] private float _releaseTime;	

	public int InitialSize { get => _initialSize; set => _initialSize = value; }	
	public int MaxSize { get => _maxSize; set => _maxSize = value; }	
	public float ReleaseTime { get => _releaseTime; set => _releaseTime = value; }
	public float BulletSpeed { get => _bulletSpeed; set => _bulletSpeed = value; }
	
}
