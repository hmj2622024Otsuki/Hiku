using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class GameManager : MonoBehaviour
{
	[SerializeField] GameObject TimerText;

	float Timer = 30;
	static int TimerInitial = 30;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		// ゲームのフレームレートを設定する
		Application.targetFrameRate = 60;
	}

    // Update is called once per frame
    void Update()
    {
		// タイマー開始
		Timer -= Time.deltaTime;
		TimerText.GetComponent<TextMeshProUGUI>().text = "Time:" + Timer.ToString("F1");

		// Timerが0になった場合、リザルトシーンへ遷移する
		if (Timer < 0f)
		{
			Timer = 0;
		}
	}
}
