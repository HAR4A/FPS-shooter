using UnityEngine;

public interface IControllable
{
    public void LookHorizontal(Vector3 horizontal);
    public void LookVertical(Vector3 vertical);
    public void Move(Vector3 direction);
}