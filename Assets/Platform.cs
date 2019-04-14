using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
	private Vector3 scale;
	public float speed = 2f;
	public Player player;
	private bool fall = false;
	public AudioClip clipAudio;
	public AudioSource clipSource;
	private void Start()
	{
		scale = transform.localScale;
		clipSource.clip = clipAudio;

	}
	private void Update()
	{
		//speed = player.speedRatio * 3f;

		//transform.Translate(Vector2.down * speed * Time.deltaTime);
	}
	void FixedUpdate()
	{
		//if (transform.localScale != scale)

		//	transform.localScale = Vector3.Lerp(transform.localScale, scale, 10f * Time.deltaTime);
		//else if(Mathf.Round(transform.localScale.x *10)/10 == 0.1)
		//{
		//	Destroy(gameObject);
		//}

		if (fall)
		{
			transform.Translate(Vector2.down * speed * Time.deltaTime);
		}
	}
	public void shrink()
	{


		scale = new Vector3(0.1f, 0.5f, 0.5f);

	}
	public void Fall()
	{
		clipSource.Play();


		fall = true;

	}
}
