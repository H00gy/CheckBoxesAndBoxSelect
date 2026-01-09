using UnityEngine;

public class spawnCircle : MonoBehaviour
{
    /// <summary>
    /// simple spawn script
    /// </summary>
    public GameObject triangle;
    int count = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject spawnedCircle = Instantiate(triangle);
            spawnedCircle.name = $"circle_{count}";
            count++;
        }
    }


}
