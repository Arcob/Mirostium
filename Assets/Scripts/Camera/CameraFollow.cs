using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
	// Use this for initialization
	public Transform aim;
	[SerializeField]private float height;//身后的距离
	[SerializeField]private float distance;//高度
	private Vector3 targetPosition;
	private bool onOperate = false;

	private Vector3 deltaVector;

	private bool flag = false;

	void Start () {
		//transform.position = aim.transform.position + Vector3.up * height - Vector3.forward * distance;
		//height = (transform.position-aim.position).y;
		//distance = (aim.position - transform.position).z;
		//Debug.Log(height+" "+distance);
		targetPosition = transform.position;
		transform.LookAt(aim);
		//changePosition(50.0f,50.0f,1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if(onOperate){
			targetPosition = aim.position - deltaVector;
		}else{
			if (flag){
				transform.position = aim.transform.position + Vector3.up * height - Vector3.forward * distance;
			}
		}
		//transform.LookAt(aim);
	}

	public void ChangePosition(float tarHeight,float tarDistance,float time){
		if (!onOperate){
			onOperate = true;
			deltaVector = new Vector3(0.0f,-tarHeight,tarDistance);
			targetPosition = aim.position - new Vector3(0.0f,-tarHeight,tarDistance);
			float moveSpeed = Mathf.Sqrt((tarHeight-height)*(tarHeight-height)+(tarDistance-distance)*(tarDistance-distance))/time;
			float angleSpeed = Vector3.Angle(aim.transform.position-transform.position,new Vector3(0.0f,-tarHeight,tarDistance))/time;
			Quaternion lookQua = Quaternion.LookRotation(new Vector3(0.0f,-tarHeight,tarDistance),Vector3.up);
			Debug.Log(moveSpeed);
			StartCoroutine(SmoothMoveToTarget(moveSpeed,angleSpeed,lookQua));
		}else{
			Debug.Log("Currently on operate");
		}
		//Debug.Log("moveSpeed is "+ moveSpeed + " angleSpeed is "+ angleSpeed);
	}

	public void ChangePosition(float tarHeight,float tarDistance,float moveSpeed,float angleSpeed){
		if (!onOperate){
			onOperate = true;
			deltaVector = new Vector3(0.0f,-tarHeight,tarDistance);
			targetPosition = aim.position - new Vector3(0.0f,-tarHeight,tarDistance);
			Quaternion lookQua = Quaternion.LookRotation(new Vector3(0.0f,-tarHeight,tarDistance),Vector3.up);
			StartCoroutine(SmoothMoveToTarget(moveSpeed,angleSpeed,lookQua));
		}else{
			Debug.Log("Currently on operate");
		}
	}

	IEnumerator SmoothMoveToTarget(float moveSpeed,float angleSpeed,Quaternion tarQua){
		float curSpeed = moveSpeed;
		float speedUp = curSpeed * 0.1f;
		while (Vector3.Distance(targetPosition,transform.position)>0.1f){
			transform.rotation = Quaternion.Slerp(transform.rotation,tarQua,angleSpeed * Time.deltaTime);
			//transform.LookAt(aim.position);
			transform.position += Vector3.Normalize(targetPosition-transform.position) * curSpeed * Time.deltaTime;
			//Debug.Log(Vector3.Distance(targetPosition,transform.position));
			//Debug.Log(transform.rotation);
			curSpeed += speedUp * Time.deltaTime;
			yield return 0;
		}
		transform.position = targetPosition;
		transform.LookAt(aim.position);
		height = targetPosition.y - aim.position.y;
		distance = aim.position.z-targetPosition.z;
		onOperate = false;
		activeFlag();
		this.enabled = false;
	}

	public void activeFlag(){
		flag = true;
	}
}
