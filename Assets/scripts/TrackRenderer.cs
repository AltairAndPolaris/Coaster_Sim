using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class TrackRenderer : MonoBehaviour
{
    [Header("Equation")]
    [SerializeField] private float tMin = 0f;
    [SerializeField] private float tMax = 20f;
    [SerializeField] private int resolution = 200;

    [Header("Example equation")]
    [SerializeField] private float amplitude = 2f;
    [SerializeField] private float frequency = 1f;

    private LineRenderer _line;

    private void Awake()
    {
        _line = GetComponent<LineRenderer>();
        RenderTrack();
    }

    public void RenderTrack()
    {
        resolution = Mathf.Max(2, resolution);

        _line.positionCount = resolution;

        for (int i = 0; i < resolution; i++)
        {
            float normalized = (float)i / (resolution - 1);
            float t = Mathf.Lerp(tMin, tMax, normalized);

            Vector3 position = EvaluateEquation(t);

            _line.SetPosition(i, position);
        }
    }

    private Vector3 EvaluateEquation(float t)
    {
        float x = t;
        float y = amplitude * Mathf.Sin(frequency * t);
        float z = 0f;

        return new Vector3(x, y, z);
    }
}
