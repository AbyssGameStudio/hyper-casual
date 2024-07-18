using UnityEngine;

public class PlaneController : MonoBehaviour
{
	public float speed = 10f;      
	public float tiltSpeed = 5f;       
	public float maxTilt = 15f;
	public float smoothTilt;

	public FloatingJoystick joystick;

	private void Start()
	{
		joystick = FloatingJoystick.FindAnyObjectByType<FloatingJoystick>();
	}
	void Update()
	{

		float moveHorizontal = joystick.Direction.x * 0.5f;
		Vector3 movement = new Vector3(moveHorizontal, 0f, 0f);
		transform.Translate(movement * speed * Time.deltaTime, Space.World);
		float targetTilt = Mathf.Clamp(-moveHorizontal * maxTilt, -maxTilt, maxTilt);
		float currentTilt = transform.rotation.eulerAngles.z;
		if (currentTilt > 180) currentTilt -= 360;  
		smoothTilt = Mathf.Lerp(currentTilt, targetTilt, Time.deltaTime * tiltSpeed);
		transform.rotation = Quaternion.Euler(0.0f, transform.rotation.y, smoothTilt);
	}
}
 