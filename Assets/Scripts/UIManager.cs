using MrBullet.Player;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>   
{
	[SerializeField] private LevelSO _levelSettings;
	[SerializeField] private Transform _container;
	[SerializeField] private GameObject _defaultBullet, _goldenBullet;

	private void OnEnable()
	{
		PlayerController.ShootEvent += CheckBulletSprite;
	}

	private void OnDisable()
	{
		PlayerController.ShootEvent -= CheckBulletSprite;
	}

	void Start()
    {
		InitBulletSprite();
	}
 
	private void InitBulletSprite()
	{
		for (int i = 0; i < _levelSettings.DefaultBulletsAmmo; i++)
		{
			GameObject defaultBullet = Instantiate(_defaultBullet, _container.transform);
		}

		for (int i = 0; i < _levelSettings.GoldenBulletsAmmo; i++)
		{
			GameObject goldenBullet = Instantiate(_goldenBullet, _container.transform);
		}
	}

	private void CheckBulletSprite()
	{
		var bulletImage = _container.transform.GetChild(_levelSettings.AmmoCapacity - 1);
		bulletImage.GetComponentInChildren<Image>().enabled = false;
	}
}
