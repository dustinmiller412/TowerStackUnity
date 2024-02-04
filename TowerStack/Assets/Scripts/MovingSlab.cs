using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class MovingSlab : MonoBehaviour
{
    public static MovingSlab movingSlab { get; set; }
    public static MovingSlab previousSlab { get; private set; }
    public static MovingSlab newSlab { get; private set; }

    public float speed = 2f;

    private void OnEnable()
    {
        if(previousSlab == null)
        {
            previousSlab = this;
        }
        movingSlab = this;
    }

    public void Stop()
    {
        float hangoverValue = 0;
        speed = 0;
        hangoverValue = transform.position.z - previousSlab.transform.position.z;
   

        float direction = hangoverValue > 0 ? 1f : -1f;
        SliceSlab(hangoverValue, direction);
        previousSlab = this;
        FindObjectOfType<SlabSpawner>().SpawnSlab();
    }

    private void SliceSlab(float hangoverValue, float direction)
    {

        float newZSize = previousSlab.transform.localScale.z - Mathf.Abs(hangoverValue);
        newZSize = Mathf.Max(newZSize, 0.01f); // Ensuring non-negative size

        float fallingBlockSize = transform.localScale.z - newZSize;
        fallingBlockSize = Mathf.Max(fallingBlockSize, 0.01f); // Ensuring falling block size is positive

        float newZPosition = previousSlab.transform.position.z + (hangoverValue / 2);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, newZSize);
        transform.position = new Vector3(transform.position.x, transform.position.y, newZPosition);

        if (fallingBlockSize > 0.01f)
        {
            // Only create the falling slab if the block size is significant
            float slabEdge = transform.position.z + (newZSize / 2f * direction);
            float fallingSlabZPosition = slabEdge + fallingBlockSize / 2f * direction;

            var slab = GameObject.CreatePrimitive(PrimitiveType.Cube);
            slab.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, fallingBlockSize);
            slab.transform.position = new Vector3(transform.position.x, transform.position.y, fallingSlabZPosition);

            // Setting color and adding Rigidbody
            slab.GetComponent<Renderer>().material.color = GetComponent<Renderer>().material.color;
            slab.AddComponent<Rigidbody>();

        }
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }
}
