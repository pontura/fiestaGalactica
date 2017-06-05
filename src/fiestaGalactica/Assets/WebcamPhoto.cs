using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class WebcamPhoto : MonoBehaviour
{
	public Texture2D lastPhotoTexture;
	WebCamTexture webCamTexture;
	private Animation anim;

	public MeshRenderer rawImage;

	private bool photoTaken;
	private bool ready;

	void Start()
	{
		anim = GetComponent<Animation> ();
		lastPhotoTexture = null;
		webCamTexture = new WebCamTexture(WebCamTexture.devices[WebCamTexture.devices.Length-1].name, 800, 600, 12);

		if (webCamTexture.isPlaying)
			webCamTexture.Stop();
		else
			webCamTexture.Play();

		Vector3 scale = rawImage.transform.localScale;

		rawImage.transform.localScale = scale;
		rawImage.material.mainTexture = webCamTexture;
	}
	void Update()
	{

	}
	void Ready()
	{
		ready = true;
	}
	void OnDestroy()
	{
		webCamTexture.Stop();
	}
	public void TakePhoto()
	{
		photoTaken = true;
		lastPhotoTexture = new Texture2D(webCamTexture.width, webCamTexture.height);
		lastPhotoTexture.SetPixels(webCamTexture.GetPixels());
		lastPhotoTexture.Apply();
		webCamTexture.Stop();
		Events.OnPhotoTaken ();
		anim.Play ("ZoomOut");
	}
}