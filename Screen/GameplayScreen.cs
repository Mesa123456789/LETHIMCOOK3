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
using System.Reflection.Metadata;
using System.ComponentModel;
using System.Net.NetworkInformation;
using LETHIMCOOK3.Screen;
using LETHIMCOOK3.Sprite;
using LETHIMCOOK3;
using System.Data.SqlTypes;


namespace LETHIMCOOK3.Screen
{
    public class GameplayScreen : screen
    {

        RestauarntScreen res;
        Texture2D texture;
        AnimatedTexture SpriteTexture;
        public static Player player;
        Enemy enemy;
        TiledMap _tiledMap;
        TiledMapRenderer _tiledMapRenderer;
        TiledMapObjectLayer _platformTiledObj;
        private readonly List<IEntity> _entities = new List<IEntity>();
        public readonly CollisionComponent _collisionComponent;
        Game1 game;

        public RectangleF Bounds = new RectangleF(new Vector2(750, 440), new Vector2(40, 64));
        Texture2D foodTexture, crabmeat;
        Texture2D hippo, hippomeat;
        Texture2D chicken, chickenmeat;
        Texture2D rat, cheese, pig, pork;
        Texture2D slime, rainbowsmilemeat;
        Texture2D pinkslime, pinksmilemeat, cowmeat, sheepmeat, sheep, mandreakC;
        Texture2D icebear, wipcream;
        Texture2D jellyfish;
        Texture2D popup;
        Texture2D enemytex, enemytexbag, QuestUI, milk, CrispyPork, newstlye;
        bool Istrue;
        bool[] spawn = new bool[27];
        Food[] food = new Food[5];
        bool[] isSpawn = new bool[27];
        ///***new
        Texture2D coriander, grass, greendimon, hippowing, jeelyfishmeat, lemon, meatball, icecream, candysnail, candysnailC;
        Texture2D Mendrek, noodle, pinkdimon, seafood, shumai, smileeggs;
        Texture2D stone, suki, tempura, purpledimon, Board, BoardInteract,tempuraenemy;
        Texture2D castusWorld, Gem_Tree, Greengemt, Healing_Tree, IceCream, Nuddle_Tree
            , NuddleSong, Pinkgemt, PinkIce, PinkIce_Tree, Pongneung, pumkinWorld, Rice,
            saladWorld,SeaUrchin,Tomato_Tree,tomatoWorld,Violetgemt, Pumpkin,rice,salad, Squid, unimeat,tomato;
        Texture2D castusWorldC, GreengemtC, Healing_TreeC, IceCreamC
    , NuddleSongC, PinkgemtC, PinkIceC, PongneungC, pumkinWorldC, RiceC,
    saladWorldC, SeaUrchinC, tomatoWorldC, VioletgemtC, PumpkinC, spider, castus, Door;

        

        int enemyINum;

        Vector2 playerPos;// = new Vector2(player.Bounds.Position.X, player.Bounds.Position.Y);
        public GameplayScreen(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            //***new
            milk = game.Content.Load<Texture2D>("ingre/milk");
            popup = game.Content.Load<Texture2D>("popup");
            
            hippo = game.Content.Load<Texture2D>("hippo");
            chicken = game.Content.Load<Texture2D>("chicken");
            pig = game.Content.Load<Texture2D>("pig");
            
            rat = game.Content.Load<Texture2D>("rat");
            slime = game.Content.Load<Texture2D>("slime");
            icebear = game.Content.Load<Texture2D>("icebear");
            
            chickenmeat = game.Content.Load<Texture2D>("ingre/chickenmeat");
            cheese = game.Content.Load<Texture2D>("ingre/cheese");
            rainbowsmilemeat = game.Content.Load<Texture2D>("ingre/rainbowsmilemeat");
            icecream = game.Content.Load<Texture2D>("ingre/icecream");

            tempuraenemy = game.Content.Load<Texture2D>("tempura");
            spider = game.Content.Load<Texture2D>("spiderx1");
            ///****
            Squid = game.Content.Load<Texture2D>("ingre/Squid");
            salad = game.Content.Load<Texture2D>("ingre/salad");
            candysnail = game.Content.Load<Texture2D>("ingre/candy snail");
            Pumpkin = game.Content.Load<Texture2D>("ingre/Pumpkin");
            icecream = game.Content.Load<Texture2D>("ingre/icecream");
            CrispyPork = game.Content.Load<Texture2D>("ingre/Crispy Pork");
            cowmeat = game.Content.Load<Texture2D>("ingre/cow_meat");
            sheepmeat = game.Content.Load<Texture2D>("ingre/sheepmeat");
            sheep = game.Content.Load<Texture2D>("sheep");
            foodTexture = game.Content.Load<Texture2D>("crab"); 
            crabmeat = game.Content.Load<Texture2D>("ingre/crabmeat");
            noodle = game.Content.Load<Texture2D>("ingre/noodle");
            Gem_Tree = game.Content.Load<Texture2D>("tree/Gem_Tree");
            Greengemt = game.Content.Load<Texture2D>("tree/Greengemt");
            Healing_Tree = game.Content.Load<Texture2D>("tree/Healing_Tree");
            IceCream = game.Content.Load<Texture2D>("tree/IceCream");
            Nuddle_Tree = game.Content.Load<Texture2D>("tree/Nuddle_Tree");
            NuddleSong = game.Content.Load<Texture2D>("tree/NuddleSong");
            Pinkgemt = game.Content.Load<Texture2D>("tree/Pinkgemt");
            PinkIce = game.Content.Load<Texture2D>("tree/PinkIce");
            PinkIce_Tree = game.Content.Load<Texture2D>("tree/PinkIce_Tree");
            Pongneung = game.Content.Load<Texture2D>("tree/Pong neung");
            pumkinWorld = game.Content.Load<Texture2D>("tree/pumkinWorld");
            Rice = game.Content.Load<Texture2D>("tree/Rice");
            saladWorld = game.Content.Load<Texture2D>("tree/saladWorld");
            SeaUrchin = game.Content.Load<Texture2D>("tree/SeaUrchin");
            Tomato_Tree = game.Content.Load<Texture2D>("tree/Tomato_Tree");
            tomatoWorld = game.Content.Load<Texture2D>("tree/tomatoWorld");
            Violetgemt = game.Content.Load<Texture2D>("tree/Violetgemt");
            QuestUI = game.Content.Load<Texture2D>("QuestUI");
            Board = game.Content.Load<Texture2D>("Board_");
            BoardInteract = game.Content.Load<Texture2D>("BoardInteract");
            newstlye = game.Content.Load<Texture2D>("newstlye");
            grass = game.Content.Load<Texture2D>("ingre/grass");
            greendimon = game.Content.Load<Texture2D>("ingre/greendimon");
            pinksmilemeat = game.Content.Load<Texture2D>("ingre/pinksmilemeat");
            meatball = game.Content.Load<Texture2D>("ingre/meatball");
            Mendrek = game.Content.Load<Texture2D>("ingre/Mendrek");
            noodle = game.Content.Load<Texture2D>("ingre/noodle");
            pinkdimon = game.Content.Load<Texture2D>("ingre/pinkdimon");
            seafood = game.Content.Load<Texture2D>("ingre/seafood");
            shumai = game.Content.Load<Texture2D>("ingre/shumai");
            
            stone = game.Content.Load<Texture2D>("ingre/stone");
            tempura = game.Content.Load<Texture2D>("ingre/tempura");
            purpledimon = game.Content.Load<Texture2D>("ingre/purpledimon");
            rice = game.Content.Load<Texture2D>("ingre/rice");
            unimeat = game.Content.Load<Texture2D>("ingre/unimeat");
            tomato = game.Content.Load<Texture2D>("ingre/tomato");
            castusWorld = game.Content.Load<Texture2D>("tree/castusWorld");
            Healing_Tree = game.Content.Load<Texture2D>("food/Healing_Tree");
            Door = game.Content.Load<Texture2D>("Door");

            candysnail = game.Content.Load<Texture2D>("tree/candy snail-export");
            candysnailC = game.Content.Load<Texture2D>("tree/Collect/candy snail");

            //***collect
            GreengemtC = game.Content.Load<Texture2D>("tree/Collect/Greengem_export");
            Healing_TreeC = game.Content.Load<Texture2D>("tree/Collect/Healing_Tree-export");
            IceCreamC = game.Content.Load<Texture2D>("tree/Collect/IceCream-export");
            NuddleSongC = game.Content.Load<Texture2D>("tree/Collect/NuddleSong-export");
            PinkgemtC = game.Content.Load<Texture2D>("tree/Collect/Pinkgem_export");
            PinkIceC = game.Content.Load<Texture2D>("tree/Collect/PinkIce-export");
            PongneungC = game.Content.Load<Texture2D>("tree/Collect/Pong neung-export");
            pumkinWorldC = game.Content.Load<Texture2D>("tree/Collect/pumkinWorld");
            RiceC = game.Content.Load<Texture2D>("tree/Collect/Rice-export");
            saladWorldC = game.Content.Load<Texture2D>("tree/Collect/saladWorld");
            SeaUrchinC = game.Content.Load<Texture2D>("tree/Collect/SeaUrchin-export");
            tomatoWorldC = game.Content.Load<Texture2D>("tree/Collect/tomatoWorld-export");
            VioletgemtC = game.Content.Load<Texture2D>("tree/Collect/Violetgem_export");
            castusWorldC = game.Content.Load<Texture2D>("tree/Collect/castusWorld-export");
            mandreakC = game.Content.Load<Texture2D>("tree/Collect/Mendrek_export");
            castus = game.Content.Load<Texture2D>("ingre/Cactus");

           
            //Collecting Map Rasteurunt
            Game1.foodList.Add(new Food("Mendrek", Mendrek, mandreakC, Mendrek, new Vector2(139, 650),new Rectangle(139, 650, 32,32),false));
            Game1.foodList.Add(new Food("Mendrek", Mendrek, mandreakC, Mendrek, new Vector2(139, 690), new RectangleF(139, 690, 32, 32), false));
            Game1.foodList.Add(new Food("Mendrek", Mendrek, mandreakC, Mendrek, new Vector2(181, 650), new RectangleF(181, 650, 32, 32), false));
            Game1.foodList.Add(new Food("Mendrek", Mendrek, mandreakC, Mendrek, new Vector2(181, 690), new RectangleF(181, 690, 32, 32), false));
            
            Game1.foodList.Add(new Food("grass", Pongneung, PongneungC, grass, new Vector2(396, 728),new RectangleF(396, 738, 32,32),false));
            Game1.foodList.Add(new Food("grass", Pongneung, PongneungC, grass, new Vector2(396, 762), new RectangleF(396, 772, 32, 32), false));
            Game1.foodList.Add(new Food("grass", Pongneung, PongneungC, grass, new Vector2(438, 728), new RectangleF(396, 738, 32, 32), false));
            Game1.foodList.Add(new Food("grass", Pongneung, PongneungC, grass, new Vector2(438, 762), new RectangleF(396, 772, 32, 32), false));

            Game1.foodList.Add(new Food("noodle", NuddleSong, NuddleSongC, noodle, new Vector2(284, 628), new RectangleF(145, 740, 32, 32), false));
            Game1.foodList.Add(new Food("noodle", NuddleSong, NuddleSongC, noodle, new Vector2(286, 662), new RectangleF(145, 740, 32, 32), false));
            Game1.foodList.Add(new Food("noodle", NuddleSong, NuddleSongC, noodle, new Vector2(326, 628), new RectangleF(145, 740, 32, 32), false));
            Game1.foodList.Add(new Food("noodle", NuddleSong, NuddleSongC, noodle, new Vector2(328, 662), new RectangleF(145, 740, 32, 32), false));

            Game1.foodList.Add(new Food("greendimon", Greengemt, GreengemtC, greendimon, new Vector2(586, 604), new RectangleF(145, 740, 32, 32), false));
            Game1.foodList.Add(new Food("purpledimon", Violetgemt, VioletgemtC, purpledimon, new Vector2(500, 612), new RectangleF(145, 740, 32, 32), false));
            Game1.foodList.Add(new Food("purpledimon", Violetgemt, VioletgemtC, purpledimon, new Vector2(544, 612), new RectangleF(145, 740, 32, 32), false));
            Game1.foodList.Add(new Food("pinkdimon", Pinkgemt, PinkgemtC, pinkdimon, new Vector2(522, 620), new RectangleF(145, 740, 32, 32), false));
            Game1.foodList.Add(new Food("pinkdimon", Pinkgemt, PinkgemtC, pinkdimon, new Vector2(564, 620), new RectangleF(145, 740, 32, 32), false));

            Game1.foodList.Add(new Food("rice", Rice, RiceC, rice, new Vector2(564, 738), new RectangleF(564, 738, 32, 32), false));
            Game1.foodList.Add(new Food("rice", Rice, RiceC, rice, new Vector2(564, 772), new RectangleF(564, 772, 32, 32), false));
            Game1.foodList.Add(new Food("rice", Rice, RiceC, rice, new Vector2(522, 738), new RectangleF(522, 738, 32, 32), false));
            Game1.foodList.Add(new Food("rice", Rice, RiceC, rice, new Vector2(522, 772), new RectangleF(522, 772, 32, 32), false));

            Game1.foodList.Add(new Food("Pumkin", pumkinWorld, pumkinWorldC, Pumpkin, new Vector2(145, 738), new RectangleF(145, 740, 32, 32), false));
            Game1.foodList.Add(new Food("Pumkin", pumkinWorld, pumkinWorldC, Pumpkin, new Vector2(145, 772), new RectangleF(145, 740, 32, 32), false));
            Game1.foodList.Add(new Food("Pumkin", pumkinWorld, pumkinWorldC, Pumpkin, new Vector2(155 + 28, 738), new RectangleF(145, 740, 32, 32), false));
            Game1.foodList.Add(new Food("Pumkin", pumkinWorld, pumkinWorldC, Pumpkin, new Vector2(155 + 28, 772), new RectangleF(145, 740, 32, 32), false));

            Game1.foodList.Add(new Food("salad", saladWorld, saladWorldC, salad, new Vector2(310, 740), new RectangleF(145, 740, 32, 32), false));
            Game1.foodList.Add(new Food("salad", saladWorld, saladWorldC, salad, new Vector2(310, 774), new RectangleF(145, 740, 32, 32), false));
            Game1.foodList.Add(new Food("salad", saladWorld, saladWorldC, salad, new Vector2(268, 740), new RectangleF(145, 740, 32, 32), false));
            Game1.foodList.Add(new Food("salad", saladWorld, saladWorldC, salad, new Vector2(268, 774), new RectangleF(145, 740, 32, 32), false));

            Game1.foodList.Add(new Food("tomato", tomatoWorld, tomatoWorldC, tomato, new Vector2(456, 670), new RectangleF(145, 740, 32, 32), false));
            Game1.foodList.Add(new Food("tomato", tomatoWorld, tomatoWorldC, tomato, new Vector2(414, 671), new RectangleF(145, 740, 32, 32), false));
            Game1.foodList.Add(new Food("tomato", tomatoWorld, tomatoWorldC, tomato, new Vector2(456, 637), new RectangleF(145, 740, 32, 32), false));
            Game1.foodList.Add(new Food("tomato", tomatoWorld, tomatoWorldC, tomato, new Vector2(414, 637), new RectangleF(145, 740, 32, 32), false));
            //36 sea
            Game1.foodList.Add(new Food("Cactus", castusWorld, castusWorldC, castus, new Vector2(100, 200-10), new RectangleF(145, 740, 32, 32), false));
            Game1.foodList.Add(new Food("Cactus", castusWorld, castusWorldC, castus, new Vector2(60, 240), new RectangleF(145, 740, 32, 32), false));
            Game1.foodList.Add(new Food("Cactus", castusWorld, castusWorldC, castus, new Vector2(150, 240), new RectangleF(145, 740, 32, 32), false));
            Game1.foodList.Add(new Food("Cactus", castusWorld, castusWorldC, castus, new Vector2(100, 270), new RectangleF(145, 740, 32, 32), false));
            Game1.foodList.Add(new Food("Cactus", castusWorld, castusWorldC, castus, new Vector2(100, 240-10), new RectangleF(145, 740, 32, 32), false));

            Game1.foodList.Add(new Food("unimeat", SeaUrchin, SeaUrchinC, unimeat, new Vector2(1200, 400), new RectangleF(145, 740, 32, 32), false));
            Game1.foodList.Add(new Food("unimeat", SeaUrchin, SeaUrchinC, unimeat, new Vector2(1280, 420), new RectangleF(145, 740, 32, 32), false));
            Game1.foodList.Add(new Food("unimeat", SeaUrchin, SeaUrchinC, unimeat, new Vector2(1250, 450), new RectangleF(145, 740, 32, 32), false));
            Game1.foodList.Add(new Food("unimeat", SeaUrchin, SeaUrchinC, unimeat, new Vector2(1250, 500), new RectangleF(145, 740, 32, 32), false));
            Game1.foodList.Add(new Food("unimeat", SeaUrchin, SeaUrchinC, unimeat, new Vector2(1200, 550), new RectangleF(145, 740, 32, 32), false));
            Game1.foodList.Add(new Food("unimeat", SeaUrchin, SeaUrchinC, unimeat, new Vector2(1250, 350), new RectangleF(145, 740, 32, 32), false));

            Game1.foodList.Add(new Food("candysnail", candysnail, candysnailC, candysnail, new Vector2(400, 200 - 10+100), new RectangleF(145, 740, 32, 32), false));
            Game1.foodList.Add(new Food("candysnail", candysnail, candysnailC, candysnail, new Vector2(460, 240+100), new RectangleF(145, 740, 32, 32), false));
            Game1.foodList.Add(new Food("candysnail", candysnail, candysnailC, candysnail, new Vector2(340, 240+100), new RectangleF(145, 740, 32, 32), false));
            Game1.foodList.Add(new Food("candysnail", candysnail, candysnailC, candysnail, new Vector2(400, 270+100), new RectangleF(145, 740, 32, 32), false));
            Game1.foodList.Add(new Food("candysnail", candysnail, candysnailC, candysnail, new Vector2(400, 240 - 10+100), new RectangleF(145, 740, 32, 32), false));
            //48 candy
            Game1.foodList.Add(new Food("pinksmaile", PinkIce, PinkIceC, pinksmilemeat, new Vector2(1160, 770), new RectangleF(145, 740, 32, 32), false));
            Game1.foodList.Add(new Food("pinksmaile", PinkIce, PinkIceC, pinksmilemeat, new Vector2(1380, 720), new RectangleF(145, 740, 32, 32), false));
            Game1.foodList.Add(new Food("pinksmaile", PinkIce, PinkIceC, pinksmilemeat, new Vector2(1210, 700), new RectangleF(145, 740, 32, 32), false));

            Game1.foodList.Add(new Food("icecream", IceCream, IceCreamC, icecream, new Vector2(1394,130), new RectangleF(145, 740, 32, 32), false));
            Game1.foodList.Add(new Food("icecream", IceCream, IceCreamC, icecream, new Vector2(1290, 174), new RectangleF(145, 740, 32, 32), false));
            Game1.foodList.Add(new Food("icecream", IceCream, IceCreamC, icecream, new Vector2(1285, 105), new RectangleF(145, 740, 32, 32), false));
            Game1.foodList.Add(new Food("icecream", IceCream, IceCreamC, icecream, new Vector2(1393, 68), new RectangleF(145, 740, 32, 32), false));
            Game1.foodList.Add(new Food("icecream", IceCream, IceCreamC, icecream, new Vector2(1351, 50), new RectangleF(145, 740, 32, 32), false));
            Game1.foodList.Add(new Food("icecream", IceCream, IceCreamC, icecream, new Vector2(1250, 68), new RectangleF(145, 740, 32, 32), false));

            // Game1.foodList.

            

            var viewportadapter = new BoxingViewportAdapter(game.Window, game.GraphicsDevice, 800, 450);
            Game1._camera = new OrthographicCamera(viewportadapter);//******//
            game._bgPosition = new Vector2(400, 225);//******//
            game._cameraPosition = new Vector2(400, 200);
            SpriteTexture = new AnimatedTexture(new Vector2(16, 16), 0, 2f, 1f);
            SpriteTexture.Load(game.Content, "Player-Sheet", 5, 4, 10);
            player = new Player(SpriteTexture, new Vector2(1500, 400), game, Bounds);
            player.Load(game.Content, "Sword");
            player.Load(game.Content, "Effect");
            //Load the background texture for the screen
            _collisionComponent = new CollisionComponent(new RectangleF(0, 0, 1600, 900));
            _tiledMap = game.Content.Load<TiledMap>("Tile_FrontRestaurant");
            _tiledMapRenderer = new TiledMapRenderer(game.GraphicsDevice, _tiledMap);
            //Get object layers
            foreach (TiledMapObjectLayer layer in _tiledMap.ObjectLayers)
            {
                if (layer.Name == "Tile_Wall_Frontres")
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
        RectangleF doorRec = new RectangleF(750, 400, 100, 20);
        RectangleF SeaMapRec = new RectangleF(700, 880, 100, 10);
        RectangleF CandyMapRec = new RectangleF(0, 400, 50, 100);
        RectangleF mouseRec;
        RectangleF BoardInteractRec = new RectangleF(900, 400, 96, 64);
        Vector2 popupPos;
        public static Vector2 mousepos;
        public static Vector2 posMouse;
        public RectangleF mouseCheck;
        public static bool EnterDoor = false;
        bool questInteract = false;
        public static bool openQuest = false;
        bool onRandom = true;
        bool onQuest = false;
        static Random randomQuest = new Random();
        public static int getQuest, getQuest2, getQuest3;
        MouseState ms, msPre;
        int count = 0;
        bool paper = false;
        bool inSide = false;
        RectangleF exitway = new RectangleF(1320, 52, 128, 128);
        public override void Update(GameTime theTime)
        {

            ms = Mouse.GetState();
            mousepos = Mouse.GetState().Position.ToVector2();
            posMouse = new Vector2(mousepos.X + (game._cameraPosition.X), mousepos.Y + (game._cameraPosition.Y));
            mouseCheck = new Rectangle((int)posMouse.X, (int)posMouse.Y, 24, 24);

            popupPos = new Vector2(700, 400);
            popupRec = new Rectangle(700, 400, 100, 50);
            //if (mouseCheck.Intersects(popupRec) && ms.LeftButton == ButtonState.Pressed)
            //{
            //    popupRec.X += 10;
            //}

            if (!player.Bounds.Intersects(doorRec) && !player.Bounds.Intersects(CandyMapRec) && !player.Bounds.Intersects(SeaMapRec))
            {
                GameplayScreen.EnterDoor = false;
            }
            if (player.Bounds.Intersects(doorRec) && !EnterDoor)
            {
                if (inSide == false)
                {
                    Game1.soundEffects[6].Play();
                }
                EnterDoor = true;

                RestauarntScreen.IsCooking = true;
                ScreenEvent.Invoke(game.RestauarntScreen, new EventArgs());
                return;
            }
            if (player.Bounds.Intersects(CandyMapRec) && !EnterDoor)
            {
                EnterDoor = true;
                ScreenEvent.Invoke(game.CandyScreen, new EventArgs());
                game._cameraPosition = new Vector2(800, 200);
                return;
            }
            if (player.Bounds.Intersects(SeaMapRec) && !EnterDoor)
            {
                EnterDoor = true;
                ScreenEvent.Invoke(game.SeaScreen, new EventArgs());
                // player.Bounds.Position = new Vector2(780, 64);
                game._cameraPosition = new Vector2(440, 0);
                return;
            }

            if (player.Bounds.Intersects(BoardInteractRec))
            {
                questInteract = true;
                if (mouseCheck.Intersects(BoardInteractRec) && ms.LeftButton == ButtonState.Pressed)
                {
                    openQuest = true;
                    Game1.closeXBox = false;
                }
            }
            else
            {
                onRandom = false;
                openQuest = false;
                questInteract = false;
            }
            if(Game1.MenuList.Count >= 10)
            {
                openway = true;
            }
            
            if (player.Bounds.Intersects(exitway) && openway == true)
            {
                game.Exit();
            }
            if (openQuest == true)
            {
                if(paper == false)
                {
                    Game1.soundEffects[11].Play();
                    paper = true;
                }
                onQuest = randomQuest.Next(0, 2) == 0;
                if (onQuest && !onRandom)
                {
                    for (int i = 0; i < 1; i++)
                    {
                        getQuest = randomQuest.Next(0, RestauarntScreen.QuestList.Count);
                        getQuest2 = randomQuest.Next(0, RestauarntScreen.QuestList.Count);
                        getQuest3 = randomQuest.Next(0, RestauarntScreen.QuestList.Count);
                        if (getQuest == getQuest2 || getQuest == getQuest3)
                        {
                            getQuest = randomQuest.Next(0, RestauarntScreen.QuestList.Count);
                        }
                        if (getQuest2 == getQuest3 || getQuest2 == getQuest)
                        {
                            getQuest2 = randomQuest.Next(0, RestauarntScreen.QuestList.Count);
                        }
                        if (getQuest3 == getQuest2 || getQuest == getQuest3)
                        {
                            getQuest3 = randomQuest.Next(0, RestauarntScreen.QuestList.Count);
                        }
                        //RestauarntScreen.QuestList[getQuest]. = true;
                        Console.WriteLine(RestauarntScreen.QuestList);
                        Console.WriteLine(getQuest);
                        Console.WriteLine(getQuest2);
                        Console.WriteLine(getQuest3);
                    }
                    onRandom = true;
                }
            } else paper = false;

            for (int i = Game1.enemyList.Count - 1; i >= 0; i--)
            {
                player.Attack(Game1.enemyList[i]);
            }
            for (int i = Game1.enemyList.Count - 1; i >= 0; i--)
            {
                Game1.enemyList[i].Follow(player);
            }
            for (int i = 0; i < Game1.BagList.Count; i++)
            {
                Game1.BagList[i].Update(theTime);
            }

            for (int i = 0; i <  Game1.foodList.Count && i < 33 ; i++)
            {
                Game1.foodList[i].Update(theTime,player,this);
            }
            for (int i = Game1.enemyList.Count - 1; i >= 0; i--)
            {
                Game1.enemyList[i].Update(theTime);
            }

            foreach (IEntity entity in _entities)
            {
                entity.Update(theTime);
            }
            _collisionComponent.Update(theTime);
            _tiledMapRenderer.Update(theTime);

            Game1._camera.LookAt(game._bgPosition + game._cameraPosition);//******//
            player.Update(theTime);
            msPre = ms;
            base.Update(theTime);

            
            for (int i = 0; i < RestauarntScreen.QuestList.Count; i++)
            {
                RestauarntScreen.QuestList[i].Menuname = spawn[i];
            }
            if (RestauarntScreen.QuestList[3].Menuname == true && isSpawn[3] == false)
            {
                int countEnemy = 1;
                for (int i = 0; i < countEnemy; i++)
                {
                    Game1.enemyList.Add(new Enemy("temura", tempuraenemy, new Food[1] { new Food("tempura", tempura, new Rectangle(0, 0, 32, 32), false) }, 5, new RectangleF(400, 300, 64, 64)));
                }
                isSpawn[3] = true;
            }
           
            if (RestauarntScreen.QuestList[9].Menuname == true && isSpawn[9] == false)
            {
                int countEnemy = 1;
                for (int i = 0; i < countEnemy; i++)
                {
                    Game1.enemyList.Add(new Enemy("pig", pig, new Food[1] { new Food("CrispyPork", CrispyPork, new Rectangle(0, 0, 32, 32), false) }, 5, new RectangleF(400, 300, 64, 64)));
                }
                isSpawn[9] = true;
            }
            if (RestauarntScreen.QuestList[10].Menuname == true && isSpawn[10] == false)
            {
                int countEnemy = 1;
                for (int i = 0; i < countEnemy; i++)
                {
                    Game1.enemyList.Add(new Enemy("chicken", chicken, new Food[1] { new Food("chicken", chickenmeat, new Rectangle(0, 0, 32, 32), false) }, 5, new RectangleF(400, 300, 64, 64)));
                }
                isSpawn[10] = true;
            }
            if (RestauarntScreen.QuestList[15].Menuname == true && isSpawn[15] == false)
            {
                int countEnemy = 1;
                for (int i = 0; i < countEnemy; i++)
                {
                    Game1.enemyList.Add(new Enemy("rat", rat, new Food[1] { new Food("cheese", cheese, new Rectangle(0, 0, 32, 32), false) }, 5, new RectangleF(400, 300, 64, 64)));
                }
                isSpawn[15] = true;
            }
            if (RestauarntScreen.QuestList[8].Menuname == true && isSpawn[8] == false)
            {
                int countEnemy = 1;
                for (int i = 0; i < countEnemy; i++)
                {
                    Game1.enemyList.Add(new Enemy("rat", rat, new Food[1] { new Food("cheese", cheese, new Rectangle(0, 0, 32, 32), false) }, 5, new RectangleF(400, 300, 64, 64)));
                }
                isSpawn[8] = true;
            }
            if (RestauarntScreen.QuestList[17].Menuname == true && isSpawn[17] == false)
            {
                int countEnemy = 1;
                for (int i = 0; i < countEnemy; i++)
                {
                    Game1.enemyList.Add(new Enemy("cow", icebear, new Food[3] { new Food(true,"cowmeat", cowmeat, new Rectangle(0, 0, 32, 32)), new Food(true, "stone", stone, new Rectangle(0, 0, 32, 32)), new Food(true, "milk", milk, new Rectangle(0, 0, 32, 32)) }, 5, new RectangleF(400, 300, 64, 64)));
                }
                isSpawn[17] = true;
            }
            if (RestauarntScreen.QuestList[18].Menuname == true && isSpawn[18] == false)
            {
                int countEnemy = 1;
                for (int i = 0; i < countEnemy; i++)
                {
                    Game1.enemyList.Add(new Enemy("spider", spider, new Food[1] { new Food("meatball", meatball, new Rectangle(0, 0, 32, 32), false) }, 5, new RectangleF(400, 300, 32,32)));
                }
                isSpawn[18] = true;
            }
            if (RestauarntScreen.QuestList[22].Menuname == true && isSpawn[22] == false)
            {
                int countEnemy = 1;
                for (int i = 0; i < countEnemy; i++)
                {
                    Game1.enemyList.Add(new Enemy("spider", spider, new Food[1] { new Food("meatball", meatball, new Rectangle(0, 0, 32, 32), false) }, 5, new RectangleF(400, 300, 32,32)));
                    Game1.enemyList.Add(new Enemy("slime", slime, new Food[1] { new Food("rainbowsmilemeat", rainbowsmilemeat, new Rectangle(0, 0, 32, 32), false) }, 5, new RectangleF(500,400, 32,32)));
                }
                isSpawn[22] = true;
            }
            if (RestauarntScreen.QuestList[24].Menuname == true && isSpawn[24] == false)
            {
                int countEnemy = 1;
                for (int i = 0; i < countEnemy; i++)
                {
                    Game1.enemyList.Add(new Enemy("slime", slime, new Food[1] { new Food("rainbowsmilemeat", rainbowsmilemeat, new Rectangle(0, 0, 32, 32), false) }, 5, new RectangleF(500, 400, 32, 32)));
                }
                isSpawn[24] = true;
            }


        }
        Rectangle popupRec;
        bool openway;

        public void Oncraft(bool menu,int show)
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


            _spriteBatch.Draw(newstlye, new Rectangle(134, 645, 42 * 2, 42 * 2), Color.White);
            _spriteBatch.Draw(newstlye, new Rectangle(262, 645, 42 * 2, 42 * 2), Color.White);
            _spriteBatch.Draw(newstlye, new Rectangle(390, 645, 42 * 2, 42 * 2), Color.White);
            _spriteBatch.Draw(newstlye, new Rectangle(518, 645, 42 * 2, 42 * 2), Color.White);

            _spriteBatch.Draw(newstlye, new Rectangle(134, 742, 42 * 2, 42 * 2), Color.White);
            _spriteBatch.Draw(newstlye, new Rectangle(262, 742, 42 * 2, 42 * 2), Color.White);
            _spriteBatch.Draw(newstlye, new Rectangle(390, 742, 42 * 2, 42 * 2), Color.White);
            _spriteBatch.Draw(newstlye, new Rectangle(518, 742, 42 * 2, 42 * 2), Color.White);

            ///Tree 
            //Gem_Tree Nuddle_Tree PinkIce_Tree Tomato_Tree
            _spriteBatch.Draw(Gem_Tree, new Rectangle(498, 592, 42 * 2, 42 * 2), Color.White);
            _spriteBatch.Draw(Gem_Tree, new Rectangle(498, 626, 42 * 2, 42 * 2), Color.White);
            _spriteBatch.Draw(Gem_Tree, new Rectangle(540, 592, 42 * 2, 42 * 2), Color.White);
            _spriteBatch.Draw(Gem_Tree, new Rectangle(540, 626, 42 * 2, 42 * 2), Color.White);

            _spriteBatch.Draw(Tomato_Tree, new Rectangle(376, 592, 42 * 2, 42 * 2), Color.White);
            _spriteBatch.Draw(Tomato_Tree, new Rectangle(376, 626, 42 * 2, 42 * 2), Color.White);
            _spriteBatch.Draw(Tomato_Tree, new Rectangle(418, 592, 42 * 2, 42 * 2), Color.White);
            _spriteBatch.Draw(Tomato_Tree, new Rectangle(418, 626, 42 * 2, 42 * 2), Color.White);

            _spriteBatch.Draw(Nuddle_Tree, new Rectangle(254, 594, 42 * 2, 42 * 2), Color.White);
            _spriteBatch.Draw(Nuddle_Tree, new Rectangle(254, 628, 42 * 2, 42 * 2), Color.White);
            _spriteBatch.Draw(Nuddle_Tree, new Rectangle(295, 594, 42 * 2, 42 * 2), Color.White);
            _spriteBatch.Draw(Nuddle_Tree, new Rectangle(295, 628, 42 * 2, 42 * 2), Color.White);
            if(openway == true)
            {
                _spriteBatch.Draw(Door, new Rectangle(1320, 52, 128, 128), Color.White);
            }
            
            //_spriteBatch.Draw(PinkIce_Tree, new Rectangle(518, 742, 42 * 2, 42 * 2), Color.White);


            _spriteBatch.Draw(Board, new Rectangle(900, 400, 96, 64), Color.White);
            if (questInteract)
            {
                _spriteBatch.Draw(BoardInteract, new Rectangle(900, 400, 96, 64), Color.White);
            }

            //_spriteBatch.Draw(popup,popupRec, Color.White);
            foreach (Food food in Game1.foodList)
            {
                for (int i = 0; i < Game1.foodList.Count && i < 33; i++)
                {
                    Game1.foodList[i].Draw(_spriteBatch);
                }
            }
            foreach (Enemy enemy in Game1.enemyList)
            {
                for (int i = 0; i < Game1.enemyList.Count; i++)
                {
                    Game1.enemyList[i].Draw(_spriteBatch);
                }
            }
            player.Draw(_spriteBatch);
            //_spriteBatch.Draw(crabmeat,new Rectangle(700,400,32,32), Color.White);




        }


    }
}