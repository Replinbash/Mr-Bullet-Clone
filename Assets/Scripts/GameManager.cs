using UnityEngine;
using Game.Enemy;
using MrBullet.Player;

public class GameManager : Singleton<GameManager>
{
	[SerializeField] private LevelSO _levelSettings;
	private int _initBullets;

	private void OnEnable()
	{
		PlayerController.ShootEvent += CheckAmmo;
		Enemy.EnemyDeathEvent += CheckEnemy;
	}

	private void OnDisable()
	{
		PlayerController.ShootEvent -= CheckAmmo;
		Enemy.EnemyDeathEvent -= CheckEnemy;
	}

	private void Start()
	{
		_initBullets = _levelSettings.CalculateAmmoCapacity();
	}

	private void CheckAmmo()
	{
		_levelSettings.AmmoCapacity--;

		if (_levelSettings.AmmoCapacity == 0)
			Invoke("CheckEnemy", 3);
	}

	private void CheckEnemy()
	{
		var enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

		if (enemyCount <= 0)
		{			
			UIManager.Instance.WinScreen(_initBullets);
		}

		else if (enemyCount >= 0 && _levelSettings.AmmoCapacity == 0)
		{
			UIManager.Instance.LoseScreen();
		}
	}	

}
