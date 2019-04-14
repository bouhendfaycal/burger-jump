using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
	private SpriteRenderer mySpriteRenderer;
	public float movementSpeed = 2f;
	private Animator animator;
	Rigidbody2D rb;
	public float jumpForce = 10f;
	private float velocityY;
	public AudioClip clipAudio;
	public AudioSource clipSource;
	float movement = 0f;
	private int timeWait;
	private Vector2 velocity;
	public float score = 1;
	private List<int> oldPlatforms;
	private float FirstgravityScale;
	private float FirstjumpForce;
	public float speedRatio = 1;
	public int bonusJumps = 10;
	public Text bonusJumpsUI;

	// Use this for initialization
	void Start()
	{
		animator = GetComponent<Animator>();
		rb = GetComponent<Rigidbody2D>();
		mySpriteRenderer = GetComponent<SpriteRenderer>();
		oldPlatforms = new List<int>();
		clipSource.clip = clipAudio;


		bonusJumpsUI.text = bonusJumps.ToString();

		FirstgravityScale = rb.gravityScale;
		FirstjumpForce = jumpForce;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButton(0))
		{
			var touch = Input.mousePosition;
			if (touch.y < Screen.height / 3)
			{

				if (touch.x < Screen.width / 2)
				{
					movement = -1 * movementSpeed;
					mySpriteRenderer.flipX = true;
				}
				else if (touch.x > Screen.width / 2)
				{
					movement = movementSpeed;
					mySpriteRenderer.flipX = false;
				}
			}

		}
		else
		{
			movement = 0;
		}

	}

	void FixedUpdate()
	{
		velocity = rb.velocity;
		velocity.x = movement;
		rb.velocity = velocity;

	}


	void OnCollisionEnter2D(Collision2D collision)
	{
		Platform platform = collision.collider.GetComponent<Platform>();

		if (velocity.y <= 0f)
		{
			Vector2 velocity = rb.velocity;
			velocity.y = jumpForce;
			movement = 0;
			rb.velocity = velocity;
			animator.SetBool("isJumping", true);
			clipSource.Play();

			int contactId = platform.GetInstanceID();
			if (!oldPlatforms.Contains(contactId))
			{
				platform.shrink();
				oldPlatforms.Add(contactId);
				score++;
				speedRatio = 1 + (score / 2);

				//rb.gravityScale = FirstgravityScale * speedRatio;

				//jumpForce = FirstjumpForce * speedRatio;
				rb.gravityScale += .05f;

				jumpForce += .15f;


			}

		}
		else if (score >= 10)
			platform.Fall();

	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		animator.SetBool("isJumping", false);

	}

	void OnBecameInvisible()
	{
		Destroy(gameObject);
		SceneManager.LoadScene("menu");
	}

	public void bonusJump()
	{
		if (bonusJumps==0)
			return;
		bonusJumps--;
		Vector2 velocity = rb.velocity;
		velocity.y = jumpForce * 2;
		rb.velocity = velocity;
		bonusJumpsUI.text = bonusJumps.ToString();
	}

}
