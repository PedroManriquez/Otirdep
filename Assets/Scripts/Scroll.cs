using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {

	public float velocidad = 0f;
	private bool enMovimiento = false;
	private float tiempoInicio = 0f;
	private KeyCode [] directions = new KeyCode[4];
	//public Renderer rend;

	// Use this for initialization
	void Start () {
		/*rend = GetComponent<Renderer>();
		rend.enabled = true;*/
		// NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeEmpiezaACorrer");
		directions[0] = KeyCode.W;
		directions[1] = KeyCode.S;
		directions[2] = KeyCode.A;
		directions[3] = KeyCode.D;
	}
	void PersonajeEmpiezaACorrer(){
		enMovimiento = true;
		tiempoInicio = Time.time;
	}
	void SetBackground (bool movement, string directions) {
		if (movement) {
			GetComponent<Renderer>().material.mainTextureOffset = new Vector2(((Time.time - tiempoInicio) * velocidad) % 1, 0);
		}
	}
	// Update is called once per frame
	void Update () {
		for (var index = 0; index < directions.Length; index++) {
			if (Input.GetKey (directions [index])) {
				switch (directions [index]) {
				case KeyCode.A:
					SetBackground (true, "csm");
						// Debug.Log("A!");
					break;
				case KeyCode.D:
					SetBackground (true, "CTM");
						// Debug.Log("D!");
					break;
				default:
					SetBackground (false, "csm");
					enMovimiento = false;
					break;
						
				}
			}
		}
	}
}
