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
using System.Diagnostics;
using LETHIMCOOK3.Screen;
using LETHIMCOOK3.Sprite;
using LETHIMCOOK3;


namespace LETHIMCOOK3.Screen
{
    public class SeaScreen : screen
    {
        Vector2 fishPos;
        Texture2D fishTexBag;
        string name;
        Texture2D fishTex;
        Fish fish;
        Texture2D texture;
        AnimatedTexture SpriteTexture;
        Player player;
        Vector2 playerPos = Vector2.Zero;
        TiledMap _tiledMap;
        TiledMapRenderer _tiledMapRenderer;
        TiledMapObjectLayer _platformTiledObj;
        private readonly List<IEntity> _entities = new List<IEntity>();
        public readonly CollisionComponent _collisionComponent;
        //Camera _camera;
        Game1 game;
        RectangleF Bounds = new RectangleF(new Vector2(780, 64), new Vector2(40, 60));
        Texture2D _fish, popup, popup2, gotfish, fishing;
        Texture2D salmonmeat, redfishmeat, whalemeat, greenshimpmeat, pinkfishmeat, sharkmeat, shimpmeat, unimeat;
        Texture2D dowfin, normalfish, octopus, salmon, shark, shimai, whale, sharkear, foodTexture, crabmeat, castusWorld, spider;
        //Collecting
        public static List<Enemy> enemyList = new();
        public static List<Fish> BigFishList = new();
        public static List<Fish> SmallFishList = new();
        private Random _random;
        public static bool _isFishing;
        public static double _fishCatchTime;
        public static double _elapsedTime;
        bool Isinteract = false;

        Texture2D jellyfish, hippomeat, jeelyfishmeat, hippowing, hippo, castusWorldC, castus;

        //Tile_FrontRestaurant Tile_Wall_Frontres
        public SeaScreen(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            RestauarntScreen.IsCooking = false;
            popup = game.Content.Load<Texture2D>("interact");
            popup2 = game.Content.Load<Texture2D>("popup");
            _fish = game.Content.Load<Texture2D>("fish");
            fishing = game.Content.Load<Texture2D>("fishing");
            gotfish = game.Content.Load<Texture2D>("gotfish");
            //**ingre
            //salmonmeat = game.Content.Load<Texture2D>("ingre/salmonmeat");
            redfishmeat = game.Content.Load<Texture2D>("ingre/redfishmeat");
            whalemeat = game.Content.Load<Texture2D>("ingre/whaleear");
            greenshimpmeat = game.Content.Load<Texture2D>("ingre/greenshimpmeat");
            pinkfishmeat = game.Content.Load<Texture2D>("ingre/pinkfishmeat");
            sharkmeat = game.Content.Load<Texture2D>("ingre/sharkmeat");
            sharkear = game.Content.Load<Texture2D>("sharkear");
            salmonmeat = game.Content.Load<Texture2D>("ingre/salmonmeat");
            //dowfin, normalfish, octopus, salmon, shark, shimai, whale;
            dowfin = game.Content.Load<Texture2D>("_fish/dowfin");
            normalfish = game.Content.Load<Texture2D>("_fish/normalfish");
            octopus = game.Content.Load<Texture2D>("_fish/octopus");
            salmon = game.Content.Load<Texture2D>("_fish/salmon");
            shark = game.Content.Load<Texture2D>("_fish/shark");
            shimai = game.Content.Load<Texture2D>("_fish/shimai");
            whale = game.Content.Load<Texture2D>("_fish/whale");
            hippo = game.Content.Load<Texture2D>("hippo");
            jellyfish = game.Content.Load<Texture2D>("jellyfish");
            hippomeat = game.Content.Load<Texture2D>("ingre/hippomeat");
            jeelyfishmeat = game.Content.Load<Texture2D>("ingre/jeelyfishmeat");
            hippowing = game.Content.Load<Texture2D>("ingre/hippowing");
            jeelyfishmeat = game.Content.Load<Texture2D>("ingre/jeelyfishmeat");
            castusWorldC = game.Content.Load<Texture2D>("Tree/Collect/castusWorld-export");
            castusWorld = game.Content.Load<Texture2D>("Tree/castusWorld");
            castus = game.Content.Load<Texture2D>("ingre/Cactus");
            //Game1.foodList.Add(new Food("castusWorld", castusWorld, castusWorld, new Vector2(300, 800)));
            //enemyList.Add(new Enemy("hippo", hippo, new Food[2] { new Food("hippomeat", hippomeat, new Rectangle(0, 0, 32, 32), true), new Food("hippowing", hippowing, new Rectangle(0, 0, 32, 32), true) }, 5, new RectangleF(400, 300, 64, 64)));
        

        //enemyList.Add(new Enemy("hippo", hippo, new Food[2] { new Food("hippomeat", hippomeat, new Rectangle(0, 0, 32, 32), true), new Food("hippowing", hippowing, new Rectangle(0, 0, 32, 32), true) }, 5, new RectangleF(400, 300, 64, 64)));

        SmallFishList.Add(new Fish(15, "salmon", salmon, salmonmeat, fishPos)); //dragon
            SmallFishList.Add(new Fish(15, "shimai", shimai, shimai, fishPos));
            BigFishList.Add(new Fish(20, "sharkmeat", shark, sharkmeat, fishPos));
            BigFishList.Add(new Fish(20, "sharkear", shark, sharkear, fishPos));
            BigFishList.Add(new Fish(20, "whaleear", whale, whalemeat, fishPos));
            BigFishList.Add(new Fish(15, "octopus", octopus, octopus, fishPos));
            BigFishList.Add(new Fish(15, "pinkfishmeat", normalfish, pinkfishmeat, fishPos));
            BigFishList.Add(new Fish(15, "redfish", dowfin, redfishmeat, fishPos)); //tiger

            // Game1.BagList.Add(new Food("hippomeat", hippomeat, hippomeat, hippomeat, new Vector2(1250, 68), new RectangleF(145, 740, 32, 32), false));

            var viewportadapter = new BoxingViewportAdapter(game.Window, game.GraphicsDevice, 800, 450);
            Game1._camera = new OrthographicCamera(viewportadapter);//*****/
            game._bgPosition = new Vector2(400, 225);//******//
            game._cameraPosition = new Vector2(440, 0);
            SpriteTexture = new AnimatedTexture(new Vector2(16, 16), 0, 2f, 1f);
            SpriteTexture.Load(game.Content, "Player-Sheet", 5, 4, 10);
            player = new Player(SpriteTexture, playerPos, game, Bounds);
            player.Load(game.Content, "Sword");
            player.Load(game.Content, "Effect");
            ////
            framePerSec = 4;
            timePerFream = (float)1 / framePerSec;
            frame = 4;

            _random = new Random();
            _isFishing = false;

            //Load the background texture for the screen

            _collisionComponent = new CollisionComponent(new RectangleF(0, 0, 1600, 900));


            _tiledMap = game.Content.Load<TiledMap>("Tile_Sea");

            _tiledMapRenderer = new TiledMapRenderer(game.GraphicsDevice, _tiledMap);
            //Get object layers
            foreach (TiledMapObjectLayer layer in _tiledMap.ObjectLayers)
            {
                if (layer.Name == "Tile_Wall_Sea")
                {
                    _platformTiledObj = layer;
                }
            }
            foreach (TiledMapObject obj in _platformTiledObj.Objects)
            {
                Vector2 position = new Vector2(obj.Position.X, obj.Position.Y);
                _entities.Add(new PlatformEntity(game, new RectangleF(position, obj.Size)));
            }

            _entities.Add(player);

            foreach (IEntity entity in _entities)
            {
                _collisionComponent.Insert(entity);


            }
            this.game = game;
        }

        RectangleF mouseRec;
        RectangleF FrontRec;
        RectangleF popupRec, SeaRec;
        public static Vector2 mousepos;
        public static Vector2 posMouse;
        public RectangleF mouseCheck;
        bool popUpfish;
        bool getfish = false;
        bool[] spawn = new bool[27];
        Food[] food = new Food[5];
        bool[] isSpawn = new bool[27];
        public override void Update(GameTime theTime)
        {

            MouseState ms = Mouse.GetState();
            mousepos = Mouse.GetState().Position.ToVector2();
            posMouse = new Vector2(mousepos.X + (game._cameraPosition.X), mousepos.Y + (game._cameraPosition.Y));
            mouseCheck = new Rectangle((int)posMouse.X, (int)posMouse.Y, 24, 24);
            popupRec = new RectangleF(840, 700, 140, 50);
            SeaRec = new RectangleF(400, 750, 1000, 200);
            FrontRec = new RectangleF(740, 0, 100, 10);
            if (player.Bounds.Intersects(FrontRec) && !GameplayScreen.EnterDoor)
            {
                ScreenEvent.Invoke(game.GameplayScreen, new EventArgs());
                game._cameraPosition = new Vector2(400, 478);
                GameplayScreen.player.Bounds.Position = new Vector2(765, 880);
                GameplayScreen.EnterDoor = true;
                return;
            }
            if (!player.Bounds.Intersects(FrontRec))
            {
                GameplayScreen.EnterDoor = false;
            }
            //if (mouseCheck.Intersects(popupRec) && ms.LeftButton == ButtonState.Pressed)
            //{
            //    popupRec.X += 10;
            //}
            if (player.Bounds.Intersects(popupRec))
            {
                Isinteract = true;
            }
            else
            {
                Isinteract = false;
            }
            if (player.Bounds.Intersects(popupRec) && mouseCheck.Intersects(SeaRec) && ms.LeftButton == ButtonState.Pressed && !_isFishing)
            {
                _isFishing = true;
                _fishCatchTime = _random.Next(2, 5); // Random time between 2 to 5 seconds
                _elapsedTime = 0;
            }
            else if (ms.LeftButton == ButtonState.Released)
            {
                _isFishing = false;
            }

            if (_isFishing)
            {
                _elapsedTime += theTime.ElapsedGameTime.TotalSeconds;

                if (_elapsedTime >= _fishCatchTime)
                {
                    _isFishing = false;
                    bool isBigFish = _random.Next(0, 2) == 0;
                    if (isBigFish)
                    {
                        int bigFishIndex = _random.Next(0, BigFishList.Count);
                        var caughtFish = BigFishList[bigFishIndex];
                        Food.OntableAble = true;
                        Game1.BagList.Add(caughtFish);
                        getfish = true;
                        Game1.IsPopUp = true;
                        Console.WriteLine("Big Fish Caught!");
                    }
                    else
                    {
                        int smallFishIndex = _random.Next(0, SmallFishList.Count);
                        var caughtFish = SmallFishList[smallFishIndex];
                        Food.OntableAble = true;
                        getfish = true;
                        Game1.BagList.Add(caughtFish);
                        Game1.IsPopUp = true;
                        Console.WriteLine("Small Fish Caught!");
                    }

                }

            }
            for (int i = enemyList.Count - 1; i >= 0; i--)
            {
                enemyList[i].Follow(player);
            }
            for (int i = enemyList.Count - 1; i >= 0; i--)
            {
                enemyList[i].Update(theTime);
            }
            for (int i = enemyList.Count - 1; i >= 0; i--)
            {
                player.Attack(enemyList[i]);
            }
            for (int i = 0; i < Game1.BagList.Count; i++)
            {
                Game1.BagList[i].Update(theTime);
            }
            for (int i = 32; i < Game1.foodList.Count; i++)
            {
                Game1.foodList[i].Update(theTime, player, this);
            }
            for (int i = BigFishList.Count - 1; i >= 0; i--)
            {
                BigFishList[i].Update(theTime);
            }
            for (int i = SmallFishList.Count - 1; i >= 0; i--)
            {
                SmallFishList[i].Update(theTime);
            }

            foreach (IEntity entity in _entities)
            {
                entity.Update(theTime);
            }
            _collisionComponent.Update(theTime);
            _tiledMapRenderer.Update(theTime);
            //Console.WriteLine("Fish Caught!");
            Game1._camera.LookAt(game._bgPosition + game._cameraPosition);//******//
            player.Update(theTime);
            UpdateFream((float)theTime.ElapsedGameTime.TotalSeconds);
            base.Update(theTime);
            for (int i = 0; i < RestauarntScreen.QuestList.Count; i++)
            {
                RestauarntScreen.QuestList[i].Menuname = spawn[i];
            }
            if (RestauarntScreen.QuestList[6].Menuname == true && isSpawn[6] == false)
            {
                int countEnemy = 1;
                for (int i = 0; i < countEnemy; i++)
                {
                    enemyList.Add(new Enemy("crab", foodTexture, new Food[1] { new Food("crabmeat", crabmeat, new Rectangle(0, 0, 32, 32), false) }, 5, new RectangleF(300, 300, 64, 64)));
                }
                isSpawn[6] = true;
            }
            if (RestauarntScreen.QuestList[26].Menuname == true && isSpawn[26] == false)
            {
                int countEnemy = 1;
                for (int i = 0; i < countEnemy; i++)
                {
                    enemyList.Add(new Enemy("hippo", hippo, new Food[2] { new Food("hippomeat", hippomeat, new Rectangle(0, 0, 32, 32), true), new Food("hippowing", hippowing, new Rectangle(0, 0, 32, 32), true) }, 5, new RectangleF(400, 300, 64, 64)));
                }
                isSpawn[26] = true;
            }
            if (RestauarntScreen.QuestList[19].Menuname == true && isSpawn[19] == false)
            {
                int countEnemy = 3;
                for (int i = 0; i < countEnemy; i++)
                {
                    enemyList.Add(new Enemy("jelly", jellyfish, new Food[1] { new Food("jeelyfishmeat", jeelyfishmeat, new Rectangle(0, 0, 32, 32), true) }, 5, new RectangleF(400, 300, 64, 64)));
                }
                isSpawn[19] = true;
            }
            if (RestauarntScreen.QuestList[23].Menuname == true && isSpawn[23] == false)
            {
                int countEnemy = 1;
                for (int i = 0; i < countEnemy; i++)
                {
                    enemyList.Add(new Enemy("jelly", jellyfish, new Food[1] { new Food("jeelyfishmeat", jeelyfishmeat, new Rectangle(0, 0, 32, 32), true) }, 5, new RectangleF(400, 300, 64, 64)));
                }
                isSpawn[23] = true;
            }
        }

        public void Oncraft(bool menu, int show)
        {
            menu = true;
            spawn[show] = menu;
            Console.WriteLine(" " + menu);





            // Console.WriteLine(menu + " " + enemyINum);
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {

            var transformMatrix = Game1._camera.GetViewMatrix();//******//
            _tiledMapRenderer.Draw(transformMatrix);//******//
            _spriteBatch.End();
            _spriteBatch.Begin(transformMatrix: transformMatrix, samplerState: SamplerState.PointClamp);//******//

            if (Isinteract == true)
            {
                _spriteBatch.Draw(popup, new Rectangle(840, 700, 140, 50), Color.White);
            }
            foreach (Food food in Game1.foodList)
            {
                for (int i = 33; i < Game1.foodList.Count; i++)
                {
                    Game1.foodList[i].Draw(_spriteBatch);
                }
            }
            foreach (Enemy enemy in enemyList)
            {
                for (int i = 0; i < enemyList.Count; i++)
                {
                    enemyList[i].Draw(_spriteBatch);
                }
            }
            foreach (Fish fish in BigFishList)
            {
                for (int i = 0; i < BigFishList.Count; i++)
                {
                    BigFishList[i].Draw(_spriteBatch);
                }
            }
            foreach (Fish fish in SmallFishList)
            {
                for (int i = 0; i < SmallFishList.Count; i++)
                {
                    SmallFishList[i].Draw(_spriteBatch);
                }
            }
            player.Draw(_spriteBatch);
            if (_isFishing == true)
            {
                _spriteBatch.Draw(fishing, new Vector2(player.Bounds.Position.X, player.Bounds.Position.Y + 40), new Rectangle(32 * frame, 0, 32, 150), Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0.0f);
            }

            foreach (Food food in Game1.BagList)
            {
                if (getfish == true)
                {
                    for (int i = 0; i < Game1.BagList.Count; i++)
                    {
                        _spriteBatch.Draw(popup2, new Rectangle((int)player.Bounds.Position.X - 10, (int)player.Bounds.Position.Y - 42, 40, 40), Color.White);
                        _spriteBatch.Draw(Game1.BagList[i].foodTexture, new Rectangle((int)player.Bounds.Position.X - 5, (int)player.Bounds.Position.Y - 40, 32, 32), Color.White);
                    }
                }
                CountTime(250);
            }




        }
        int countPopUp;
        public void CountTime(int timePopup)
        {
            countPopUp += 1;
            {
                if (countPopUp > timePopup)
                {
                    countPopUp = 0;
                    getfish = false;

                }
            }
        }
        public int frame;
        public int framePerSec;
        public float totalElapsed;
        public float timePerFream;
        void UpdateFream(float elapsed)
        {
            totalElapsed += elapsed;
            if (totalElapsed > timePerFream)
            {
                frame = (frame + 1) % 4;
                totalElapsed -= timePerFream;
            }
        }

    }
}