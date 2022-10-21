using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    [Header("Parametres")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private string playerTag; //tag gameobject player
    [SerializeField] private float movingspeed; //speed move

    private void Awake()
    {
        if (this.playerTransform == null)
        {

            if (this.playerTag == "")
            {
                this.playerTag = "Player";
            }


            this.playerTransform = GameObject.FindGameObjectWithTag(this.playerTag).transform;

        }
        this.transform.position = new Vector3()
        {
            x = this.playerTransform.position.x,
            y = this.playerTransform.position.y,
            z = this.playerTransform.position.z - 20
        };
    }

    private void Update()
    {
        if (this.playerTransform)
        {
            Vector3 target = new Vector3()
            {
                x = this.playerTransform.position.x,
                y = this.playerTransform.position.y,
                z = this.playerTransform.position.z - 20
            };

            Vector3 pos = Vector3.Lerp(this.transform.position, target, this.movingspeed = Time.deltaTime);

            this.transform.position = pos;
        }
    }
}
