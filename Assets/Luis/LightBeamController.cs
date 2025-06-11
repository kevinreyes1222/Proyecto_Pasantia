using UnityEngine;
using UnityEngine.UIElements;

public class LightBeamController : MonoBehaviour
{
    public Light spotLight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spotLight = GetComponentInParent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(spotLight.spotAngle * 4.5f, spotLight.spotAngle * 4.5f, spotLight.range * 25);
        transform.rotation = Quaternion.Inverse(spotLight.transform.rotation);
        transform.position = spotLight.transform.position + spotLight.transform.forward * 5f * 0.5f;
    }
}
