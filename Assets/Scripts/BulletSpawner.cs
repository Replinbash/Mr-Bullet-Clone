using UnityEngine;
using UnityEngine.Pool;

namespace MrBullet.Bullet
{
	public class BulletSpawner : MonoBehaviour
	{
		[SerializeField] private Bullet _bulletPrefab;
		[SerializeField] private BulletSO _bulletSettings;

		public IObjectPool<Bullet> pool;	

		private void Awake()
		{
			pool = new ObjectPool<Bullet>
		   (
			   CreateBullet,
			   ActionOnGet,
			   ActionOnRelease,
			   ActionOnDestroy,
			   true,
			   _bulletSettings.InitialSize,
			   _bulletSettings.MaxSize
		   );
		}

		private Bullet CreateBullet()
		{
			Bullet bullet = Instantiate(_bulletPrefab);
			bullet.SetPool(pool);
			return bullet;
		}

		private void ActionOnGet(Bullet bullet) => bullet.gameObject.SetActive(true);		
		private void ActionOnRelease(Bullet bullet) => bullet.gameObject.SetActive(false);		
		private void ActionOnDestroy(Bullet bullet) => Destroy(bullet.gameObject);	
	}

}
