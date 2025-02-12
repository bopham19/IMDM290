using System;
using JetBrains.Annotations;
using UnityEngine;

public class HeartAnimation : MonoBehaviour
{
    GameObject[] spheres;
    public int numSphere; 
    float time = 0f;
    Vector3[] initPos;
    void Start()
    {
        spheres = new GameObject[numSphere];
        initPos = new Vector3[numSphere];
        
        for (int i =0; i < numSphere; i++){

            spheres[i] = GameObject.CreatePrimitive(PrimitiveType.Sphere); 

            initPos[i] = new Vector3(Mathf.Sqrt(2)*Mathf.Pow(Mathf.Sin(i),3), 
            -Mathf.Pow(Mathf.Cos(i),3) - Mathf.Pow(Mathf.Cos(i),2) + 2*Mathf.Cos(i));
            spheres[i].transform.position = initPos[i];


            Renderer sphereRenderer = spheres[i].GetComponent<Renderer>();


            Color color = Color.HSVToRGB(0, 1f, 1f); //color red for spheres
            sphereRenderer.material.color = color;
        }
    }

    void Update()
    {
        Vector3 tempScale = new Vector3(1f,1f,1f);
        time += Time.deltaTime;
        for (int i =0; i < numSphere; i++){

            spheres[i].transform.position = initPos[i] + new Vector3(1f, 1f, Mathf.Sin(time) * 3f) ;

            spheres[i].transform.localScale = tempScale*i/100*Mathf.Sin(time);

            Renderer sphereRenderer = spheres[i].GetComponent<Renderer>();

        }

    }
}
