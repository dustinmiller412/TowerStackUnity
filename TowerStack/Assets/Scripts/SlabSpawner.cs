using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlabSpawner : MonoBehaviour
{
    public MovingSlab movingSlabScript;
    public Material movingSlabMaterial;

    public void SpawnSlab()
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


        // Position and scale the new cube
        newSlabObject.transform.position = new Vector3(0, newYPosition, -7);
        newSlabObject.transform.localScale = new Vector3(MovingSlab.previousSlab.transform.localScale.x, 0.5f, MovingSlab.previousSlab.transform.localScale.z);

        newSlab.speed = 2f + (0.5f * GameManager.count);

        // Update movingSlab to the newly spawned slab
        MovingSlab.movingSlab = newSlab;


        //float newYPosition = MovingSlab.previousSlab.transform.position.y + 0.5f;
        //MovingSlab newSlab = Instantiate(movingSlabPrefab);
        //newSlab.transform.position = new Vector3(0, newYPosition, -7);
        //newSlab.speed = 2f + (0.5f * GameManager.count);

        //// Update movingSlab to the newly spawned slab
        //MovingSlab.movingSlab = newSlab;
    }
}
