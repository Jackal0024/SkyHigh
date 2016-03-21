using UnityEngine;
using System.Collections;

public class WindController : MonoBehaviour {

    public float power = 10f;
    public float coefficient;
    public GameObject player;


    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 velocity = Camera.main.transform.forward + new Vector3(0.0f, 2.0f, 0.0f);
        Vector3 totalv = velocity * (power * Input.GetAxis("Trigger"));
        totalv.y = Mathf.Abs(totalv.y);
        Wind(player,totalv);
    }

    void Wind(GameObject col, Vector3 velocity)
    {
        // 相対速度計算
        var relativeVelocity = velocity - col.GetComponent<Rigidbody>().velocity;

        // 空気抵抗を与える
        col.GetComponent<Rigidbody>().AddForce(coefficient * relativeVelocity);
    }
}
