using UnityEngine;

public class CameraMove : MonoBehaviour {

	public float Speed = 30f;
	public float BorderThickness = 10f;
	public float ScrollSpeed = 5f;
	public float MinY = 10f;
	public float MaxY = 80f;

	void Update () {

		if (GameManager.GameIsOver)
		{
			this.enabled = false;
			return;
		}

		if (Input.GetKey("w"))
		{
            transform.Translate(Vector3.forward * Speed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey("s"))
		{
			transform.Translate(Vector3.back * Speed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey("d"))
		{
			transform.Translate(Vector3.right * Speed * Time.deltaTime, Space.World);
		}
		if (Input.GetKey("a"))
		{
			transform.Translate(Vector3.left * Speed * Time.deltaTime, Space.World);
		}
		float scroll = Input.GetAxis("Mouse ScrollWheel");
		Vector3 pos = transform.position;
		pos.y -= scroll * 1000 * ScrollSpeed * Time.deltaTime;
		pos.y = Mathf.Clamp(pos.y, MinY, MaxY);
		transform.position = pos;
	}
}
