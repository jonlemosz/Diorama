using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        Move();
        Rotate();
    }

    private void Move()
    {
        Vector3 moveTo = new Vector3();
        moveTo += MyInput.Head.forward * MyInput.ControllerR.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).y;
        moveTo += MyInput.Head.right * MyInput.ControllerR.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).x;
        moveTo.y = 0;
        transform.Translate(moveTo.normalized * Time.deltaTime *1);
    }

    void Rotate()
    {
        transform.Rotate(Vector3.up * MyInput.ControllerL.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).x * Time.deltaTime*10);
    }
}
