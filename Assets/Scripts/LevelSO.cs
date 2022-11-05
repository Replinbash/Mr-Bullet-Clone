using UnityEngine;

[CreateAssetMenu(fileName ="Level", menuName ="Level/Create New Level Settings")]
public class LevelSO : ScriptableObject
{
	[Header("Ammo Settings")]
	[SerializeField] private int _goldenBulletsAmmo;
	[SerializeField] private int _defaultBulletsAmmo;

	[Header("Win Text")]
	private string _oneStarText = "WELL DONE!";
	private string _twoStarText = "AWESOME!";
	private string _threeStarText = "FANTASTIC!"; 

	private int _ammoCapacity;
	public string OneStarText { get => _oneStarText;}
	public string TwoStarText { get => _twoStarText;}
	public string ThreeStarText { get => _threeStarText;}
	public int GoldenBulletsAmmo { get => _goldenBulletsAmmo; }
	public int DefaultBulletsAmmo { get => _defaultBulletsAmmo; }
	public int AmmoCapacity { get => _ammoCapacity; set => _ammoCapacity = value; }
	public int CalculateAmmoCapacity() => _ammoCapacity = _goldenBulletsAmmo + _defaultBulletsAmmo;
}
