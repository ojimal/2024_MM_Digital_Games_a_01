using System.Collections.Generic;
using UnityEngine;

public class SeeThrough : MonoBehaviour
{
    public Transform Target;
    private List<Transform> currentObstructions = new List<Transform>();
    private List<MeshRenderer> obstructionRenderers = new List<MeshRenderer>();

    private float maxDistance = 10.0f;
    private LayerMask obstructionMask; 

    void Start()
    {
        obstructionMask = LayerMask.GetMask("Obstacles"); 
    }

    void Update()
    {
        CheckForObstructions();
    }

    void CheckForObstructions()
    {
        RaycastHit hit;

        ResetObstructions();

        // Cast a ray from the camera to the player to check for obstructions
        if (Physics.Raycast(transform.position, Target.position - transform.position, out hit, maxDistance, obstructionMask))
        {
            // If the object hit by the ray is not the player, treat it as an obstruction
            if (hit.collider.gameObject.tag != "Player")
            {
                Transform obstruction = hit.transform;
                MeshRenderer obstructionRenderer = obstruction.GetComponent<MeshRenderer>();

                if (obstructionRenderer != null)
                {
                    // Store the obstruction to reset later
                    currentObstructions.Add(obstruction);
                    obstructionRenderers.Add(obstructionRenderer);

                    // Set obstruction to invisible
                    obstructionRenderer.enabled = false;
                }
            }
        }
    }

    // Reset visibility of previous obstructions
    void ResetObstructions()
    {
        for (int i = 0; i < obstructionRenderers.Count; i++)
        {
            if (obstructionRenderers[i] != null)
            {
                obstructionRenderers[i].enabled = true;
            }
        }

        // Clear the lists for the next frame
        currentObstructions.Clear();
        obstructionRenderers.Clear();
    }
}
