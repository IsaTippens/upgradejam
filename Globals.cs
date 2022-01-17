global using Microsoft.Xna.Framework;
global using Microsoft.Xna.Framework.Graphics;
global using Microsoft.Xna.Framework.Input;
global using System;
namespace upgradejam;

public static class ContentManagerExtensions
{
    public static Texture2D LoadTexture(this Microsoft.Xna.Framework.Content.ContentManager content, string assetName)
    {
        return content.Load<Texture2D>(assetName);
    }
}