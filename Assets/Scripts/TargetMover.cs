using UnityEngine;

public class TargetMover : MonoBehaviour {

	public int distanceTravelled = 5;
	public int speed = 1;

	Vector2 originalPosition;
	Transform transform;

	void Awake() {
		transform = GetComponent<Transform>();
		originalPosition = transform.position;
	}

	void Update() {
		transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
		if(transform.position.y > originalPosition.y + distanceTravelled ||
			transform.position.y < originalPosition.y - distanceTravelled) {
				speed = speed * -1;
			}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if(coll.gameObject.tag == "ball") {
			Destroy(gameObject);
		}
	}

}
