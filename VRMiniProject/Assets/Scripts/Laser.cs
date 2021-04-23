using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {

	LineRenderer lr;
	Material mat;

	[SerializeField]
	Texture2D normal, hit;
    [SerializeField]
    GameObject point;
    [SerializeField]
    Color pointColorOff, pointColorOn;

    Material pointMat;
    public GameObject _point { get { return point; } }
    float range;

	bool bhit;

	void Awake(){
		lr = GetComponent<LineRenderer> ();
		mat = lr.material;
        pointMat = point.GetComponent<Renderer>().material;

    }

    public void SetRange(float input)
    {
        range = input;
    }

    public void OnOff(bool input)
    {
        lr.enabled = input;
        point.SetActive(input);
    }

	public void SetHitPont(Vector3 input){
		Vector3 temp = transform.InverseTransformPoint (input);

        point.SetActive(true);
        point.transform.position = input;
        point.transform.LookAt(Valve.VR.InteractionSystem.Player.instance.hmdTransform);


        lr.SetPosition (1, temp);
	}

	public void SetNoHitPoint(){
        point.SetActive(false);

        lr.SetPosition (1, new Vector3(0f, 0f, range));
	}

	public void SetTextue(bool input){
		if (bhit == input)
			return;

		mat.mainTexture = input ? hit : normal;
        //		mat.SetTexture ("_EmissionMap", input ? hit : normal);
        pointMat.color = input ? pointColorOn : pointColorOff;

        bhit = input;
	}


}
