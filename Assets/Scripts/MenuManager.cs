using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : Singleton<MenuManager>
{
    [SerializeField] private CanvasGroup _fadeImage;

    public void RestartScene()
    {
        //_fadeImage.DOFade(1, 1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		//_fadeImage.DOFade(0, 1f);
	}
}
