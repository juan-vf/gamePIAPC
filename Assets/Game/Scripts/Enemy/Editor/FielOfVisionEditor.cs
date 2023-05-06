using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FieldVisionController))]
public class FielOfVisionEditor : Editor
{
    private void OnSceneGUI()
    {
        FieldVisionController fov = (FieldVisionController)target;

        Color color = new Color(1, 0, 0, 0.2f);

        Handles.color = color;
        Handles.DrawSolidArc(
            fov.transform.position,
            fov.transform.up,
            Quaternion.AngleAxis(-fov.m_angleVision * 0.5f, fov.transform.up) * fov.transform.forward,
            fov.m_angleVision,
            fov.m_dstVision
        );
        // if (fov.WatchingPlayer)
        // {
            // Debug.Log("cuantos se ven"+(fov.WatchingPlayer));

            foreach (var target in fov.getTargetList())
            {
                Handles.color = Color.green;
                Handles.DrawLine(fov.transform.position, target.position);
            }
        // }
    }
}