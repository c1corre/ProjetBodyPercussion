using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Piste : MonoBehaviour {

    public Partition partition; // piste à laquelle appartient la piste
    public List<Note> notes = new List<Note>(); // une piste contient plusieurs notes
    private float duree; // durée totale de la piste

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
