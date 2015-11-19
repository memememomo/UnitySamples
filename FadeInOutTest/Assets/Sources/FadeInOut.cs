using UnityEngine;
using System.Collections;

using UnityEngine;
using System.Collections;

public class FadeInOut : MonoBehaviour
{
	public float fadeSpeed = 1.5f;

	bool sceneStarting = true;

	bool fading = false;

	public bool IsFinish {
		get;
		private set;
	}

	Color fadeColor;

	void Awake ()
	{
		GetComponent<GUITexture>().pixelInset = new Rect(0f, 0f, Screen.width, Screen.height);
		GetComponent<GUITexture> ().enabled = false;
	}

	void Start()
	{
		StartFadeIn ();
	}

	void Update ()
	{
		if(fading)
			Fade();
	}

	public void Hide()
	{
		GetComponent<GUITexture> ().enabled = false;
	}

	void Fade()
	{
		GetComponent<GUITexture> ().color = Color.Lerp (GetComponent<GUITexture> ().color, fadeColor, fadeSpeed * Time.deltaTime);
		if (fadeColor == Color.clear && GetComponent<GUITexture> ().color.a <= 0.05f) {
			GetComponent<GUITexture> ().color = Color.clear;
			GetComponent<GUITexture> ().enabled = false;
			IsFinish = true;
			fading = false;
			StartFadeout ();
		} else if (fadeColor == Color.black && GetComponent<GUITexture> ().color.a >= 0.95f) {
			IsFinish = true;
			fading = false;
			StartFadeIn ();
		}
	}

	public void StartFadeIn()
	{
		fading = true;
		IsFinish = false;
		GetComponent<GUITexture> ().color = Color.black;
		GetComponent<GUITexture> ().enabled = true;
		fadeColor = Color.clear;
	}

	public void StartFadeout()
	{
		fading = true;
		IsFinish = false;
		GetComponent<GUITexture> ().color = Color.clear;
		GetComponent<GUITexture> ().enabled = true;
		fadeColor = Color.black;
	}
}