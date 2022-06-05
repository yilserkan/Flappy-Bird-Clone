using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{   
    [SerializeField] float moveSpeed;

    void Update()
    {
        gameObject.transform.position -= Vector3.right * moveSpeed * Time.deltaTime;     

        DespawnPipe();
    }

    private void DespawnPipe()
    {
        float despawnXPosition = Camera.main.ViewportToWorldPoint(new Vector3(0,0,0)).x;
        if(gameObject.transform.position.x < despawnXPosition)
        {
            ObjectPoolManager.Instance.DespawnObject(gameObject);
        }
    }
}
