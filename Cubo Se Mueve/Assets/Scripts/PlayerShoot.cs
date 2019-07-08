using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {
    [SerializeField] GameObject bullet;
    [SerializeField] float weaponSpeed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bullet);
            bullet.GetComponent<Bullet>().dirvector = (new Vector2(Vector2 dirvector = (new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y) - new Vector2(gameObject.transform.position.x, gameObject.transform.position.y)).normalized;))
            bullet.GetComponent<bullet>().speed;
        }
	}
}
