using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public float speed = 10.0f;
    [SerializeField] private float lifespan;

    private float dirx;
    private float diry;

    public Projectile(float x, float y){
        this.dirx = x;
        this.diry = y;
    }

	void Update() {
		transform.Translate(dirx*speed*Time.deltaTime, diry*speed*Time.deltaTime, 0);

        this.lifespan -= Time.deltaTime;

        if(this.lifespan < 0){
            Destroy(this.gameObject);
        }
	}
}
