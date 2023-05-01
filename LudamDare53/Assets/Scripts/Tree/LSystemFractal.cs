using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSystemFractal : MonoBehaviour
{
    public GameObject trunkPrefab;
    public GameObject leafPrefab;
    public int iterations = 4;
    public float segmentLength = 1f;
    public float segmentAngle = 25f;
    public float spriteSize = 1f;
    public float segmentSpacing = 0.1f;
    public float drawDelay = 0.25f;

    private string axiom = "F";
    private string currentString;
    private float currentLength;
    private float currentAngle;
    private Stack<TransformInfo> transformStack;
    private float elapsedTime;

    private void Start()
    {
        currentString = axiom;
        currentLength = segmentLength;
        currentAngle = segmentAngle;
        transformStack = new Stack<TransformInfo>();
        elapsedTime = 0f;

        StartCoroutine(DrawLSystemFractal());
    }
    private IEnumerator DrawLSystemFractal()
    {
        float distanceTraveled = 0f; // Running total of the distance traveled along the y-axis

        for (int i = 0; i < iterations; i++)
        {
            string newString = "";
            foreach (char c in currentString)
            {
                switch (c)
                {
                    case 'F':
                        newString += "F+F-F-F+F";
                        break;
                    case '+':
                        newString += "+";
                        break;
                    case '-':
                        newString += "-";
                        break;
                }
            }
            currentString = newString;
            currentLength /= 2f;
            currentAngle /= 2f;
        }

        foreach (char c in currentString)
        {
            switch (c)
            {
                case 'F':
                    Vector3 initialPosition = transform.position;
                    transform.Translate(Vector3.up * currentLength * spriteSize);
                    distanceTraveled += currentLength * spriteSize; // Update the distance traveled
                    yield return new WaitForSeconds(drawDelay);
                    GameObject trunk = Instantiate(trunkPrefab, new Vector3(initialPosition.x, initialPosition.y + distanceTraveled, initialPosition.z), transform.rotation, transform);
                    trunk.transform.localScale = new Vector3(spriteSize, currentLength * spriteSize, 1f);
                    transform.Translate(Vector3.up * segmentSpacing * spriteSize);
                    distanceTraveled += segmentSpacing * spriteSize; // Update the distance traveled
                    break;
                case '+':
                    transform.Rotate(Vector3.back * currentAngle);
                    break;
                case '-':
                    transform.Rotate(Vector3.forward * currentAngle);
                    break;
                case '[':
                    transformStack.Push(new TransformInfo(transform.position, transform.rotation));
                    break;
                case ']':
                    TransformInfo ti = transformStack.Pop();
                    transform.position = ti.position;
                    transform.rotation = ti.rotation;
                    break;
            }
        }

        // Attach leaves to the end of each trunk
        foreach (Transform child in transform)
        {
            Instantiate(leafPrefab, child.position, Quaternion.identity, child);
        }
    }

    private struct TransformInfo
    {
        public Vector3 position;
        public Quaternion rotation;

        public TransformInfo(Vector3 position, Quaternion rotation)
        {
            this.position = position;
            this.rotation = rotation;
        }
    }
}
