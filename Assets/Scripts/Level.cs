using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
	[SerializeField] private int _levelIndex;

	private Button _levelButton;
	private Image _image;
	private Color _lockTheLevel = Color.black;

	private void Awake()
	{
		_levelButton = GetComponent<Button>();
		_image = GetComponent<Image>();
	}

	private void Start()
	{
		if (PlayerPrefs.GetInt("Level", 1) >= _levelIndex)
		{
			_levelButton.onClick.AddListener(() => LoadLevel());
			
		}

		else
		{
			_image.color = _lockTheLevel;
		}

	}

	public void LoadLevel() => SceneManager.LoadScene(gameObject.name);
}
