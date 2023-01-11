using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseFunctions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static float fractalNoise(float x, float y, int seed, float scale, int depth)
    {
        float noise = 0;
        for (int i = 0; i < depth; i++)
        {
            noise += Mathf.Clamp(Mathf.PerlinNoise(x * Mathf.Pow(2, i) * scale + seed, y * Mathf.Pow(2, i) * scale + seed), 0, 1) * Mathf.Pow(2, -i); //Produces a fractal noise using the original perlin noise function
        }
        return noise / (2 - Mathf.Pow(2, 1 - depth));
    }
    public static float ridge(float noise, int power)
    {
        return Mathf.Pow((1 - 2 * Mathf.Abs(noise - 0.5f)), power); //Ridges the noise to alter the generation
    }
    public static float ridgedFractalNoise(float x, float y, int seed, float scale, int depth, int power)
    {
        float noise = 0;
        for (int i = 0; i < depth; i++)
        {
            noise += ridge(Mathf.Clamp(Mathf.PerlinNoise(x * Mathf.Pow(2, i) * scale + seed, y * Mathf.Pow(2, i) * scale + seed), 0, 1), power) * Mathf.Pow(2, -i); //Combines both fractal noise and the ridge function to create ridged noise
        }
        return noise / (2 - Mathf.Pow(2, 1 - depth));
    }
}
