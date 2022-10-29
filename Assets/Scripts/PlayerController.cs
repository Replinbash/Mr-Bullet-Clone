using UnityEngine;
using UnityEngine.SceneManagement;
using MrBullet.Bullet;

namespace MrBullet.Player
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] private BulletSO _bulletSettings;
		[SerializeField] private BulletSpawner _bulletSpawner;
		[SerializeField] private LineRenderer _line;
		[SerializeField] private GameObject _laser;
		[SerializeField] private Transform _initialFirePos, _endFirePos, _crosshair;

		private Transform _armPos;
		private Camera _cam;

		private bool OnAim => Input.GetMouseButton(0);
		private bool OnShoot => Input.GetMouseButtonUp(0);
		private bool OnRestart => Input.GetMouseButton(1);

		private void Awake()
		{
			_cam = Camera.main;
			_armPos = this.gameObject.transform.GetChild(0);
		}

		private void Start()
		{
			_laser.gameObject.SetActive(false);
		}

		void Update()
		{
			if (OnAim)
			{
				Aim();
			}

			if (OnShoot)
			{
				Shoot();
			}

			if (OnRestart)
			{
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}

		private void Aim()
		{
			_laser.gameObject.SetActive(true);

			// arm rotation
			Vector3 mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
			Vector2 direction = mousePos - _armPos.transform.position;
			float angle = Vector2.SignedAngle(Vector2.down, direction);
			_armPos.transform.eulerAngles = new Vector3(0, 0, angle);

			// laser position
			_line.SetPosition(0, _initialFirePos.position);
			_endFirePos.position = mousePos;
			_line.SetPosition(1, _endFirePos.position);

			// crosshair position
			_crosshair.transform.position = mousePos + (Vector3.forward * 10);
		}

		private void Shoot()
		{
			_laser.gameObject.SetActive(false);

			var tempBullet = _bulletSpawner.pool.Get();
			tempBullet.transform.position = _initialFirePos.position;
			//GameObject tempBullet = Instantiate(_bulletSettings.BulletPrefab, _initialFirePos.position, Quaternion.identity);
			Rigidbody2D rigidbody = tempBullet.GetComponent<Rigidbody2D>();
			rigidbody.AddForce(_initialFirePos.right * _bulletSettings.BulletSpeed, ForceMode2D.Impulse);
		}

	}
}

