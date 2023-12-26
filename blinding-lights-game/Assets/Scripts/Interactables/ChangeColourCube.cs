using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ChangeColourCube : Interactable
{

    private int colourIndex;
    public Color[] colors;
    MeshRenderer mesh;
    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        mesh.material.color = Color.red;
    }
    protected override void Interact()
    {
        colourIndex++;
        if (colourIndex >= colors.Length-1)
        {
            colourIndex = 0;
        }
        mesh.material.color = colors[colourIndex];
    }
}
