using UnityEngine;

public class PaddleControl : MonoBehaviour {

	public int speed;
	public float rotate_speed;

	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveV = Input.GetAxis("Vertical");
		float moveH = Input.GetAxis("Horizontal");
		rb2d.AddForce(new Vector2(moveH * speed, moveV * speed));

		float rotate = Input.GetAxis("RotateButton");

		rb2d.AddTorque(rotate * rotate_speed);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if(coll.gameObject.tag == "target") {
			var force = transform.position - coll.transform.position;
			force.Normalize();
			rb2d.AddForce(force * 1000);
		}
	}
}
