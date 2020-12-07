using Ascetic.Unity.Core;
using System.Collections.Generic;
using UnityEngine;

namespace Ascetic.Unity.PixelText
{
    [ExecuteAlways]
    public class PixelTextRenderer : MonoBehaviour
    {
        //[SerializeField, PropertyField(nameof(DrawOrbits))]
        public string Text;
        public GameObject Cube;
        public PixelTextFont Font;
        public float TextSize;
        public TextAlignment TextAlignment;

        private List<GameObject> _cubes = new List<GameObject>();
        private string _drawedText = null;

        private void Awake()
        {
            ClearText();
        }

        private void Update()
        {
            if (Text != _drawedText)
            {
                DrawText();
            }
        }

        private void OnDestroy()
        {
            ClearText();
        }

        private float GetTextWidth()
        {
            return Text.Length * Font.SizeX;
        }

        private float GetPixelScale()
        {
            return TextSize / Font.SizeY;
        }

        private void DrawText()
        {
            ClearText();
            var position = 0;
            foreach (var letter in Text)
            {
                var letterIndex = Font.AtlasText.IndexOf(letter);
                if (letterIndex > -1)
                {
                    DrawLetter(letterIndex, position);
                    position++;
                }
            }
            _drawedText = Text;
        }

        private void DrawLetter(int letterIndex, int position)
        {
            var textWidth = GetTextWidth();
            var pixelScale = GetPixelScale();
            for (var y = 0; y < Font.SizeY; y++)
            {
                for (var x = 0; x < Font.SizeX; x++)
                {
                    var color = Font.AtlasTexture.GetPixel(x + Font.SizeX * letterIndex, Font.AtlasTexture.height - y - 1);
                    if (color.grayscale > 0.5)
                    {
                        var cube = Instantiate(Cube);
                        cube.hideFlags = HideFlags.HideAndDontSave;
                        cube.transform.SetParent(transform);
                        cube.transform.localScale = new Vector3(pixelScale, pixelScale, pixelScale);
                        var offsetX = 0f;
                        if (TextAlignment == TextAlignment.Center)
                        {
                            offsetX = -textWidth / 2;
                        }
                        else if (TextAlignment == TextAlignment.Right)
                        {
                            offsetX = -textWidth;
                        }
                        cube.transform.localPosition = new Vector3((x + position * Font.SizeX + offsetX) * pixelScale, (Font.SizeY - y) * pixelScale, 0);
                        _cubes.Add(cube);
                    }
                }
            }
        }

        private void ClearText()
        {
            foreach (var cube in _cubes)
            {
                if (Application.isEditor)
                {
                    DestroyImmediate(cube);
                }
                else
                {
                    Destroy(cube);
                }
            }
            _drawedText = null;
            _cubes.Clear();
        }
    }
}
