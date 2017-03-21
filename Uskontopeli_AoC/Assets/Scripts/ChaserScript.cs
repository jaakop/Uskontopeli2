using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserScript : MonoBehaviour {

    [SerializeField]
    private GameObject Player;

	void Start () {
		
	}


	void Update () {
        transform.rotation = Player.transform.rotation;
	}
}
