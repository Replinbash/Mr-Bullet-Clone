using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : Singleton <MenuManager>
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

	public IEnumerator LoadLevel(int levelIndex)
	{
		_transation.SetTrigger("StartFade");
		yield return new WaitForSeconds(_transitionTime);
		SceneManager.LoadScene(levelIndex);
	}
}
