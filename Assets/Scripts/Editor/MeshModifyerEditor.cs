using UnityEditor;

[CustomEditor(typeof(MeshModify))]
public class MeshModifyerEditor : Editor
{
    private MeshModify meshModify;

    public void OnEnable()
    {
        meshModify = (MeshModify)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
    }
}
