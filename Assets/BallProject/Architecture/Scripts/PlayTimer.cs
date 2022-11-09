using UnityEngine;

public class PlayTimer : MonoBehaviour
{
    public float ElapsedTime { get; private set; }

    private void Awake()
    {
        Disable();
    }

    private void Update()
    {
        ElapsedTime += Time.deltaTime;
    }

    public void Enable()
    {
        ElapsedTime = 0;
        enabled = true;
    }

    public void Disable()
    {
        enabled = false;
    }
}
