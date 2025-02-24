using System.Collections;
using UnityEngine;

public class ChuujaCycle : MonoBehaviour {
	public Light Taijou;
	public int GameTime = 720;      //←マックスは1439(24*60-1)

	void Start() {
		StartCoroutine(UpdateTime());
	}

	IEnumerator UpdateTime() {
		while (true) {
			//↓ゲーム内1分=現実1秒
			yield return new WaitForSeconds(1);
			GameTime = (GameTime + 1) % 1440;

			//太陽をブン回せ(1年の進捗を求める時に使った式)
			float TaijouAngle = (GameTime / 1440f) * 360f;
			Taijou.transform.rotation = Quaternion.Euler(TaijouAngle - 90, -30, 0);
		}
	}

	public string GetTimeText() {
		return (GameTime / 60) + ":" + (GameTime % 60);
	}
}
