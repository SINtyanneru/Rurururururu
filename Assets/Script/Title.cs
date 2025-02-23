using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour {
	void Start() {
		
	}

	void Update() {
		
	}

	public void StartButton() {
		SceneManager.LoadScene("Main");
	}

	public void ExitButton() {
		#if UNITY_EDITOR
		//エディターでの動作
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		//ビルド後の動作
		Application.Quit();
		#endif
	}
}
