using LETHIMCOOK3.Sprite;
using LETHIMCOOK3;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.Collisions;
using MonoGame.Extended.ECS;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace LETHIMCOOK3
{
    public class Enemy : SpriteEntity
    {
        private readonly Game1 game;
        bool isFollow, charge, isDrop;
        CircleF tarGet;
        Vector2 direction, targetSet;
        Texture2D enemytex;
        int count, attackCount, Idraw;
        bool go, left;
        public bool isDead,isDamage;

        Random r;
        Food[] droppedFood;
        string name;
        Vector2 enemyPosition;
        public Enemy(string name, Texture2D enemytex, Food[] droppedFood, int HP, IShapeF circleF)
        {
            this.name = name;
            this.enemytex = enemytex;
            this.droppedFood = droppedFood;
            hp = HP;
            Bounds = circleF;
            framePerSec = 7;
            timePerFream = (float)1 / framePerSec;
            frame = 0;
        }

        public override void Update(GameTime gameTime)
        {
            if (hp > 0)
            {
                attackRange = new CircleF(new Vector2((Bounds.Position.X + 32), (Bounds.Position.Y + 32)), 65);
                tarGet = new CircleF(new Vector2((Bounds.Position.X + 32), (Bounds.Position.Y + 32)), 200);
            }
            if (hp <= 0)
            {
                Bounds.Position = new Vector2(-1000, -1000);
                attackRange.Position = new Vector2(-1000, -1000);
                tarGet.Position = new Vector2(-1000, -1000);
                if (isDead == false)
                {
                    isDead = true;
                    for (int i = 0; i < droppedFood.Length; i++)
                    {
                        Game1.BagList.Add(droppedFood[i]);
                    }
                    Game1.IsPopUp = true;
                }
            }
            if(isDamage == true)
            {
                color = Color.Red;

            }
            else
            {
                color = Color.White;
            }
            if (isDamage == true)
            {
                countDamage += 1;
                {
                    if (countDamage > 20)
                    {
                        countDamage = 0;
                        isDamage = false;
                    }
                }
            }
            UpdateFream((float)gameTime.ElapsedGameTime.TotalSeconds);
        }
        Color color;
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(enemytex, Bounds.Position, new Rectangle(32 * frame, 0, 32, 32), color, 0.0f, Vector2.Zero, 2.0f, SpriteEffects.FlipHorizontally, 0.0f);
            //spriteBatch.DrawRectangle((RectangleF)Bounds, Color.Purple, 3f);
        }
        public void Draww(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(enemytex, Bounds.Position, new Rectangle(80 * frame, 0, 32, 32), color, 0.0f, Vector2.Zero, 2.0f, SpriteEffects.FlipHorizontally, 0.0f);
           // spriteBatch.DrawRectangle((RectangleF)Bounds, Color.Purple, 3f);
        }

        public override void OnCollision(CollisionEventArgs collisionInfo)
        {
            if (collisionInfo.Other.ToString().Contains("WallEntity"))
            {
                Bounds.Position -= collisionInfo.PenetrationVector;
            }
        }
        bool isHit;
        bool soundDamage;
        int countDamage;
        public void Follow(Player player)
        {
            if (Bounds.Intersects(player.Bounds) && !isHit)
            {
                Game1.currentHeart -= 1;
                isHit = true;
                if (soundDamage = false)
                {
                    Game1.soundEffects[9].Play();
                    soundDamage = true;
                }
            } else soundDamage = false;
            if (isHit == true)
            {
                countDamage += 1;
                {
                    if (countDamage > 100)
                    {
                        countDamage = 0;
                        isHit = false;
                    }
                }
            }
            if (player.Bounds.Position.X > Bounds.Position.X)
            {
                left = false;
            }
            if (player.Bounds.Position.X < Bounds.Position.X)
            {
                left = true;
            }
            if (hp > 0)
            {
                if (tarGet.Intersects(player.Bounds))
                {
                    isFollow = true;
                }
                if (attackRange.Intersects(player.Bounds))
                {
                    charge = true;
                }

                if (charge == false)
                {
                    if (isFollow == true)
                    {
                        if (Bounds.Position.X > player.Bounds.Position.X)
                        {
                            Bounds.Position -= new Vector2(2, 0);
                        }
                        if (Bounds.Position.X < player.Bounds.Position.X)
                        {
                            Bounds.Position += new Vector2(2, 0);
                        }
                        if (Bounds.Position.Y > player.Bounds.Position.Y)
                        {
                            Bounds.Position -= new Vector2(0, 2);
                        }
                        if (Bounds.Position.Y < player.Bounds.Position.Y)
                        {
                            Bounds.Position += new Vector2(0, 2);
                        }
                    }
                }

                if (charge == true)
                {
                    direction = player.Bounds.Position - Bounds.Position;
                    if (count == 0)
                    {
                        if (Bounds.Position.X > targetSet.X)
                        {
                            targetSet = player.Bounds.Position + (direction * 2);
                        }
                        if (Bounds.Position.X < targetSet.X)
                        {
                            targetSet = player.Bounds.Position + (direction * 2);
                        }
                        if (Bounds.Position.Y > targetSet.Y)
                        {
                            targetSet = player.Bounds.Position + (direction * 2);
                        }
                        if (Bounds.Position.Y < targetSet.Y)
                        {
                            targetSet = player.Bounds.Position + (direction * 2);
                        }

                    }

                    count++;
                    if (count > 50)
                    {
                        go = true;
                    }
                    if (go == true)
                    {

                        if (Bounds.Position.X > targetSet.X)
                        {
                            Bounds.Position -= new Vector2(20, 0);
                        }
                        if (Bounds.Position.X < targetSet.X)
                        {
                            Bounds.Position += new Vector2(20, 0);
                        }
                        if (Bounds.Position.Y > targetSet.Y)
                        {
                            Bounds.Position -= new Vector2(0, 20);
                        }
                        if (Bounds.Position.Y < targetSet.Y)
                        {
                            Bounds.Position += new Vector2(0, 20);
                        }
                        if (count > 120)
                        {
                            attackCount = 0;
                            go = false;
                            count = 0;
                            charge = false;
                        }

                    }
                }
            }
        }

        void UpdateFream(float elapsed)
        {
            totalElapsed += elapsed;
            if (totalElapsed > timePerFream)
            {
                frame = (frame + 1) % 5;
                totalElapsed -= timePerFream;
            }
        }
    }
}
