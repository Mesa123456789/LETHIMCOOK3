using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using MonoGame.Extended.Input;
using System.Reflection;
namespace LETHIMCOOK3.Screen
{
    public class TitleScreen : screen
    {
        Texture2D menuTexture;
        Game1 game;
        Texture2D startgame, menugame, Tutorial;

        int currentMenu = 1;
        bool keyActiveUp, keyActiveDown;

        public TitleScreen(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            //Load the background texture for the screen
            startgame = game.Content.Load<Texture2D>("menugame (1)");
            menugame = game.Content.Load<Texture2D>("menugame (2)");
            Tutorial = game.Content.Load<Texture2D>("Tutorial");
            this.game = game;
        }
        bool oncursor = false, showSetting = false;
        bool oncursor1 = false;
        bool oncursor2 = false;
        bool oncursor3 = false;
        bool oncursor4 = false;
        bool noSound = false;
        bool noMusic = false;
        bool tutorailUi;
        MouseState msPre, ms;
        public override void Update(GameTime theTime)
        {
            ms = Mouse.GetState();
            Rectangle mouseRec = new Rectangle(ms.X, ms.Y, 30, 30);
            Rectangle startgame = new Rectangle(282, 272, 238, 89);
            Rectangle soundbutton = new Rectangle(292, 384, 30, 30);
            Rectangle ask = new Rectangle(357, 387, 30, 30);
            Rectangle setting = new Rectangle(425, 387, 30, 30);
            Rectangle outgame = new Rectangle(490, 387, 30, 30);

            //***
            Rectangle sound = new Rectangle(341, 212, 30, 30);
            Rectangle music = new Rectangle(341, 259, 30, 30);



            if (mouseRec.Intersects(startgame))
            {
                oncursor = true;
                if (ms.LeftButton == ButtonState.Pressed && !showSetting)
                {
                    ScreenEvent.Invoke(game.GameplayScreen, new EventArgs());
                    game._cameraPosition = new Vector2(400, 225);
                    return;
                }
            }
            else
            {
                oncursor = false;
            }
            if (ms.LeftButton == ButtonState.Pressed && msPre.LeftButton == ButtonState.Released)
            {
                if (mouseRec.Intersects(soundbutton))
                {
                    showSetting = !showSetting;
                }
            }
            if (showSetting)
            {
                if (ms.LeftButton == ButtonState.Pressed && msPre.LeftButton == ButtonState.Released)
                {
                    if (mouseRec.Intersects(sound))
                    {
                        noSound = !noSound;
                    }
                }
                if (ms.LeftButton == ButtonState.Pressed && msPre.LeftButton == ButtonState.Released)
                {
                    if (mouseRec.Intersects(music))
                    {
                        noMusic = !noMusic;
                    }
                }
            }
            if (ms.LeftButton == ButtonState.Pressed && msPre.LeftButton == ButtonState.Released)
            {
                if (mouseRec.Intersects(ask))
                {
                    tutorailUi = !tutorailUi;
                }
            }
            if(tutorailUi) {
            KeyboardState keyboard = Keyboard.GetState();

                if (keyboard.IsKeyDown(Keys.Left))
                {
                    if (keyActiveUp == true)
                    {
                        if (currentMenu > 1)
                        {
                            currentMenu = currentMenu - 1;
                            keyActiveUp = false;
                        }
                    }
                }
                if (keyboard.IsKeyDown(Keys.Right))
                {
                    if (keyActiveDown == true)
                    {
                        if (currentMenu < 3)
                        {
                            currentMenu = currentMenu + 1; keyActiveDown = false;
                        }
                    }
                }
               if (keyboard.IsKeyUp(Keys.Up))
                {
                    keyActiveUp = true;
                }
                if (keyboard.IsKeyUp(Keys.Right))
                {
                    keyActiveDown = true;
                }

            }




                if (mouseRec.Intersects(setting))
            {
                oncursor3 = true;

            }
            else { oncursor3 = false; }
            if (mouseRec.Intersects(outgame))
            {
                oncursor4 = true;
                if (ms.LeftButton == ButtonState.Pressed && !showSetting)
                {
                    game.Exit();
                }
            }
            else { oncursor4 = false; }
            if (showSetting == true)
            {
                oncursor = false;
                oncursor1 = false;
                oncursor2 = false;
                oncursor3 = false;
                oncursor4 = false;
            }
            msPre = ms;
            base.Update(theTime);
        }
        bool p1,p2,p3;
        public override void Draw(SpriteBatch theBatch)
        {
            theBatch.Draw(startgame, Vector2.Zero, Color.White);
            theBatch.Draw(menugame, new Vector2(282, 272), new Rectangle(96, 194, 238, 89), Color.White);
            if (oncursor)
            {
                theBatch.Draw(menugame, new Vector2(282, 272), new Rectangle(96, 74, 238, 89), Color.White);
            }
            theBatch.Draw(menugame, new Vector2(278, 373), new Rectangle(57, 303, 50, 48), Color.White);
            if (oncursor1)
            {
                theBatch.Draw(menugame, new Vector2(279, 373), new Rectangle(58, 367, 50, 48), Color.White);
            }
            theBatch.Draw(menugame, new Vector2(278 + 66, 373), new Rectangle(123, 303, 50, 48), Color.White);
            if (oncursor2)
            {
                theBatch.Draw(menugame, new Vector2(279 + 66, 373), new Rectangle(124, 367, 50, 48), Color.White);
            }
            theBatch.Draw(menugame, new Vector2(278 + 66 + 66, 373), new Rectangle(123 + 66, 303, 50, 48), Color.White);
            if (oncursor3)
            {
                theBatch.Draw(menugame, new Vector2(276 + 66 + 66, 373), new Rectangle(121 + 66, 367, 50, 48), Color.White);
            }
            theBatch.Draw(menugame, new Vector2(278 + 66 + 66 + 66, 373), new Rectangle(123 + 66 + 66, 303, 50, 48), Color.White);
            if (oncursor4)
            {
                theBatch.Draw(menugame, new Vector2(274 + 66 + 66 + 66, 373), new Rectangle(119 + 66 + 66, 367, 50, 48), Color.White);
            }

            if (showSetting)
            {
                theBatch.Draw(menugame, new Vector2(286, 120), new Rectangle(387, 79, 232, 200), Color.White);
                if (noSound)
                {
                    theBatch.Draw(menugame, new Vector2(338, 208), new Rectangle(413, 311, 17, 17), Color.White);
                }
                if (noMusic)
                {
                    theBatch.Draw(menugame, new Vector2(338, 258), new Rectangle(413, 311, 17, 17), Color.White);
                }
            }
            if (tutorailUi)
            {
                if (currentMenu == 1)
                {
                    theBatch.Draw(Tutorial, new Vector2(0 + 82, 0 - 50), new Rectangle(50, 0, 632, 450), Color.White);
                }
                else
                {
                    theBatch.Draw(Tutorial, new Vector2(1000, 1000), new Rectangle(0, 0, 185, 40), Color.White);
                }
                if (currentMenu == 2)
                {
                    theBatch.Draw(Tutorial, new Vector2(0 + 73, 0 - 50), new Rectangle(50 + 632, 0, 632, 450), Color.White);
                }
                else
                {
                    theBatch.Draw(Tutorial, new Vector2(1000, 1000), new Rectangle(0, 40, 185, 40), Color.White);
                }
                if (currentMenu == 3)
                {
                    theBatch.Draw(Tutorial, new Vector2(0 + 65, 0 - 50), new Rectangle(50 + 632 + 632, 0, 632, 450), Color.White);
                }
                else
                {
                    theBatch.Draw(Tutorial, new Vector2(1000, 1000), new Rectangle(0, 0, 185, 40), Color.White);
                }
            }
            base.Draw(theBatch);
        }
    }
}