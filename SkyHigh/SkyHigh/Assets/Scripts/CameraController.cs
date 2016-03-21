using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Transform target;
    private float angleH;
    private float angleV;
    public float rotSpeed = 180f;
    public float radius = 5f;

    void LateUpdate()
    {
        angleH += Input.GetAxis("LeftStickX") * rotSpeed * Time.deltaTime;
        angleV += Input.GetAxis("LeftStickY") * rotSpeed * Time.deltaTime;

        Vector3 rotDir = Quaternion.Euler(-angleV, -angleH, 0f) * Vector3.back;
        transform.position = (target.position + new Vector3(0.0f,1.0f,0.0f)) + radius * rotDir;

        transform.LookAt(target.position + new Vector3(0.0f, 1.0f, 0.0f));
    }
}
