using UnityEngine;

public class DissolveSphere : MonoBehaviour {

    public static Material mat;

    private void Start() {
        mat = GetComponent<Renderer>().material;
    }
}