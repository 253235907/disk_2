using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class PhysisManager :  SSActionManager,  IActionManager{

	public Physis fly;                            
	public FirstController scene_controller; 

	protected void Start()
	{
		scene_controller = (FirstController)SSDirector.GetInstance().CurrentScenceController;
		scene_controller.action_manager = this;     
	}

	public void UFOFly(GameObject disk, float angle, float power)
	{
		fly = Physis.GetSSAction(disk, angle, power);
		this.RunAction(disk, fly, this);
		disk.GetComponent<DiskData> ().action = fly;

		disk.AddComponent<Rigidbody> ();
		Rigidbody rigid = disk.GetComponent<Rigidbody> ();
		rigid.useGravity = true;

		disk.GetComponent<Rigidbody>().velocity = Vector3.zero;
		Vector3 force = new Vector3 (15 * Random.Range(-1,1), 5 * Random.Range(0.5f,2), 10);
		disk.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
	}

}
