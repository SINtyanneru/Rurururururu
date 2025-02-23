using UnityEngine;

public class Player : MonoBehaviour {
	[SerializeField]
	public GameObject CameraObj;
	public float MoveSpeed = 5f;
	public float MouseSens = 100f;
	public bool Enabled = true;

	private float xRotation = 0f;
	private Rigidbody RB;

	void Start() {
		//マウスカーソルを非表示にしてロック
		Cursor.lockState = CursorLockMode.Locked;

		RB = GetComponent<Rigidbody>();
		RB.interpolation = RigidbodyInterpolation.Interpolate;
		RB.collisionDetectionMode = CollisionDetectionMode.Continuous;
	}

	void FixedUpdate() {
		if (Enabled) {
			Move();
			CameraRotate();
		}
	}

	private void Move() {
		float HOR = Input.GetAxis("Horizontal");
		float VER = Input.GetAxis("Vertical");

		//べくたー
		Vector3 DIRECTION = transform.right * HOR + transform.forward * VER;
		DIRECTION = DIRECTION.normalized;

		//移動
		RB.AddForce(DIRECTION * MoveSpeed, ForceMode.Force);

		//速度を制限
		if (RB.linearVelocity.magnitude > 5f)
		{
			RB.linearVelocity = RB.linearVelocity.normalized * 5f;
		}
	}

	//(上下のみ)
	private void CameraRotate() {
		float MouseX = Input.GetAxis("Mouse X") * MouseSens * Time.deltaTime;
		float MouseY = Input.GetAxis("Mouse Y") * MouseSens * Time.deltaTime;

		//垂直方向の回転を計算
		xRotation -= MouseY;
		//角度を上下90度まで制限
		xRotation = Mathf.Clamp(xRotation, -90f, 90f);

		//水平方向の回転を計算（プレイヤーの左右移動）
		CameraObj.gameObject.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
		transform.Rotate(Vector3.up * MouseX);
	}
}
