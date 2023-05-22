// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using CodeMonkey.Utils;

// public class Armas_Luz : MonoBehaviour
// {
//     // Start is called before the first frame update
//     void Start()
// {
//     Mesh mesh = new Mesh(); // Crea un nuevo objeto Mesh
//     GetComponent<MeshFilter>().mesh = mesh;

//     float fov = 90f;
//     Vector3 origin = Vector3.zero;
//     int rayCount = 2;
//     float angle = 0f;
//     float angleIncrease = fov / rayCount;
//     float viewDistance = 50f;


//     Vector3[] vertices = new Vector3[rayCount+1+1]; // Arreglo para almacenar las posiciones de los vértices
//     Vector2[] uv = new Vector2[vertices.Length]; // Arreglo para almacenar las coordenadas UV (mapeo de texturas)
//     int[] triangles = new int[rayCount*3]; // Arreglo para almacenar los índices de los triángulos

//     vertices[0] = origin; // Establece la posición del primer vértice en (0, 0, 0)
    
//     for(int i=0; i<= rayCount; i++0){
//         Vector3 vertex = origin + UtilsClass.getan
//     }

//     mesh.vertices = vertices; // Asigna los vértices al objeto Mesh
//     mesh.uv = uv; // Asigna las coordenadas UV al objeto Mesh
//     mesh.triangles = triangles; // Asigna los triángulos al objeto Mesh
// }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }
