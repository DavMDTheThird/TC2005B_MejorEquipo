using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Armas_Luz : MonoBehaviour
{
    private Mesh mesh;
    void Start(){

        mesh = new Mesh(); // Crea un nuevo objeto Mesh
        GetComponent<MeshFilter>().mesh = mesh;
    }

    private void Update(){

        float fov = 20f;
        Vector3 origin = Vector3.zero;
        int rayCount = 50;
        float angle = 0f;
        float angleIncrease = fov / rayCount;
        float viewDistance = 5f;


        Vector3[] vertices = new Vector3[rayCount+1+1]; // Arreglo para almacenar las posiciones de los vértices
        Vector2[] uv = new Vector2[vertices.Length]; // Arreglo para almacenar las coordenadas UV (mapeo de texturas)
        int[] triangles = new int[rayCount*3]; // Arreglo para almacenar los índices de los triángulos

        vertices[0] = origin; // Establece la posición del primer vértice en (0, 0, 0)
        
        int vertexIndex=1;
        int triangleIndex = 0;
        for(int i=0; i<= rayCount; i++  ){
            Vector3 vertex;        
            RaycastHit2D raycast2d = Physics2D.Raycast(origin,UtilsClass.GetVectorFromAngle(angle),viewDistance);
            if(raycast2d.collider == null){
                //No choca con ningun objeto
                vertex = origin + UtilsClass.GetVectorFromAngle(angle) * viewDistance;
            } else {
                //Choca con las estructuras
                vertex = raycast2d.point;
            }
            vertices[vertexIndex] = vertex;
            if(i>0){
                triangles[triangleIndex+0] = 0;
                triangles[triangleIndex+1] = vertexIndex - 1;
                triangles[triangleIndex+2] = vertexIndex;
                triangleIndex += 3;
            }
            vertexIndex ++;
            angle -= angleIncrease;
        }
        mesh.vertices = vertices; // Asigna los vértices al objeto Mesh
        mesh.uv = uv; // Asigna las coordenadas UV al objeto Mesh
        mesh.triangles = triangles; // Asigna los triángulos al objeto Mesh


        // public void SetOrigin(Vector3 origin){
        //     this.origin = origin;

        // }

        // public void SetAimDirection(Vector3 aimDirection){
        //     startingAngle = UtilsClass.GetAngleFromVectorFloat(aimDirection) - fov / 2f;
        // }
    }


}

