using Ascetic.Unity.Core;
using System.Collections.Generic;
using UnityEngine;

namespace Ascetic.Unity.PixelText
{
    [ExecuteAlways]
    public class PixelTextRenderer : MonoBehaviour
    {
        [SerializeField, PropertyField(nameof(Pixel)), NonNullCheck]
        private GameObject _pixel;
        public GameObject Pixel
        {
            get { return _pixel; }
            set
            {
                _pixel = value;
                RenderText();
            }
        }

        [SerializeField, PropertyField(nameof(Font)), NonNullCheck]
        private PixelTextFont _font;
        public PixelTextFont Font
        {
            get { return _font; }
            set
            {
                _font = value;
                RenderText();
            }
        }

        [SerializeField, PropertyField(nameof(Text))]
        private string _text = "PIXEL TEXT";
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                RenderText();
            }
        }

        [SerializeField, PropertyField(nameof(TextSize))]
        private float _textSize = 1;
        public float TextSize
        {
            get { return _textSize; }
            set
            {
                _textSize = value;
                RenderText();
            }
        }

        [SerializeField, PropertyField(nameof(TextAlignment))]
        private TextAlignment _textAlignment = TextAlignment.Center;
        public TextAlignment TextAlignment
        {
            get { return _textAlignment; }
            set
            {
                _textAlignment = value;
                RenderText();
            }
        }

        private List<GameObject> _cubes = new List<GameObject>();

        private void Start()
        {
            RenderText();
        }

        private void OnDestroy()
        {
            DestroyText();
        }

        private float GetTextWidth()
        {
            return _text.Length * _font.SizeX;
        }

        private float GetPixelScale()
        {
            return _textSize / _font.SizeY;
        }

        private void RenderText()
        {
            DestroyText();
            var position = 0;
            foreach (var letter in _text)
            {
                var letterIndex = _font.AtlasText.IndexOf(letter);
                if (letterIndex > -1)
                {
                    DrawLetter(letterIndex, position);
                    position++;
                }
            }
        }

        private void DrawLetter(int letterIndex, int position)
        {
            var textWidth = GetTextWidth();
            var pixelScale = GetPixelScale();
            for (var y = 0; y < _font.SizeY; y++)
            {
                for (var x = 0; x < _font.SizeX; x++)
                {
                    var color = _font.AtlasTexture.GetPixel(x + _font.SizeX * letterIndex, _font.AtlasTexture.height - y - 1);
                    if (color.grayscale > 0.5)
                    {
                        var pixel = Instantiate(_pixel);
                        pixel.hideFlags = HideFlags.HideAndDontSave;
                        pixel.transform.SetParent(transform);
                        pixel.transform.localScale = new Vector3(pixelScale, pixelScale, pixelScale);
                        var offsetX = 0f;
                        if (_textAlignment == TextAlignment.Center)
                        {
                            offsetX = -textWidth / 2;
                        }
                        else if (_textAlignment == TextAlignment.Right)
                        {
                            offsetX = -textWidth;
                        }
                        pixel.transform.localPosition = new Vector3((x + position * _font.SizeX + offsetX) * pixelScale, (_font.SizeY - y) * pixelScale, 0);
                        _cubes.Add(pixel);
                    }
                }
            }
        }

        private void DestroyText()
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
            _cubes.Clear();
        }
    }
}
