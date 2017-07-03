using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesManager : MonoBehaviour {

	public Explotion explotion;
	int id = 0;

	void Start () {
		Events.OnAbduction += OnAbduction;
	}

	void OnAbduction (Character character) {
		
		print ("ABDUCTION" + character);

		id++;
		if (id > 5)
			id = 0;
		Explotion newExplotion = Instantiate (explotion);
		newExplotion.transform.position = character.transform.position;
		newExplotion.Init (id);
	}
}
