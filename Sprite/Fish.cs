using LETHIMCOOK3.Sprite;
using LETHIMCOOK3;
using LETHIMCOOK3.Screen;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Timers;
using System;


namespace LETHIMCOOK3.Sprite
{
    public class Fish : Food
    {
        Vector2 fishPos;
        Texture2D fishTexBag;
        Texture2D fishTex;

        private Random _random;
        public static bool _isFishing;
        public static double _fishCatchTime;
        public static double _elapsedTime;

        public Fish(int id, string name, Texture2D fishTex, Texture2D fishTexBag, Vector2 fishPos) : base(name, fishTex, fishTexBag, fishPos)
        {
            this.id = id;
            this.name = name;
            this.fishTex = fishTex;
            this.fishPos = fishPos;
            this.fishTexBag = fishTexBag;
            _isFishing = false;
        }

        public override void Update(GameTime gameTime)
        {

        }


        public override void OnCollision()
        {
            OntableAble = true;
            Game1.BagList.Add(this);
            Game1.IsPopUp = true;

        }
        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(fishTex, fishPos, new Rectangle(0, 0, 32, 32), Color.White, 0.0f, new Vector2(16, 16), 2.0f, SpriteEffects.None, 0.0f);
        }
        public override void DrawBag(SpriteBatch batch)
        {
            batch.Draw(fishTexBag, fishPos, new Rectangle(0, 0, 32, 32), Color.White);
        }
    }
}