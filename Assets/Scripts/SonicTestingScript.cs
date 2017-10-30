using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonicTestingScript : MonoBehaviour {

	public float velocidadMax = 10f;
	bool mirandoDerecha = true;
	Rigidbody2D rigi;
	Animator anim;

	// Use this for initialization
	void Start () {
		rigi = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float move = Input.GetAxis ("Horizontal");

		anim.SetFloat ("Velocidad", Mathf.Abs (move));

		rigi.velocity = new Vector2 (move * velocidadMax, rigi.velocity.y);

		if (move > 0 && !mirandoDerecha) {
			GetComponent<SpriteRenderer> ().flipX = false;
			mirandoDerecha = true;
		} else if (move < 0 && mirandoDerecha) {
			GetComponent<SpriteRenderer> ().flipX = true;
			mirandoDerecha = false;
		}

	}

	void Girar(){
		mirandoDerecha = !mirandoDerecha;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
