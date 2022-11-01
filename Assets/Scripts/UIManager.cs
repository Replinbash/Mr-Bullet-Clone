using UnityEngine;
using MrBullet.Player;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class UIManager : Singleton<UIManager>
{
	[SerializeField] private LevelSO _levelSettings;

	[Header("Bullet Sprite")]
	[SerializeField] private Transform _container;
	[SerializeField] private GameObject _defaultBullet, _goldenBullet;

	[Header("Win Screen")]
	[SerializeField] private Text _winText;
	[SerializeField] private GameObject _winPanel;
	[SerializeField] private Image[] _stars;
	[SerializeField] private Sprite shineStar, darkStar;

	[Header("Lose Screen")]
	[SerializeField] private GameObject _losePanel;

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
			Instantiate(_defaultBullet, _container.transform);
		}

		for (int i = 0; i < _levelSettings.GoldenBulletsAmmo; i++)
		{
			Instantiate(_goldenBullet, _container.transform);
		}
	}

	private void CheckBulletSprite()
	{
		var bulletImage = _container.transform.GetChild(_levelSettings.AmmoCapacity - 1);
		bulletImage.GetComponentInChildren<Image>().enabled = false;
	}

	public bool IsMouseOverUI() => EventSystem.current.IsPointerOverGameObject();

	public void LoseScreen()
	{
		_losePanel.gameObject.SetActive(true);
		StartCoroutine(PanelEffect(_losePanel, false));
	}
	
	public void WinScreen(int initBullets)
	{
		_winPanel.SetActive(true);
		StartCoroutine(PanelEffect(_winPanel, true));

		var average = initBullets / 2;
		var usedBullets = initBullets - _levelSettings.AmmoCapacity;

		if (usedBullets <= _levelSettings.GoldenBulletsAmmo)
		{
			_winText.text = _levelSettings.ThreeStarText.ToString(); 
			Stars(3);
		}

		else if (_levelSettings.AmmoCapacity >= average)
		{
			_winText.text = _levelSettings.TwoStarText.ToString();
			Stars(2);
		}

		else if (_levelSettings.AmmoCapacity <= average)
		{
			_winText.text = _levelSettings.OneStarText.ToString(); 
			Stars(1);
		}
	}

	private void Stars(int star)
	{
		switch (star)
		{
			case 3:
				for (int i = 0; i < _stars.Length; i++)
				{
					_stars[i].sprite = shineStar;
				}
				break;

			case 2:
				for (int i = 0; i < _stars.Length; i++)
				{
					if (i == 2)
					{
						_stars[2].sprite = darkStar;
						continue;
					}					
					_stars[i].sprite = shineStar;					
				}
				break;

			case 1:
				for (int i = 0; i < _stars.Length; i++)
				{		
					if (i == 0)
					{
						_stars[0].sprite = shineStar;
						continue;
					}
					_stars[i].sprite = darkStar;
				}
				break;
		}
	}

	private IEnumerator PanelEffect(GameObject panel, bool isWin)
	{
		if (isWin)
		{
			yield return new WaitForSeconds(1f);		
			if (panel.TryGetComponent<CanvasGroup>(out CanvasGroup fade))
			{
				if (fade != null)
				{
					fade.DOKill();
				}

				fade.DOFade(1, 2f);
			}
		}
		
		else
		{
			panel.transform.DOMoveY(360f, 1f);
		}
	}
}
