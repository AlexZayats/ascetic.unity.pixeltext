using UnityEngine;

namespace Ascetic.Unity.PixelText
{
    [CreateAssetMenu(menuName = "Pixel Text/Font")]
    public class PixelTextFont : ScriptableObject
    {
        public Texture2D AtlasTexture;
        public string AtlasText;
        public int SizeX;
        public int SizeY;
    }
}
