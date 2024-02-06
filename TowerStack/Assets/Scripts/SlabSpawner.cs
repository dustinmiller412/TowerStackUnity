using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlabSpawner : MonoBehaviour
{
    public MovingSlab movingSlabScript;
    public Material movingSlabMaterial;


    public void SpawnSlab()
    {
        if (!MovingSlab.done)
        {

            float newYPosition = MovingSlab.previousSlab.transform.position.y + 0.5f;

            // Create a new primitive cube
            GameObject newSlabObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            // Add the MovingSlab script and material to the new cube
            MovingSlab newSlab = newSlabObject.AddComponent<MovingSlab>();

            if (movingSlabMaterial != null)
            {
                Renderer slabRenderer = newSlabObject.GetComponent<Renderer>();
                slabRenderer.material = movingSlabMaterial;

            }
            newSlab.GetComponent<Renderer>().material.SetColor("_Color", Color.HSVToRGB((GameManager.count / 100f) % 1f, 1f, 1f));

            // Position and scale the new cube
            if (GameManager.count % 2 == 0)
            {
                newSlabObject.transform.position = new Vector3(-7, newYPosition, (MovingSlab.previousSlab.transform.position.z));
            }
            else
            {
                newSlabObject.transform.position = new Vector3(MovingSlab.previousSlab.transform.position.x, newYPosition, -7);
            }


            newSlabObject.transform.localScale = new Vector3(MovingSlab.previousSlab.transform.localScale.x, 0.5f, MovingSlab.previousSlab.transform.localScale.z);

            newSlab.speed += (0.5f * GameManager.count);

            // Update movingSlab to the newly spawned slab
            MovingSlab.movingSlab = newSlab;
            MainCamera.UpdateCamera();
        }


    }

}
