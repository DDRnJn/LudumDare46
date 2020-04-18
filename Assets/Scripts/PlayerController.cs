using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = .05f;
    public Vector2 rotation;
    public Transform playerSprite;
    public Transform shooter;

    public Transform basicProjectile;

    public float fireDelay;
    float currentTime;

    void Update()
    {
        Vector2 translation = this.getTranslation();
        Vector3 rotation = this.getRotation();

        this.transform.Translate(translation);
        this.playerSprite.rotation = Quaternion.Euler(rotation);
        this.shooter.rotation = Quaternion.Euler(rotation);

        this.currentTime = this.currentTime + Time.deltaTime;
        if (Input.GetButton("Fire1") && this.currentTime > this.fireDelay)
        {
            this.Fire();
            this.currentTime = 0.0f;
        }

    }

    Vector2 getTranslation()
    {
        Vector2 translation = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            translation += Vector2.up * this.movementSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            translation += Vector2.down * this.movementSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            translation += Vector2.left * this.movementSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            translation += Vector2.right * this.movementSpeed;
        }
        return translation;
    }

    Vector3 getRotation()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 objectPosition = Camera.main.WorldToScreenPoint(this.transform.position);
        mousePosition.x = mousePosition.x - objectPosition.x;
        mousePosition.y = mousePosition.y - objectPosition.y;
        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        return new Vector3(0, 0, angle);
    }

    void Fire()
    {
        Transform basicProjectile = Instantiate(this.basicProjectile, this.shooter.transform.position,
                                      this.shooter.transform.rotation);
    }
}
