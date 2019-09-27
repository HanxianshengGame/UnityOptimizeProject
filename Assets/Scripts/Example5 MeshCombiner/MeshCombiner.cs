using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCombiner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ChildMeshCombiner();
    }

    private void ChildMeshCombiner()
    {
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combineInstances=new CombineInstance[meshFilters.Length-1];
        for (int i = 1; i < meshFilters.Length; i++)
        {
            combineInstances[i-1].mesh = meshFilters[i].sharedMesh;
            combineInstances[i-1].transform = meshFilters[i].transform.localToWorldMatrix;
        }

        var finalMater = meshFilters[1].gameObject.GetComponent<MeshRenderer>().material;
        Mesh finalMesh=new Mesh();
        finalMesh.CombineMeshes(combineInstances);
        meshFilters[0].mesh = finalMesh;
        GetComponent<MeshRenderer>().material = finalMater;
        
    }
}
