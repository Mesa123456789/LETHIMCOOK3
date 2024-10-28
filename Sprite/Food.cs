using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

using MonoGame.Extended.Collisions;
using MonoGame.Extended.Tiled.Renderers;
using MonoGame.Extended.Tiled;
using MonoGame.Extended;
using MonoGame.Extended.Timers;
using MonoGame.Extended.ViewportAdapters;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Input;
using LETHIMCOOK3.Screen;

namespace LETHIMCOOK3.Sprite
{
    public class Food : Sprite
    {
        public Vector2 foodPosition;
        public RectangleF foodBox;
        public Rectangle foodRec;
        public Texture2D foodTexture, foodTexBag2, foodTexture2;
        public Texture2D foodTexBag;
        public int getFood;
        public static bool OntableAble;
        Game1 game;
        public RectangleF Bounds;
        AnimatedTexture SpriteTexture;
        Vector2 playerPos;
        public string name;
        public bool istrue;
        public bool Two, cursor;
        public int id;

        public Food(int id, string name, bool Istrue)
        {
            this.id = id;
            this.name = name;
            istrue = Istrue;
        }
        public Food(Texture2D foodTexture, Vector2 foodPosition)
        {

            this.foodTexture = foodTexture;
            this.foodPosition = foodPosition;
        }
        public Food(string name, Texture2D foodTexBag, Vector2 foodPosition)
        {
            this.name = name;
            this.foodTexBag = foodTexBag;
            this.foodPosition = foodPosition;
        }

        public Food(string name, Texture2D foodTexBag, Rectangle foodRec,bool Two)
        {
            this.name = name;
            this.Two = Two;
            this.foodTexBag = foodTexBag;
            this.foodRec = foodRec;
        }
        public bool three;
        public Food(bool three,string name, Texture2D foodTexBag, Rectangle foodRec)
        {
            this.name = name;
            this.three  = three;
            this.foodTexBag = foodTexBag;
            this.foodRec = foodRec;
        }
        public Food(string name, Texture2D foodTexBag, bool Istrue , Vector2 foodPosition , Rectangle foodRec)
        {
            this.name = name;
            this.foodTexBag = foodTexBag;
            istrue = Istrue;
            this.foodPosition = foodPosition;
            this.foodRec = foodRec;
            foodBox = new RectangleF((int)foodPosition.X, (int)foodPosition.Y, 32, 32);
        }
        public Food(string name, Texture2D foodTexture, Texture2D foodTexture2, Texture2D foodTexBag, Vector2 foodPosition, RectangleF foodBox, bool cursor)
        {
            this.name = name;
            this.foodTexture = foodTexture;
            this.foodTexture2 = foodTexture2;
            this.foodTexBag = foodTexBag;
            this.foodPosition = foodPosition;
            this.foodBox = foodBox;
            this.cursor = cursor;
            foodBox = new RectangleF((int)foodPosition.X, (int)foodPosition.Y, 32, 32);
        }
        bool healing;
        public Food(Texture2D foodTexture, Vector2 foodPosition, RectangleF foodBox,bool healing)
        {

            this.foodTexture = foodTexture;
            this.foodPosition = foodPosition;
            this.foodBox = foodBox;
            this.healing = healing;
            foodBox = new RectangleF((int)foodPosition.X, (int)foodPosition.Y, 32, 32);
        }
        public Food(string name, Texture2D foodTexture, Texture2D foodTexBag, Vector2 foodPosition)
        {
            this.name = name;
            this.foodTexture = foodTexture;
            this.foodTexBag = foodTexBag;
            this.foodPosition = foodPosition;
            foodBox = new RectangleF((int)foodPosition.X, (int)foodPosition.Y, 50, 50);
            OntableAble = false;
            
        }
        bool oncursor;

        public void Update(GameTime gameTime, Player player,GameplayScreen gameplay)
        {
            MouseState ms = Mouse.GetState();
            Rectangle MouseRec = new Rectangle(ms.X,ms.Y,32,32);
            if (foodBox.Intersects(player.Bounds) && ms.LeftButton == ButtonState.Pressed)
            {
                Console.WriteLine("intersect");
                OnCollision();
            }
            if (foodBox.Intersects(gameplay.mouseCheck))
            {
                oncursor = true;
            }
            else
            {
                oncursor = false;
            }
            foodBox = new RectangleF((int)foodPosition.X, (int)foodPosition.Y,32,32);
        }
        public void Update(GameTime gameTime, Player player, CandyScreen gameplay)
        {
            MouseState ms = Mouse.GetState();
            Rectangle MouseRec = new Rectangle(ms.X, ms.Y, 32, 32);
            if (foodBox.Intersects(player.Bounds) && ms.LeftButton == ButtonState.Pressed)
            {
                Console.WriteLine("intersect");
                OnCollision();
            }
            if (foodBox.Intersects(gameplay.mouseRec))
            {
                oncursor = true;
            }
            else
            {
                oncursor = false;
            }
            foodBox = new RectangleF((int)foodPosition.X, (int)foodPosition.Y, 32, 32);
        }

        public void Update(GameTime gameTime, Player player, SeaScreen gameplay)
        {
            MouseState ms = Mouse.GetState();
            Rectangle MouseRec = new Rectangle(ms.X, ms.Y, 32, 32);
            if (foodBox.Intersects(player.Bounds) && ms.LeftButton == ButtonState.Pressed)
            {
                Console.WriteLine("intersect");
                OnCollision();
            }
            if (foodBox.Intersects(gameplay.mouseCheck))
            {
                oncursor = true;
            }
            else
            {
                oncursor = false;
            }
            foodBox = new RectangleF((int)foodPosition.X, (int)foodPosition.Y, 32, 32);
        }
        public override void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(foodTexture, foodPosition,Color.White);
            //_spriteBatch.DrawRectangle((RectangleF)foodBox, Color.Purple, 3f);
            if (oncursor)
            {
                _spriteBatch.Draw(foodTexture2, foodPosition, Color.White);
                //_spriteBatch.DrawRectangle((RectangleF)foodBox, Color.Purple, 3f);
            }
        }
        public void DrawBook(SpriteBatch _spriteBatch)
        {
            //for (int i = 0; i < Game1.MenuList.Count; i++)
            //{
            //    Game1.MenuList[i].foodPosition = Game1.bookVec[i];
            //}
            _spriteBatch.Draw(foodTexture,  new Rectangle((int)foodPosition.X, (int)foodPosition.Y,40,40) , Color.White);
        }
        public override void DrawBag(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(foodTexBag, foodPosition, Color.White);
        }
        public virtual void OnCollision()
        {
            //OntableAble = true;
            Game1.BagList.Add(this);
            Game1.IsPopUp = true;
            foreach (Food food in Game1.foodList)
            {
                Game1.foodList.Remove(this);
                break;
            }
        }


    }
}
