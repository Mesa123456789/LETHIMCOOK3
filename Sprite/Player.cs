using LETHIMCOOK3.Screen;
using LETHIMCOOK3;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Collisions;
using MonoGame.Extended.ViewportAdapters;
using System;
using static System.Formats.Asn1.AsnWriter;
using System.Diagnostics.Contracts;


namespace LETHIMCOOK3.Sprite
{
    public class Player : IEntity, ICollisionActor
    {
        Enemy enemy;
        public Vector2 CharPosition;
        AnimatedTexture SpriteTexture;
        AnimatedTexture SpriteTextureIdel;
        MouseState mouseSt;
        Vector2 mousepos;
        Vector2 distance = new();
        Vector2 posMouse = new();
        Vector2 knockbackdirection;
        Texture2D sword, effect;
        GameplayScreen screen;
        bool isHit, isAttak, isMove;
        float rotation, preRo;

        bool isClick;
        int state = 0;
        int count, countAtk;
        public Rectangle mouseCheck;
        public enum Direction { Left, Right, Up, Down }
        public Direction direction { get; set; }
        private readonly Game1 _game;
        public int Velocity = 4;
        public Vector2 move;
        public IShapeF Bounds { get; }
        private KeyboardState ks;
        private KeyboardState _oldKey;
        Texture2D myTexture, smoke;
        RectangleF ltChack, lbChack, rtChack, rbChack, mouseF;

        public Player(AnimatedTexture SpriteTexture, Vector2 CharPosition, Game1 game, IShapeF circleF)
        {

            this.SpriteTexture = SpriteTexture;
            this.CharPosition = CharPosition;
            direction = Direction.Right;
            _game = game;
            Bounds = circleF;
            SpriteTextureIdel = new AnimatedTexture(new Vector2(16, 16), 0, 2f, 1f);
            //game._cameraPosition = new Vector2(400, 200);

        }

        public void Load(ContentManager content, string asset)
        {
            smoke = content.Load<Texture2D>("Smoke");
            sword = content.Load<Texture2D>("Sword");
            effect = content.Load<Texture2D>("Effect");
            SpriteTextureIdel.Load(content, "PlayerIdel", 5, 4, 4);
            //myTexture = content.Load<Texture2D>("Player-Sheet");
            var viewportadapter = new BoxingViewportAdapter(_game.Window, _game.GraphicsDevice, 800, 450);
            Game1._camera = new OrthographicCamera(viewportadapter);
        }

        Vector2 dr;
        bool IsMove = false;
        public void Update(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            SpriteTextureIdel.Play();
            SpriteTexture.Pause();
            KeyboardState ks = Keyboard.GetState();
            ks = Keyboard.GetState();


            if (ks.IsKeyDown(Keys.D) && Bounds.Position.X < 1600 - ((RectangleF)Bounds).Width)
            {
                move = new Vector2(Velocity, 0) * gameTime.GetElapsedSeconds() * 42;
                move.Normalize();
                if (Bounds.Position.X - _game.GetCameraPosX() >= 400 && _game.GetCameraPosX() < 700)
                {
                    _game.UpdateCamera(move);
                }
                Bounds.Position += move;
                SpriteTexture.Play();
                direction = Direction.Right;
                IsMove = true;
            }
            else
            {
                IsMove = false;
            }
            if (ks.IsKeyDown(Keys.A) && Bounds.Position.X > 0 - ((RectangleF)Bounds).Width)
            {
                move = new Vector2(-Velocity, 0) * gameTime.GetElapsedSeconds() * 42;
                move.Normalize();
                if (Bounds.Position.X - _game.GetCameraPosX() <= 400 && _game.GetCameraPosX() > 0)
                {
                    _game.UpdateCamera(move);
                }

                Bounds.Position += move;
                SpriteTexture.Play();
                direction = Direction.Left;
                IsMove = true;
            }
            //else
            //{
            //    IsMove = false;
            //}
            if (ks.IsKeyDown(Keys.S) && Bounds.Position.Y < 900 - ((RectangleF)Bounds).Height)
            {
                move = new Vector2(0, Velocity) * gameTime.GetElapsedSeconds() * 42;
                move.Normalize();
                if (Bounds.Position.Y - _game.GetCameraPosY() >= 225 && _game.GetCameraPosY() < 450)
                {
                    _game.UpdateCamera(move);
                }
                Bounds.Position += move;
                SpriteTexture.Play();
                direction = Direction.Right;
                IsMove = true;

            }
            //else
            //{
            //    IsMove = false;
            //}
            if (ks.IsKeyDown(Keys.W) && Bounds.Position.Y > 0 - ((RectangleF)Bounds).Height)
            {
                move = new Vector2(0, -Velocity) * gameTime.GetElapsedSeconds() * 42;
                move.Normalize();
                if (Bounds.Position.Y - _game.GetCameraPosY() <= 225 && _game.GetCameraPosY() > 0)
                {
                    _game.UpdateCamera(move);
                }
                Bounds.Position += move;
                SpriteTexture.Play();
                direction = Direction.Down;
                IsMove = true;
            }
            if (move != Vector2.Zero)
            {
                move.Normalize();
            }
            if (IsMove == false)
            {
                SpriteTextureIdel.Play();
            }

            SpriteTexture.UpdateFrame(elapsed);
            SpriteTextureIdel.UpdateFrame(elapsed);
            mouseSt = Mouse.GetState();
            mousepos = Mouse.GetState().Position.ToVector2();
            posMouse = new Vector2(mousepos.X + (_game._cameraPosition.X - 15), mousepos.Y + (_game._cameraPosition.Y -15));
            mouseCheck = new Rectangle((int)posMouse.X, (int)posMouse.Y, 24, 24);

            distance = new Vector2(posMouse.X - Bounds.Position.X, posMouse.Y - Bounds.Position.Y);

            rotation = (float)Math.Atan2(distance.Y, distance.X);

            ltChack = new RectangleF(Bounds.Position.X - 45, Bounds.Position.Y - 45, 80, 80);
            lbChack = new RectangleF(Bounds.Position.X - 45, Bounds.Position.Y + 32, 80, 80);
            rtChack = new RectangleF(Bounds.Position.X + 32, Bounds.Position.Y - 45, 80, 80);
            rbChack = new RectangleF(Bounds.Position.X + 32, Bounds.Position.Y + 32, 80, 80);

            if (Bounds.Intersects(mouseF))
            {
                isHit = true;
            }
            else isHit = false;

            //Attack
            if (mouseSt.LeftButton == ButtonState.Pressed)
            {
                if (isClick == false)
                {
                    if (state <= 3)
                    {
                        state = state + 1;
                        countAtk = 0;
                        isAttack = true;
                        isClick = true;
                    }
                }
            }
            if (mouseSt.LeftButton == ButtonState.Released)
            {
                isClick = false;
                isAttack = false;
                preRo = rotation;
            }
            if (state > 3)
            {
                if (countAtk < 15)
                {
                    state = 1;
                }
                else state = 0;
            }
            if (state < 4)
            {
                countAtk++;
            }
            if (countAtk < 15)
            {
                isAttack = true;
            }
            else
            {
                isAttack = false;
            }

            //Partical();

        }



        public void Draw(SpriteBatch _spriteBatch)
        {
            //_spriteBatch.DrawRectangle((RectangleF)ltChack, Color.Red, 3f);
            //_spriteBatch.DrawRectangle((RectangleF)lbChack, Color.Red, 3f);
            //_spriteBatch.DrawRectangle((RectangleF)rtChack, Color.Red, 3f);
            //_spriteBatch.DrawRectangle((RectangleF)rbChack, Color.Red, 3f);
            if (IsMove == true)
            {
                SpriteTexture.DrawFrame(_spriteBatch, new Vector2((int)((RectangleF)Bounds).X + 18, (int)((RectangleF)Bounds).Y + 32), (int)direction + 1);
                //_spriteBatch.DrawRectangle((RectangleF)Bounds, Color.Red, 3f);
            }
            if (IsMove == false)
            {
                SpriteTextureIdel.DrawFrame(_spriteBatch, new Vector2((int)((RectangleF)Bounds).X + 18 , (int)((RectangleF)Bounds).Y + 32), (int)direction + 1);
                //_spriteBatch.DrawRectangle((RectangleF)Bounds, Color.Red, 3f);
            }


            if (state == 1 && isAttack == true && !SeaScreen._isFishing && RestauarntScreen.IsCooking == false)
            {
                _spriteBatch.Draw(effect, new Vector2(Bounds.Position.X, Bounds.Position.Y + 15), new Rectangle(0, 0, 48, 48), Color.White, rotation, new Vector2(24, 24), 2.0f, SpriteEffects.FlipVertically, 0.0f);
                _spriteBatch.Draw(sword, new Vector2(Bounds.Position.X, Bounds.Position.Y + 15), new Rectangle(0, 0, 48, 48), Color.White, rotation, new Vector2(24, 24), 2.0f, SpriteEffects.None, 0.0f);
            }

            //Attack 2
            if (state == 2 && isAttack == true && !SeaScreen._isFishing && RestauarntScreen.IsCooking == false)
            {
                postrotation = rotation;
                _spriteBatch.Draw(effect, new Vector2(Bounds.Position.X, Bounds.Position.Y + 15), new Rectangle(0, 0, 48, 48), Color.White, rotation, new Vector2(24, 24), 2.0f, SpriteEffects.None, 0.0f);
                _spriteBatch.Draw(sword, new Vector2(Bounds.Position.X, Bounds.Position.Y + 15), new Rectangle(0, 0, 48, 48), Color.White, rotation + 135.0f, new Vector2(24, 24), 2.0f, SpriteEffects.FlipHorizontally, 0.0f);
            }

            //Attack 3
            if (state == 3 && isAttack == true && !SeaScreen._isFishing && RestauarntScreen.IsCooking == false)
            {
                postrotation = rotation;
                _spriteBatch.Draw(effect, new Vector2(Bounds.Position.X, Bounds.Position.Y + 15), new Rectangle(0, 0, 48, 48), Color.White, rotation, new Vector2(24, 24), 2.0f, SpriteEffects.None, 0.0f);
                _spriteBatch.Draw(sword, new Vector2(Bounds.Position.X, Bounds.Position.Y + 15), new Rectangle(0, 0, 48, 48), Color.White, rotation - 190.0f, new Vector2(24, 24), 2.0f, SpriteEffects.FlipHorizontally, 0.0f);
            }

        }

        bool isDamage;
        public void OnCollision(CollisionEventArgs collisionInfo)
        {
            if (collisionInfo.Other.ToString().Contains("PlatformEntity"))
            {
                Bounds.Position -= collisionInfo.PenetrationVector;
            }
            if (collisionInfo.Other.ToString().Contains("WallEntity"))
            {
                Bounds.Position -= collisionInfo.PenetrationVector;
            }

        }
        //public void Partical()
        //{
        //    for (int i = 0; i < 2; i++)
        //    {
        //        Vector2 smokePos = Bounds.Position + new Vector2(38, 32);
        //        smokePos.X += randomizer.Next(6) - 5;
        //        smokePos.Y += randomizer.Next(6) - 5;
        //        groundList.Add(smokePos);
        //    }
        //    if (groundList.Count == 8)
        //    {
        //        for (int y = 0; y < 4; y++)
        //        {
        //            groundList.RemoveAt(y);
        //            count = 0;
        //        }
        //    }
        //}
        public float postrotation;
        public static bool isAttack;
        public static bool isCheck;
        Vector2 FollowEnemyDirection;
        public void Attack(Enemy enemy)
        {
            //TopLeft
            if (mouseF.Position.X <= Bounds.Position.X - 32 && mouseF.Position.Y < Bounds.Position.Y - 32 && enemy.Bounds.Intersects(ltChack) && isAttack == true && isClick == false)
            {
                FollowEnemyDirection = enemy.Bounds.Position - Bounds.Position;
                if (FollowEnemyDirection != Vector2.Zero)
                {
                    FollowEnemyDirection.Normalize();
                }
                enemy.isDamage = true;
                enemy.hp--;
                enemy.Bounds.Position += FollowEnemyDirection * 20;
            }
            //TopRight
            if (mouseF.Position.X >= Bounds.Position.X - 32 && mouseF.Position.Y < Bounds.Position.Y - 32 && enemy.Bounds.Intersects(rtChack) && isAttack == true && isClick == false)
            {
                FollowEnemyDirection = enemy.Bounds.Position - Bounds.Position;
                if (FollowEnemyDirection != Vector2.Zero)
                {
                    FollowEnemyDirection.Normalize();
                }
                enemy.isDamage = true;
                enemy.hp--;
                enemy.Bounds.Position += FollowEnemyDirection * 20;
            }
            //BotLeft
            if (mouseF.Position.X <= Bounds.Position.X - 32 && mouseF.Position.Y > Bounds.Position.Y - 32 && enemy.Bounds.Intersects(lbChack) && isAttack == true && isClick == false)
            {
                FollowEnemyDirection = enemy.Bounds.Position - Bounds.Position;
                if (FollowEnemyDirection != Vector2.Zero)
                {
                    FollowEnemyDirection.Normalize();
                }
                enemy.isDamage = true;
                enemy.hp--;
                enemy.Bounds.Position += FollowEnemyDirection * 20;
            }
            //BotRight
            if (mouseF.Position.X >= Bounds.Position.X - 32 && mouseF.Position.Y > Bounds.Position.Y - 32 && enemy.Bounds.Intersects(rbChack) && isAttack == true && isClick == false)
            {
                FollowEnemyDirection = enemy.Bounds.Position - Bounds.Position;
                if (FollowEnemyDirection != Vector2.Zero)
                {
                    FollowEnemyDirection.Normalize();
                }
                enemy.isDamage = true;
                enemy.hp--;
                enemy.Bounds.Position += FollowEnemyDirection * 20;
            }

            if (enemy.Bounds.Intersects(mouseF))
            {
                isHit = true;
            }
            else isHit = false;
        }
        
    }
}