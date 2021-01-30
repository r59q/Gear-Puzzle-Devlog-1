using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Threading.Tasks;

[CustomEditor(typeof(GearMesh))]
public class GearMeshEditor : Editor
{
    int teethCount, resolution;
    float teethDepth, thickness;
    GearMesh myScript;
    bool autoUpdate = false;

    private void OnEnable()
    {
        myScript = (GearMesh)target;
        SetCheckMemory();
    }
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Generate Mesh Manually"))
        {
            myScript.GenerateGear();
        }
        if (GUILayout.Button("Auto-generate : " + autoUpdate.ToString()))
        {
            autoUpdate = !autoUpdate;
        }

        // Set memory
        if (SetCheckMemory() && autoUpdate)
        {
            myScript.GenerateGear();
        }
    }


    private bool SetCheckMemory()
    {
        bool result = false;
        if (teethCount  != myScript.TeethCount ||
            resolution  != myScript.Resolution ||
            teethDepth  != myScript.TeethDepth ||
            thickness   != myScript.Thickness)
        {
            result = true;
        }
        teethCount = myScript.TeethCount;
        resolution = myScript.Resolution;
        teethDepth = myScript.TeethDepth;
        thickness = myScript.Thickness;
        return result;
    }
}