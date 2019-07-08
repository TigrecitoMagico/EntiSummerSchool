using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    [SerializeField] GameObject player;
    public float cameraSpeed;
	// Use this for initialization
	void Start () {
		
	}


    private void LateUpdate()
    {
        //movimiento suavizado de la camara
        float posx = Mathf.Lerp(transform.position.x, player.transform.position.x, Time.deltaTime * cameraSpeed);
        float posy = Mathf.Lerp(transform.position.y, player.transform.position.y, Time.deltaTime * cameraSpeed);
        transform.position = new Vector3(posx, posy, transform.position.z); 
  
    }
    // Update is called once per frame
    void Update () {

		
	}
}
