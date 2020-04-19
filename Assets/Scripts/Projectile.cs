using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    public float lifetime;
    // Start is called before the first frame update
    void Awake()
    {
        Destroy(this.gameObject, this.lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        float angle = (this.transform.rotation.eulerAngles.z + 90) * Mathf.Deg2Rad;
        float xOffset = Mathf.Cos(angle) * speed;
        float yOffset = Mathf.Sin(angle) * speed;
        this.transform.position = new Vector3(this.transform.position.x + xOffset,
                                            this.transform.position.y + yOffset,
                                            this.transform.position.z);
    }
}
