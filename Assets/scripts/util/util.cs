using UnityEngine;
namespace util
{

    public static class UnityExtensions
    {
        public static void centerScale(this GameObject go, Transform parent)
        {
            go.transform.SetParent(parent);
            go.transform.localScale = Vector3.one;
            go.transform.localPosition = Vector3.zero;
        }
    }
}
