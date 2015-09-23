using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour {

    public Piste piste; // piste à laquelle appartient la note
    private int index; // index dans la piste
    private float temps; // moment auquel est joué la note
    private AudioClip son; // attribut nécessaire pour jouer un son (!!! modif!!!)

    private AudioClip[] sons;
    private 

	// Use this for initialization
	void Start () {
        Awake();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    /// <summary>
    /// Awake this instance.
    /// </summary>
    // Use this for initialization
    void Awake()
    {
        // Instanciation des clips présents dans le dossier Sounds.
        sons = Resources.LoadAll<AudioClip>("Sounds");

        // Instanciation des couleurs.
        /*black = (Material)Resources.Load("Materials/Black");
        red = (Material)Resources.Load("Materials/Red");
        blue = (Material)Resources.Load("Materials/Blue");
        green = (Material)Resources.Load("Materials/Green");
        neutre = (Material)Resources.Load("Materials/Neutre");*/
    }

    /// <summary>
	/// Ajout d'un son à une boucle.
	/// </summary>
	/// <param name="title"> Titre de l'AudioClip à ajouter à la boucle.</param>
	/// <param name="time"> Paramètre à fournir pour ajouter un son à un temps voulu.</param>
	/// <param name="delay"> Décalage entre l'appui d'une touche et l'ajout d'un son.</param>
	public void AddSound(string title, float time = -1, float delay = 0.0f)
    {

        GameObject sph = (GameObject)Instantiate(Resources.Load("Sphere")); // Chargement du prefab Sphere.
        AddColor(title, sph);

        sph.transform.parent = this.gameObject.transform.GetChild(0); // Désigne le parent de la Sphere.
                                                                      // Positionnement de la Sphere.
        float x = sph.transform.parent.parent.position.x;
        float y = sph.transform.parent.parent.position.y;
        float z = sph.transform.parent.parent.position.z - (sph.transform.parent.parent.localScale.z) / 2.0f;
        sph.transform.position = new Vector3(x, y, z);

        if (time == -1)
        {
            // Par défaut
            sph.GetComponent<Sound>().Time = loopTime;

            //sph.GetComponent<Sound>().Time = loopTime;
            sph.GetComponent<Sound>().Title = title;
            sph.GetComponent<Sound>().Clp = clips.Find(a => a.name == title);
        }
        else
        {
            // Si un temps a été défini.
            sph.GetComponent<Sound>().Time = time;
            sph.GetComponent<Sound>().Title = title;
            sph.GetComponent<Sound>().Clp = clips.Find(a => a.name == title);
            float angle = (time * 360.0f) / loopDuration; // Calcul de la rotation à effectuer pour placer la Sphere (en fonction du temps).
            sph.transform.RotateAround(sph.transform.parent.parent.position, Vector3.left, angle);
        }

        sph.GetComponent<Sound>().Time -= 0.20f;
        if (sph.GetComponent<Sound>().Time < 0.0f)
        {
            sph.GetComponent<Sound>().Time += loopDuration;
        }

        if (spheres.Count != 0)
        {
            float t = AdjustSound(sph);
            if (t != sph.GetComponent<Sound>().Time)
            {
                float angle = ((t - sph.GetComponent<Sound>().Time) * 360.0f) / loopDuration;
                sph.GetComponent<Sound>().Time = t;
                sph.transform.RotateAround(sph.transform.parent.parent.position, Vector3.left, -angle);
            }
        }
        spheres.Add(sph); // Ajout de la Sphere à la liste.
    }

}
