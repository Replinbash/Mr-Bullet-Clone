using UnityEngine;

[CreateAssetMenu(fileName ="Level", menuName ="Level/Create New Level Settings")]
public class LevelSO : ScriptableObject
{
	[Header("Number Of Ammo")]
	[SerializeField] private int _goldenBulletsAmmo;
	[SerializeField] private int _defaultBulletsAmmo;

	private int _ammoCapacity;
	public int GoldenBulletsAmmo { get => _goldenBulletsAmmo; }
	public int DefaultBulletsAmmo { get => _defaultBulletsAmmo; }
	public int AmmoCapacity { get => _ammoCapacity; set => _ammoCapacity = value; }
	public int CalculateAmmoCapacity() => _ammoCapacity = _goldenBulletsAmmo + _defaultBulletsAmmo;
}
