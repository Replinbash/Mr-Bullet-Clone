using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton <LevelManager>
{
	[SerializeField] private float _transitionTime;
	private Animator _transation;	

	private void Awake()
	{
		_transation = GetComponentInChildren<Animator>();
	}

	public void RestartLevel()
	{
		StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
	}

	public void ReturnToLevelMenu()
	{
		StartCoroutine(LoadLevel(0));
	}

	public void NextLevel()
	{
		StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
	}

	public IEnumerator LoadLevel(int levelIndex)
	{
		_transation.SetTrigger("StartFade");
		yield return new WaitForSeconds(_transitionTime);
		SceneManager.LoadScene(levelIndex);
	}

	public void UnlockNextLevel(int levelNumber)
	{
		if (levelNumber >= SceneManager.GetActiveScene().buildIndex)
		{
			PlayerPrefs.SetInt("Level", levelNumber + 1);
		}
	}
}
