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
using LETHIMCOOK3.Sprite;
using MonoGame.Extended.Collections;
using System.Reflection.Metadata;



namespace LETHIMCOOK3.Screen
{
    public class CandyScreen : screen
    {
        public List<Enemy> enemyList = new();
        Texture2D popup;
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
        RectangleF Bounds = new RectangleF(new Vector2(1500, 400), new Vector2(40, 60)); //new Vector2(1500, 400)
        public Texture2D book;
        Texture2D ui;
        public Texture2D uiHeart, pinkslime, smileeggs, pork, sheepmeat, sheep, wipcream;

        //Tile_FrontRestaurant Tile_Wall_Frontres
        public CandyScreen(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            pinkslime = game.Content.Load<Texture2D>("pinksmaile");
            smileeggs = game.Content.Load<Texture2D>("ingre/smileeggs");
            pork = game.Content.Load<Texture2D>("ingre/pork");
            sheepmeat = game.Content.Load<Texture2D>("ingre/sheepmeat");
            sheep = game.Content.Load<Texture2D>("sheep");
            wipcream = game.Content.Load<Texture2D>("ingre/wipcream");

            game._cameraPosition = new Vector2(800, 100);
            popup = game.Content.Load<Texture2D>("popup");
            var viewportadapter = new BoxingViewportAdapter(game.Window, game.GraphicsDevice, 800, 450);
            Game1._camera = new OrthographicCamera(viewportadapter);//******//
            game._bgPosition = new Vector2(400, 225);//******//
            ui = game.Content.Load<Texture2D>("ui");
            uiHeart = game.Content.Load<Texture2D>("uiHeart");
            book = game.Content.Load<Texture2D>("book");

            SpriteTexture = new AnimatedTexture(new Vector2(16,16), 0, 2f, 1f);
            SpriteTexture.Load(game.Content, "Player-Sheet", 5, 4, 10);
            player = new Player(SpriteTexture, new Vector2(1500, 400),game, Bounds);
            player.Load(game.Content, "Sword");
            player.Load(game.Content, "Effect");
            //Load the background texture for the screen
            //enemyList.Add(new Enemy("pinksmaile", pinkslime, new Food[2] { new Food("pork", pork, new Rectangle(0, 0, 32, 32), true), new Food("smileeggs", smileeggs, new Rectangle(0, 0, 32, 32), true) }, 5, new RectangleF(1500,800, 64, 64)));
            //enemyList.Add(new Enemy("sheep", sheep, new Food[2] { new Food("sheepmeat", sheepmeat, new Rectangle(0, 0, 32, 32), true), new Food("wipcream", wipcream, new Rectangle(0, 0, 32, 32), true) }, 5, new RectangleF(400, 300, 64, 64)));
        

        _collisionComponent = new CollisionComponent(new RectangleF(0, 0, 1600, 900));


            _tiledMap = game.Content.Load<TiledMap>("Map_Candy");

            _tiledMapRenderer = new TiledMapRenderer(game.GraphicsDevice, _tiledMap);
            //Get object layers
            foreach (TiledMapObjectLayer layer in _tiledMap.ObjectLayers)
            {
                if (layer.Name == "Wall")
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

        RectangleF doorRec = new RectangleF(200, 100, 100, 100);
        RectangleF FrontRec = new RectangleF(1580, 400, 20, 100);
        public RectangleF mouseRec;
        RectangleF bookRec;
        bool OnCursor1;
        bool[] spawn = new bool[27];
        Food[] food = new Food[5];
        bool[] isSpawn = new bool[27];
        public override void Update(GameTime theTime)
        {
            if (player.Bounds.Intersects(FrontRec) && !GameplayScreen.EnterDoor)
            {
                ScreenEvent.Invoke(game.GameplayScreen, new EventArgs());
                game._cameraPosition = new Vector2(0, 200);
                GameplayScreen.player.Bounds.Position = new Vector2(50, 450);
                GameplayScreen.EnterDoor = true;
                return;
            }
            if (!player.Bounds.Intersects(FrontRec))
            {
                GameplayScreen.EnterDoor = false;
            }
            MouseState ms = Mouse.GetState();

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
            for (int i = 48; i < Game1.foodList.Count; i++)
            {
                Game1.foodList[i].Update(theTime);
            }
            for (int i = 0; i < enemyList.Count; i++)
            {
                enemyList[i].Update(theTime);
            }
            foreach (IEntity entity in _entities)
            {
                entity.Update(theTime);
            }
            _collisionComponent.Update(theTime);
            _tiledMapRenderer.Update(theTime);
            Game1._camera.LookAt(game._bgPosition + game._cameraPosition);//******//
            player.Update(theTime);
            base.Update(theTime);

            for (int i = 0; i < RestauarntScreen.QuestList.Count; i++)
            {
                RestauarntScreen.QuestList[i].Menuname = spawn[i];
            }
            if (RestauarntScreen.QuestList[23].Menuname == true && isSpawn[23] == false)
            {
                int countEnemy = 3;
                for (int i = 0; i < countEnemy; i++)
                {
                    enemyList.Add(new Enemy("pinksmaile", pinkslime, new Food[2] { new Food("pork", pork, new Rectangle(0, 0, 32, 32), true), new Food("smileeggs", smileeggs, new Rectangle(0, 0, 32, 32), true) }, 5, new RectangleF(400 + (i * 32), 300 + (i * 32), 64, 64)));
                }
                isSpawn[23] = true;
            }
            if (RestauarntScreen.QuestList[21].Menuname == true && isSpawn[21] == false)
            {
                int countEnemy = 3;
                for (int i = 0; i < countEnemy; i++)
                {
                    enemyList.Add(new Enemy("pinksmaile", pinkslime, new Food[2] { new Food("pork", pork, new Rectangle(0, 0, 32, 32), true), new Food("smileeggs", smileeggs, new Rectangle(0, 0, 32, 32), true) }, 5, new RectangleF(400 + (i * 32), 300 + (i * 32), 64, 64)));
                }
                isSpawn[21] = true;
            }
            if (RestauarntScreen.QuestList[20].Menuname == true && isSpawn[20] == false)
            {
                int countEnemy = 1;
                for (int i = 0; i < countEnemy; i++)
                {
                    enemyList.Add(new Enemy("sheep", sheep, new Food[2] { new Food("sheepmeat", sheepmeat, new Rectangle(0, 0, 32, 32), true), new Food("wipcream", wipcream, new Rectangle(0, 0, 32, 32), true) }, 5, new RectangleF(400, 300, 64, 64)));
                }
                isSpawn[20] = true;
            }
            if (RestauarntScreen.QuestList[7].Menuname == true && isSpawn[7] == false)
            {
                int countEnemy = 1;
                for (int i = 0; i < countEnemy; i++)
                {
                    enemyList.Add(new Enemy("sheep", sheep, new Food[2] { new Food("sheepmeat", sheepmeat, new Rectangle(0, 0, 32, 32), true), new Food("wipcream", wipcream, new Rectangle(0, 0, 32, 32), true) }, 5, new RectangleF(400, 300, 64, 64)));
                }
                isSpawn[7] = true;
            }
            if (RestauarntScreen.QuestList[24].Menuname == true && isSpawn[24] == false)
            {
                int countEnemy = 1;
                for (int i = 0; i < countEnemy; i++)
                {
                    enemyList.Add(new Enemy("pinksmaile", pinkslime, new Food[2] { new Food("pork", pork, new Rectangle(0, 0, 32, 32), true), new Food("smileeggs", smileeggs, new Rectangle(0, 0, 32, 32), true) }, 5, new RectangleF(400 + (i * 32), 300 + (i * 32), 64, 64)));
                }
                isSpawn[24] = true;
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
            foreach (Food food in Game1.foodList)
            {
                for (int i = 49; i < Game1.foodList.Count; i++)
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
            player.Draw(_spriteBatch);
    


            //_spriteBatch.Draw(popup, new Rectangle((int)doorRec.X, (int)doorRec.Y, (int)doorRec.Width, (int)doorRec.Height), Color.White);


        }


    }
}

