# Ascetic's Unity Pixel Text

[![npm](https://img.shields.io/npm/v/ascetic.unity.pixeltext?style=for-the-badge)](https://www.npmjs.com/package/ascetic.unity.pixeltext)
[![npm](https://img.shields.io/npm/dw/ascetic.unity.pixeltext?style=for-the-badge)](https://www.npmjs.com/package/ascetic.unity.pixeltext)
[![GitHub](https://img.shields.io/github/license/alexzayats/ascetic.unity.pixeltext?style=for-the-badge)](https://github.com/AlexZayats/ascetic.unity.pixeltext)
[![GitHub](https://img.shields.io/github/workflow/status/alexzayats/ascetic.unity.pixeltext/Node.js%20Package?style=for-the-badge)](https://github.com/AlexZayats/ascetic.unity.pixeltext)

Unity package for creating 3D pixel text. Contains component, pixel prefabs and fonts.

## Installation

**Ascetic's Unity Pixel Text** is used through **Unity's Package Manager**. In order to use it you'll need to add the following lines to your `Packages/manifest.json` file. This has to be done so your Unity editor can connect to NPM's package registry.

```
"scopedRegistries": [
  {
    "name": "NPM",
    "url": "https://registry.npmjs.org",
    "scopes": [
      "ascetic"
    ]
  }
]
```

After that you'll be able to visually control what specific version of **Ascetic's Unity Pixel Text** you're using from the package manager window in Unity.

From Unity IDE: Window -> Package Manager
* Click "+" -> Add package from git URL
* Enter "ascetic.unity.pixeltext"
* Click "Add"

Enjoy!
