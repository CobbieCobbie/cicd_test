using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    public int width = 256;
    public int height = 256;
    public float scale = 20.0f;
    public float offsetX = 0.0f;
    public float offsetY = 0.0f;

    private Renderer currentRenderer;

    private void Start()
    {
        currentRenderer = GetComponent<Renderer>();
        offsetX = Random.Range(0f, 9999f);
        offsetY = Random.Range(0f, 9999f);
    }

    private void Update()
    {
        currentRenderer.material.mainTexture = GenerateTexture();
    }

    Texture2D GenerateTexture()
    {
        Texture2D texture = new Texture2D(width, height);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color color = CalculateColor(x, y);
                texture.SetPixel(x, y, color);
            }
        }
        texture.Apply();
        return texture;
    }

    Color CalculateColor(int x, int y)
    {
        float xCoordinate = (float)x / width * scale + offsetX;
        float yCoordinate = (float)y / height * scale + offsetY;

        var sample = Mathf.PerlinNoise(xCoordinate, yCoordinate);
        return new Color(sample, sample, sample);
    }
}
