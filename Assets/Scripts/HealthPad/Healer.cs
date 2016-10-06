using UnityEngine;
using System.Collections;

public class Healer : MonoBehaviour {

	public float healValue = -0.1f;
	public float healLength = 10f;
	public float healPause = 30f;

	private float healTime;
	private float healWait;
	private Vector3 m_Area = new Vector3 (5f, 25f, 5f);

	private void OnTriggerStay(Collider other){
		if (Time.time < healTime && Time.time > healWait) {
			Collider[] colliders = Physics.OverlapBox (transform.position, m_Area);

			for (int i = 0; i < colliders.Length; i++) {
				Rigidbody targetRigidbody = colliders [i].GetComponent<Rigidbody> ();

				if (!targetRigidbody) {
					continue;
				}

				TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth> ();

				if (!targetHealth) {
					continue;
				}

				targetHealth.TakeDamage (-1 * healValue);
			}
		}
	}
	private void OnTriggerEnter(Collider other){
		healTime = Time.time + healLength;
	}
	private void OnTriggerExit(Collider other){
		healWait = Time.time + healPause;
	}
}
