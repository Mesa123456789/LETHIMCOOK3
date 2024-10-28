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
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Diagnostics;
using System.IO;



namespace LETHIMCOOK3.Screen
{
    public class RestauarntScreen : screen
    {
        ///***new <summary>
        Texture2D BBQfood, oct, DragonFish, GreenShrimp, Dumpling, GrilledChicken, Icecream_food, Mukrata, meatball_food, Pizza, Sasimi, Stone, Tempura, ThaiCrab, Bingsu, PumkimCheses, CrunchPork, Salad, Jellyfish_Salad, GlamStew, SweetSteak, DungNgo, Pudding, UltimateSasimi, MoodengNoodle, TangHuLu;
        bool getBBQfood = false, getDragonFish = false, getGreenShrimp = false, getDumpling = false, getGrilledChicken = false, getIcecream_food = false, getMukrata = false
            , getmeatball_food = false, getPizza = false, getSasimi = false, getStone = false, getTempura = false, getThaiCrab = false, getBingsu = false, getPumkimCheses = false, getCrunchPork = false, getSalad = false, getJellyfish_Salad = false, getGlamStew, getSweetSteak = false, getDungNgo = false, getPudding = false, getUltimateSasimi = false, getMoodengNoodle = false, getTangHuLu = false, getgetThaiCrab;
        Texture2D coriander, grass, greendimon, hippowing, jeelyfishmeat, lemon, meatball;
        Texture2D Mendrek, noodle, pinkdimon, seafood, shumai, smileeggs;
        Texture2D stone, suki, tempura, purpledimon;
        Texture2D salmonmeat, redfishmeat, whalemeat, greenshimpmeat, pinkfishmeat, sharkmeat, shimpmeat, unimeat, octopus, shimai;
        Texture2D ayinomoto, chili, oil, milk, salt2, sauce2, rice, sugar, icecream;
        Texture2D foodTexture, crabmeat;
        Texture2D hippo, hippomeat;
        Texture2D chicken, chickenmeat;
        Texture2D rat, cheese;
        Texture2D slime, rainbowsmilemeat;
        Texture2D pinkslime, pinksmilemeat;
        Texture2D icebear, wipcream, newfood;
        public static bool IsCooking;
        Texture2D popup;
        Texture2D interact;
        Texture2D craft;
        Texture2D inventory;
        Texture2D FridgeUi;
        Texture2D QuestUI;
        Texture2D uni;
        AnimatedTexture SpriteTexture;
        public static Player player;
        TiledMap _tiledMap;
        TiledMapRenderer _tiledMapRenderer;
        TiledMapObjectLayer _platformTiledObj;
        private readonly List<IEntity> _entities = new List<IEntity>();
        public static List<OpenQuest> QuestList = new List<OpenQuest>();
        public readonly CollisionComponent _collisionComponent;
        Game1 game;
        Vector2 playerPos;
        RectangleF Bounds = new RectangleF(new Vector2(161, 350), new Vector2(40, 60));
        bool Uniricefood, PumkinChesesfood, bingsuFood, sasimifood, JellyFishSaladfood, SweetSteakfood;
        bool octfood = false, BBQfoodfood = false, DragonFishfood = false, GreenShrimpfood = false, Dumplingfood = false,
            GrilledChickenfood = false, Icecream_foodfood = false, Mukratafood = false,
                meatball_foodfood = false, Pizzafood = false, Sasimifood = false, Stonefood = false, Tempurafood = false, ThaiCrabfood = false, Bingsufood = false, PumkimChesesfood = false, CrunchPorkfood = false, Saladfood = false, Jellyfish_Saladfood = false, GlamStewfood = false, SweetSeakfood = false, DungNgofood = false, Puddingfood, UltimateSasimifood = false, MoodengNoodlefood = false, TangHuLufood = false;
        Texture2D Boardquest_1, Boardquest_2, Boardquest_3, Boardquest_4, Boardquest_5, Boardquest_6, Boardquest_7, Boardquest_8, Boardquest_9
           , Boardquest_10, Boardquest_11, Boardquest_12, Boardquest_13, Boardquest_14, Boardquest_15, Boardquest_16, Boardquest_17, Boardquest_18,
           Boardquest_19, Boardquest_20, Boardquest_21, Boardquest_22, Boardquest_23, Boardquest_24, Boardquest_25, Boardquest_26, Boardquest_27;
        Texture2D BoardquestB_1, BoardquestB_2, BoardquestB_3, BoardquestB_4, BoardquestB_5, BoardquestB_6, BoardquestB_7, BoardquestB_8, BoardquestB_9
            , BoardquestB_10, BoardquestB_11, BoardquestB_12, BoardquestB_13, BoardquestB_14, BoardquestB_15, BoardquestB_16, BoardquestB_17, BoardquestB_18,
            BoardquestB_19, BoardquestB_20, BoardquestB_21, BoardquestB_22, BoardquestB_23, BoardquestB_24, BoardquestB_25, BoardquestB_26, BoardquestB_27;
        Texture2D Quest_1, Quest_2, Quest_3, Quest_4, Quest_5, Quest_6, Quest_7, Quest_8, Quest_9, Quest_10, Quest_11, Quest_12, Quest_13, Quest_14, Quest_15, Quest_16, Quest_17,
            Quest_18, Quest_19, Quest_20, Quest_21, Quest_22, Quest_23, Quest_24, Quest_25, Quest_26, Quest_27;

        bool isDing;

        public  List<Vector2> _craftRec = new List<Vector2>();
        
        public RestauarntScreen(Game1 game, EventHandler theScreenEvent) : base(theScreenEvent)
        {
            //Game1.sendingMenu = true;

            

            IsCooking = true;
            game._bgPosition = new Vector2(400, 225);//******/
            SpriteTexture = new AnimatedTexture(new Vector2(16, 16), 0, 2f, 1f);
            SpriteTexture.Load(game.Content, "Player-Sheet", 5, 4, 10);
            player = new Player(SpriteTexture, new Vector2(1500, 400), game, Bounds);
            popup = game.Content.Load<Texture2D>("popup");
            interact = game.Content.Load<Texture2D>("interact");
            craft = game.Content.Load<Texture2D>("craft");
            inventory = game.Content.Load<Texture2D>("inventory");
            FridgeUi = game.Content.Load<Texture2D>("FridgeUI");
            QuestUI = game.Content.Load<Texture2D>("QuestUI");
            newfood = game.Content.Load<Texture2D>("newfood");
            player.Load(game.Content, "Sword");
            player.Load(game.Content, "Effect");
            ////****food
            uni = game.Content.Load<Texture2D>("Uni");
            oct = game.Content.Load<Texture2D>("food/oct");
            BBQfood = game.Content.Load<Texture2D>("food/BBQ");
            DragonFish = game.Content.Load<Texture2D>("food/DragonFish");
            GreenShrimp = game.Content.Load<Texture2D>("food/GreenShrimp");
            Dumpling = game.Content.Load<Texture2D>("food/Dumpling_PNG");
            GrilledChicken = game.Content.Load<Texture2D>("food/GrilledChicken");
            Icecream_food = game.Content.Load<Texture2D>("food/ice-cream");
            Mukrata = game.Content.Load<Texture2D>("food/Mukrata");
            meatball_food = game.Content.Load<Texture2D>("food/meatball");
            Pizza = game.Content.Load<Texture2D>("food/Pizza");
            Sasimi = game.Content.Load<Texture2D>("food/Sasimi");
            Stone = game.Content.Load<Texture2D>("food/Stone");
            Tempura = game.Content.Load<Texture2D>("food/Tempura_PNG");
            ThaiCrab = game.Content.Load<Texture2D>("food/ThaiCrab");
            Bingsu = game.Content.Load<Texture2D>("food/Bingsu");
            PumkimCheses = game.Content.Load<Texture2D>("food/PumkinCheses");
            CrunchPork = game.Content.Load<Texture2D>("food/CrunchPork");
            Salad = game.Content.Load<Texture2D>("food/Salad");
            Jellyfish_Salad = game.Content.Load<Texture2D>("food/Jellyfish Salad");
            GlamStew = game.Content.Load<Texture2D>("food/GlamStew");
            SweetSteak = game.Content.Load<Texture2D>("food/SweetSteak");
            DungNgo = game.Content.Load<Texture2D>("food/DungNgo");
            Pudding = game.Content.Load<Texture2D>("food/Pudding");
            UltimateSasimi = game.Content.Load<Texture2D>("food/UltimateSasimi");
            MoodengNoodle = game.Content.Load<Texture2D>("food/MoodengNoodle");
            TangHuLu = game.Content.Load<Texture2D>("food/TangHuLu");
            //TangHuLu = game.Content.Load<Texture2D>("food/TangHuLu");
            BoardquestB_1 = game.Content.Load<Texture2D>("AllQuestB/BoardquestB_1");
            BoardquestB_2 = game.Content.Load<Texture2D>("AllQuestB/BoardquestB_2");
            BoardquestB_3 = game.Content.Load<Texture2D>("AllQuestB/BoardquestB_3");
            BoardquestB_4 = game.Content.Load<Texture2D>("AllQuestB/BoardquestB_4");
            BoardquestB_5 = game.Content.Load<Texture2D>("AllQuestB/BoardquestB_5");
            BoardquestB_6 = game.Content.Load<Texture2D>("AllQuestB/BoardquestB_6");
            BoardquestB_7 = game.Content.Load<Texture2D>("AllQuestB/BoardquestB_7");
            BoardquestB_8 = game.Content.Load<Texture2D>("AllQuestB/BoardquestB_8");
            BoardquestB_9 = game.Content.Load<Texture2D>("AllQuestB/BoardquestB_9");
            BoardquestB_10 = game.Content.Load<Texture2D>("AllQuestB/BoardquestB_10");
            BoardquestB_11 = game.Content.Load<Texture2D>("AllQuestB/BoardquestB_11");
            BoardquestB_12 = game.Content.Load<Texture2D>("AllQuestB/BoardquestB_12");
            BoardquestB_13 = game.Content.Load<Texture2D>("AllQuestB/BoardquestB_13");
            BoardquestB_14 = game.Content.Load<Texture2D>("AllQuestB/BoardquestB_14");
            BoardquestB_15 = game.Content.Load<Texture2D>("AllQuestB/BoardquestB_15");
            BoardquestB_16 = game.Content.Load<Texture2D>("AllQuestB/BoardquestB_16");
            BoardquestB_17 = game.Content.Load<Texture2D>("AllQuestB/BoardquestB_17");
            BoardquestB_18 = game.Content.Load<Texture2D>("AllQuestB/BoardquestB_18");
            BoardquestB_19 = game.Content.Load<Texture2D>("AllQuestB/BoardquestB_19");
            BoardquestB_20 = game.Content.Load<Texture2D>("AllQuestB/BoardquestB_20");
            BoardquestB_21 = game.Content.Load<Texture2D>("AllQuestB/BoardquestB_21");
            BoardquestB_22 = game.Content.Load<Texture2D>("AllQuestB/BoardquestB_22");
            BoardquestB_23 = game.Content.Load<Texture2D>("AllQuestB/BoardquestB_23");
            BoardquestB_24 = game.Content.Load<Texture2D>("AllQuestB/BoardquestB_24");
            BoardquestB_25 = game.Content.Load<Texture2D>("AllQuestB/BoardquestB_25");
            BoardquestB_26 = game.Content.Load<Texture2D>("AllQuestB/BoardquestB_26");
            BoardquestB_27 = game.Content.Load<Texture2D>("AllQuestB/BoardquestB_27");
            Boardquest_1 = game.Content.Load<Texture2D>("AllQuest/Boardquest_1");
            Boardquest_2 = game.Content.Load<Texture2D>("AllQuest/Boardquest_2");
            Boardquest_3 = game.Content.Load<Texture2D>("AllQuest/Boardquest_3");
            Boardquest_4 = game.Content.Load<Texture2D>("AllQuest/Boardquest_4");
            Boardquest_5 = game.Content.Load<Texture2D>("AllQuest/Boardquest_5");
            Boardquest_6 = game.Content.Load<Texture2D>("AllQuest/Boardquest_6");
            Boardquest_7 = game.Content.Load<Texture2D>("AllQuest/Boardquest_7");
            Boardquest_8 = game.Content.Load<Texture2D>("AllQuest/Boardquest_8");
            Boardquest_9 = game.Content.Load<Texture2D>("AllQuest/Boardquest_9");
            Boardquest_10 = game.Content.Load<Texture2D>("AllQuest/Boardquest_10");
            Boardquest_11 = game.Content.Load<Texture2D>("AllQuest/Boardquest_11");
            Boardquest_12 = game.Content.Load<Texture2D>("AllQuest/Boardquest_12");
            Boardquest_13 = game.Content.Load<Texture2D>("AllQuest/Boardquest_13");
            Boardquest_14 = game.Content.Load<Texture2D>("AllQuest/Boardquest_14");
            Boardquest_15 = game.Content.Load<Texture2D>("AllQuest/Boardquest_15");
            Boardquest_16 = game.Content.Load<Texture2D>("AllQuest/Boardquest_16");
            Boardquest_17 = game.Content.Load<Texture2D>("AllQuest/Quest_17");
            Boardquest_18 = game.Content.Load<Texture2D>("AllQuest/Boardquest_18");
            Boardquest_19 = game.Content.Load<Texture2D>("AllQuest/Boardquest_19");
            Boardquest_20 = game.Content.Load<Texture2D>("AllQuest/Boardquest_20");
            Boardquest_21 = game.Content.Load<Texture2D>("AllQuest/Boardquest_21");
            Boardquest_22 = game.Content.Load<Texture2D>("AllQuest/Boardquest_22");
            Boardquest_23 = game.Content.Load<Texture2D>("AllQuest/Boardquest_23");
            Boardquest_24 = game.Content.Load<Texture2D>("AllQuest/Boardquest_24");
            Boardquest_25 = game.Content.Load<Texture2D>("AllQuest/Boardquest_25");
            Boardquest_26 = game.Content.Load<Texture2D>("AllQuest/Boardquest_26");
            Boardquest_27 = game.Content.Load<Texture2D>("AllQuest/Boardquest_27");
            Quest_1 = game.Content.Load<Texture2D>("Menu_Quest/Quest_1");
                Quest_2 = game.Content.Load<Texture2D>("Menu_Quest/Quest_2");
            Quest_3 = game.Content.Load<Texture2D>("Menu_Quest/Quest_3");
            Quest_4 = game.Content.Load<Texture2D>("Menu_Quest/Quest_4");
            Quest_5 = game.Content.Load<Texture2D>("Menu_Quest/Quest_5");
            Quest_6 = game.Content.Load<Texture2D>("Menu_Quest/Quest_6");
            Quest_7 = game.Content.Load<Texture2D>("Menu_Quest/Quest_7");
            Quest_8 = game.Content.Load<Texture2D>("Menu_Quest/Quest_8");
            Quest_9 = game.Content.Load<Texture2D>("Menu_Quest/Quest_9");
            Quest_10 = game.Content.Load<Texture2D>("Menu_Quest/Quest_10");
            Quest_11 = game.Content.Load<Texture2D>("Menu_Quest/Quest_11");
            Quest_12 = game.Content.Load<Texture2D>("Menu_Quest/Quest_12");
            Quest_13 = game.Content.Load<Texture2D>("Menu_Quest/Quest_13");
            Quest_14 = game.Content.Load<Texture2D>("Menu_Quest/Quest_14");
            Quest_15 = game.Content.Load<Texture2D>("Menu_Quest/Quest_15");
            Quest_16 = game.Content.Load<Texture2D>("Menu_Quest/Quest_16");
            Quest_17 = game.Content.Load<Texture2D>("Menu_Quest/Quest_17");
            Quest_18 = game.Content.Load<Texture2D>("Menu_Quest/Quest_18");
            Quest_19 = game.Content.Load<Texture2D>("Menu_Quest/Quest_19");
            Quest_20 = game.Content.Load<Texture2D>("Menu_Quest/Quest_20");
            Quest_21 = game.Content.Load<Texture2D>("Menu_Quest/Quest_21");
            Quest_22 = game.Content.Load<Texture2D>("Menu_Quest/Quest_22");
            Quest_23 = game.Content.Load<Texture2D>("Menu_Quest/Quest_23");
            Quest_24 = game.Content.Load<Texture2D>("Menu_Quest/Quest_24");
            Quest_25 = game.Content.Load<Texture2D>("Menu_Quest/Quest_25");
            Quest_26 = game.Content.Load<Texture2D>("Menu_Quest/Quest_26");
            Quest_27 = game.Content.Load<Texture2D>("Menu_Quest/Quest_27");
     

            QuestList.Add(new OpenQuest(octfood, Boardquest_1, BoardquestB_1,Quest_1, new Rectangle(0, 0, 145, 180), false));
            QuestList.Add(new OpenQuest(Icecream_foodfood, Boardquest_2, Quest_2, BoardquestB_2, new Rectangle(0, 0, 145, 180), false));
            QuestList.Add(new OpenQuest(Uniricefood, Boardquest_3, BoardquestB_3, Quest_3, new Rectangle(0, 0, 145, 180), false));
            QuestList.Add(new OpenQuest(Tempurafood, Boardquest_4, BoardquestB_4, Quest_4, new Rectangle(0, 0, 145, 180), false));
            QuestList.Add(new OpenQuest(GreenShrimpfood, Boardquest_5, BoardquestB_5, Quest_5, new Rectangle(0, 0, 145, 180), false));
            QuestList.Add(new OpenQuest(ThaiCrabfood, Boardquest_6, BoardquestB_6, Quest_6, new Rectangle(0, 0, 145, 180), false));
            QuestList.Add(new OpenQuest(Dumplingfood, Boardquest_7, BoardquestB_7, Quest_7, new Rectangle(0, 0, 145, 180), false));
            QuestList.Add(new OpenQuest(BBQfoodfood, Boardquest_8, BoardquestB_8, Quest_8, new Rectangle(0, 0, 145, 180), false));
            QuestList.Add(new OpenQuest(PumkinChesesfood, Boardquest_9, BoardquestB_9, Quest_9, new Rectangle(0, 0, 145, 180), false));
            QuestList.Add(new OpenQuest(CrunchPorkfood, Boardquest_10, BoardquestB_10, Quest_10, new Rectangle(0, 0, 145, 180), false));
            //**11
            QuestList.Add(new OpenQuest(GrilledChickenfood, Boardquest_11, BoardquestB_11, Quest_11, new Rectangle(0, 0, 145, 180), false));
            QuestList.Add(new OpenQuest(bingsuFood, Boardquest_12, BoardquestB_12, Quest_12, new Rectangle(0, 0, 145, 180), false));
            QuestList.Add(new OpenQuest(TangHuLufood, Boardquest_13, BoardquestB_13, Quest_13, new Rectangle(0, 0, 145, 180), false));
            QuestList.Add(new OpenQuest(DragonFishfood, Boardquest_14, BoardquestB_14, Quest_14, new Rectangle(0, 0, 145, 180), false));
            QuestList.Add(new OpenQuest(sasimifood, Boardquest_15, BoardquestB_15, Quest_15, new Rectangle(0, 0, 145, 180), false));
            QuestList.Add(new OpenQuest(Pizzafood, Boardquest_16, BoardquestB_16, Quest_16, new Rectangle(0, 0, 145, 180), false));
            QuestList.Add(new OpenQuest(Saladfood, Boardquest_17, BoardquestB_17, Quest_17, new Rectangle(0, 0, 145, 180), false));
            QuestList.Add(new OpenQuest(Stonefood, Boardquest_18, BoardquestB_18, Quest_18, new Rectangle(0, 0, 145, 180), false));
            QuestList.Add(new OpenQuest(meatball_foodfood, Boardquest_19, BoardquestB_19, Quest_19, new Rectangle(0, 0, 145, 180), false));
            QuestList.Add(new OpenQuest(JellyFishSaladfood, Boardquest_20, BoardquestB_20, Quest_20, new Rectangle(0, 0, 145, 180), false));
            ///**21
            QuestList.Add(new OpenQuest(SweetSteakfood, Boardquest_21, BoardquestB_21, Quest_21, new Rectangle(0, 0, 145, 180), false));
            QuestList.Add(new OpenQuest(bingsuFood, Boardquest_22, BoardquestB_22, Quest_22, new Rectangle(0, 0, 145, 180), false));
            QuestList.Add(new OpenQuest(TangHuLufood, Boardquest_23, BoardquestB_23, Quest_23, new Rectangle(0, 0, 145, 180), false));
            QuestList.Add(new OpenQuest(Mukratafood, Boardquest_24, BoardquestB_24, Quest_24, new Rectangle(0, 0, 145, 180), false));
            QuestList.Add(new OpenQuest(sasimifood, Boardquest_25, BoardquestB_25, Quest_25, new Rectangle(0, 0, 145, 180), false));
            QuestList.Add(new OpenQuest(GlamStewfood, Boardquest_26, BoardquestB_26, Quest_26, new Rectangle(0, 0, 145, 180), false));
            QuestList.Add(new OpenQuest(MoodengNoodlefood, Boardquest_27, BoardquestB_27, Quest_27, new Rectangle(0, 0, 145, 180), false));

            _craftRec.Add(new Vector2(287, 95));
            _craftRec.Add(new Vector2(287 + 69, 95));
            _craftRec.Add(new Vector2(287 + 69 + 69, 95));
            _craftRec.Add(new Vector2(287 + 69 + 69 +69, 95));



            
            ///*****
            Game1.ingredentList.Add(new Food(0, "ayinomoto", false));
            Game1.ingredentList.Add(new Food(1, "chili", false));
            Game1.ingredentList.Add(new Food(2, "oil", false));
            Game1.ingredentList.Add(new Food(3, "milk", false));
            Game1.ingredentList.Add(new Food(4, "salt2", false));
            Game1.ingredentList.Add(new Food(5, "sauce2", false));
            Game1.ingredentList.Add(new Food(6, "rice", false));
            Game1.ingredentList.Add(new Food(7, "sugar", false));
            //***
            Game1.ingredentList.Add(new Food(8, "Thaicrab", false));
            Game1.ingredentList.Add(new Food(9, "pinksmaile", false));
            Game1.ingredentList.Add(new Food(10, "hippomeat", false));
            Game1.ingredentList.Add(new Food(11, "chicken", false));
            Game1.ingredentList.Add(new Food(12, "cheese", false));
            Game1.ingredentList.Add(new Food(13, "slime", false));
            Game1.ingredentList.Add(new Food(14, "wipcream", false));
            //***
            Game1.ingredentList.Add(new Food(15, "redfish", false));
            Game1.ingredentList.Add(new Food(16, "salmon", false));
            Game1.ingredentList.Add(new Food(17, "whaleear", false));
            Game1.ingredentList.Add(new Food(18, "greenshimpmeat", false));
            Game1.ingredentList.Add(new Food(19, "pinkfishmeat", false));
            Game1.ingredentList.Add(new Food(20, "sharkmeat", false));
            Game1.ingredentList.Add(new Food(21, "shimpmeat", false));
            Game1.ingredentList.Add(new Food(22, "unimeat", false));
            ///***new
            Game1.ingredentList.Add(new Food(23, "jeelyfishmeat", false));
            Game1.ingredentList.Add(new Food(24, "coriander", false));
            Game1.ingredentList.Add(new Food(25, "grass", false));
            Game1.ingredentList.Add(new Food(26, "greendimon", false));
            Game1.ingredentList.Add(new Food(27, "lemon", false));
            Game1.ingredentList.Add(new Food(28, "Mendrek", false));
            Game1.ingredentList.Add(new Food(29, "noodle", false));
            Game1.ingredentList.Add(new Food(30, "pinkdimon", false));
            Game1.ingredentList.Add(new Food(31, "shumai", false));
            Game1.ingredentList.Add(new Food(32, "stone", false));
            Game1.ingredentList.Add(new Food(33, "tempura", false));
            Game1.ingredentList.Add(new Food(34, "suki", false));
            Game1.ingredentList.Add(new Food(35, "seafood", false));
            Game1.ingredentList.Add(new Food(36, "icecream", false));
            Game1.ingredentList.Add(new Food(37, "shimai", false));
            Game1.ingredentList.Add(new Food(38, "octopus", false));
            Game1.ingredentList.Add(new Food(39, "pork", false));//39
            Game1.ingredentList.Add(new Food(40, "purpledimon", false));//39
            Game1.ingredentList.Add(new Food(41, "CrispyPork", false));//39
            Game1.ingredentList.Add(new Food(42, "cowmeat", false));//39
            Game1.ingredentList.Add(new Food(43, "sheepmeat", false));//39
            Game1.ingredentList.Add(new Food(44, "Pumkin", false));//39
            Game1.ingredentList.Add(new Food(45, "sharkear", false));//39
            Game1.ingredentList.Add(new Food(46, "Cactus", false));//39
            Game1.ingredentList.Add(new Food(47, "tomato", false));//39
            Game1.ingredentList.Add(new Food(48, "salad", false));//39
            Game1.ingredentList.Add(new Food(49, "meatball", false));//39
            Game1.ingredentList.Add(new Food(50, "smileeggs", false));//39
            Game1.ingredentList.Add(new Food(51, "rainbowsmilemeat", false));//39
            Game1.ingredentList.Add(new Food(52, "Squid", false));//39
            Game1.ingredentList.Add(new Food(53, "hippowing", false));//39
            Game1.ingredentList.Add(new Food(54, "candysnail", false));//39


            _collisionComponent = new CollisionComponent(new RectangleF(0, 0, 800, 450));
            _tiledMap = game.Content.Load<TiledMap>("Tile_Inrestaurant");

            _tiledMapRenderer = new TiledMapRenderer(game.GraphicsDevice, _tiledMap);
            //Get object layers
            foreach (TiledMapObjectLayer layer in _tiledMap.ObjectLayers)
            {
                if (layer.Name == "Tile_Wall_Inretaurant")
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
        
        RectangleF mouseRec, craftBox, inventoryBox;
        public static RectangleF doorRec = new RectangleF(161, 397, 200, 20);
        bool IssendMenuInterect = false;
        bool IsInterect = false;
        bool finsihcraft = false;
        MouseState msPre, ms;
        static Random randomQuest = new Random();
        float rotationMenuBG;
        ///**bool food
        bool getPongneng = false;
        bool onRandom = true;
        bool onQuest = false;
        bool alreadyDraw = false;
        bool inSide;
        public override void Update(GameTime theTime)
        {
            if (player.Bounds.Intersects(doorRec) && !GameplayScreen.EnterDoor)
            {
                
                IsCooking = false;
                ScreenEvent.Invoke(game.GameplayScreen, new EventArgs());
                GameplayScreen.player.Bounds.Position = new Vector2(770, 420);
                game._cameraPosition = new Vector2(400, 200);
                GameplayScreen.EnterDoor = true;
                return;
            }
            else inSide = false;
            if (!player.Bounds.Intersects(doorRec))
            {
                GameplayScreen.EnterDoor = false;
            }
            game.UpdateUIRest(player, theTime);
            ms = Mouse.GetState();

            mouseRec = new RectangleF(ms.X, ms.Y, 20, 20);
            RectangleF FrigeRec = new RectangleF(348, 120, 40, 80);
            RectangleF tableBox = new RectangleF(450, 150, 130, 20);
            RectangleF sendMenu = new RectangleF(600, 240, 40, 30);
            craftBox = new RectangleF(335, 140, 140, 50);
            if (player.Bounds.Intersects(FrigeRec))
            {
                IsFrigeInterect = true;
            }
            else { IsFrigeInterect = false; }
            if (player.Bounds.Intersects(tableBox))
            {
                IsInterect = true;
            }
            else
            {
                IsInterect = false;
            }
            if (player.Bounds.Intersects(sendMenu))
            {
                IssendMenuInterect = true;
            }
            else
            {
                IssendMenuInterect = false;
            }
            for (int i = 0; i < Game1.seasoningList.Count; i++)
            {
                if (mouseRec.Intersects(Game1.seasoningList[i].foodRec) && ms.LeftButton == ButtonState.Released && msPre.LeftButton == ButtonState.Pressed)
                {
                    if (Game1.openFridgeUI == true)
                    {
                        Game1.BagList.Add(Game1.seasoningList[i]);
                        Game1.IsPopUp = true;
                        break;
                    }
                }
            }
            for (int i = Game1.CraftList.Count - 1; i >= 0; i--)
            {
                foreach (Food food in Game1.CraftList)
                {
                    Game1.CraftList[i].foodPosition = _craftRec[i];
                    break;
                }
                Rectangle tocraft = new Rectangle((int)Game1.CraftList[i].foodPosition.X, (int)Game1.CraftList[i].foodPosition.Y, 32, 32);
                if (mouseRec.Intersects(tocraft) && ms.LeftButton == ButtonState.Released && msPre.LeftButton == ButtonState.Pressed && Game1.Ontable)
                {
                    Console.WriteLine("intersect Back!");
                        Game1.BagList.Add(Game1.CraftList[i]);
                        Game1.CraftList.RemoveAt(i);

                    for (int j = 0; j < Game1.CraftList.Count; j++)
                    {
                        Game1.CraftList[j].foodPosition = _craftRec[j];
                    }
                    break;
                }

                tocraft = new Rectangle((int)Game1.CraftList[i].foodPosition.X, (int)Game1.CraftList[i].foodPosition.Y, 32, 32);
            }

            for (int i = Game1.BagList.Count - 1; i >= 0; i--)
            {
                foreach (Food food in Game1.BagList)
                {
                    Game1.BagList[i].foodPosition = Game1.inventBox[i];
                    break;
                }
                inventoryBox = new Rectangle((int)Game1.BagList[i].foodPosition.X, (int)Game1.BagList[i].foodPosition.Y, 32, 32);
                if (mouseRec.Intersects(inventoryBox) && ms.LeftButton == ButtonState.Released && msPre.LeftButton == ButtonState.Pressed && Game1.Ontable)
                {
                    Console.WriteLine("intersect!");
                    if (Game1.CraftList.Count < 4)
                    {
                        Game1.CraftList.Add(Game1.BagList[i]);
                        Game1.BagList.RemoveAt(i);
                    }

                    for (int j = 0; j < Game1.BagList.Count; j++)
                    {
                        Game1.BagList[j].foodPosition = Game1.inventBox[j];
                    }
                    break;
                }

                inventoryBox = new Rectangle((int)Game1.BagList[i].foodPosition.X, (int)Game1.BagList[i].foodPosition.Y, 32, 32);
            }


            if (ms.LeftButton == ButtonState.Pressed && mouseRec.Intersects(craftBox))
            {
               
                for (int i = 0; i < Game1.ingredentList.Count; i++)
                {
                    Game1.ingredentList[i].istrue = false;
                    for (int j = 0; j < Game1.CraftList.Count; j++)
                    {
                        if (Game1.ingredentList[i].name == Game1.CraftList[j].name)
                        {
                            Game1.ingredentList[i].istrue = true;
                            Console.WriteLine("carft");
                        }
                        if (Game1.CraftList.Count < 3)
                        {
                            if (QuestList[0].Menuname && Game1.ingredentList[7].istrue == true && Game1.ingredentList[25].istrue == true)
                            {
                                Game1.MenuList.Add(new Food(oct, new Vector2(100, 100)));
                                Console.WriteLine("pongneng true");
                                getPongneng = true;
                                RemoveCraft(2);
                                Game1.GotMenu = true;
                                finsihcraft = true;
                                Game1.havQ = false;
                               
                            }
                            if (QuestList[1].Menuname && Game1.ingredentList[36].istrue == true && Game1.ingredentList[14].istrue == true)
                            {
                                Game1.MenuList.Add(new Food(Icecream_food, new Vector2(100, 100)));
                                Console.WriteLine("icecream true");
                                getIcecream_food = true;
                                Game1.GotMenu = true;
                                finsihcraft = true;
                                Game1.havQ = false;
                                if (isDing == false)
                                {
                                    Game1.soundEffects[6].Play();
                                    isDing = true;
                                }
                                RemoveCraft(3);
                            }
                            if (QuestList[3].Menuname && Game1.ingredentList[5].istrue == true && Game1.ingredentList[33].istrue == true)
                            {
                                Game1.MenuList.Add(new Food(Tempura, new Vector2(100, 100)));
                                Console.WriteLine("getTempura true");
                                getTempura = true;
                                Game1.GotMenu = true;
                                finsihcraft = true;
                                Game1.havQ = false;
                                if (isDing == false)
                                {
                                    Game1.soundEffects[6].Play();
                                    isDing = true;
                                }
                                RemoveCraft(3);
                            }
                            if (QuestList[4].Menuname && Game1.ingredentList[18].istrue == true && Game1.ingredentList[0].istrue == true)
                            {
                                Game1.MenuList.Add(new Food(GreenShrimp, new Vector2(100, 100)));
                                Console.WriteLine("getGreenShrimp true");
                                getGreenShrimp = true;
                                Game1.GotMenu = true;
                                finsihcraft = true;
                                Game1.havQ = false;
                                if (isDing == false)
                                {
                                    Game1.soundEffects[6].Play();
                                    isDing = true;
                                }
                                RemoveCraft(3);
                            }
                            if (QuestList[6].Menuname && Game1.ingredentList[37].istrue == true && Game1.ingredentList[1].istrue == true)
                            {
                                Game1.MenuList.Add(new Food(Dumpling, new Vector2(100, 100)));
                                Console.WriteLine("getDumpling true");
                                getDumpling = true;
                                Game1.GotMenu = true;
                                finsihcraft = true;
                                Game1.havQ = false;
                                if (isDing == false)
                                {
                                    Game1.soundEffects[6].Play();
                                    isDing = true;
                                }
                                RemoveCraft(3);
                            }
                            if (QuestList[7].Menuname && Game1.ingredentList[5].istrue == true && Game1.ingredentList[43].istrue == true)
                            {
                                Game1.MenuList.Add(new Food(BBQfood, new Vector2(100, 100)));
                                Console.WriteLine("getBBQ true");
                                getBBQfood = true;
                                Game1.GotMenu = true;
                                finsihcraft = true;
                                Game1.havQ = false;
                                if (isDing == false)
                                {
                                    Game1.soundEffects[6].Play();
                                    isDing = true;
                                }
                                RemoveCraft(3);
                            }
                            if (QuestList[10].Menuname && Game1.ingredentList[5].istrue == true && Game1.ingredentList[11].istrue == true)
                            {
                                Game1.MenuList.Add(new Food(GrilledChicken, new Vector2(100, 100)));
                                Console.WriteLine("getGrilledChicken true");
                                getGrilledChicken = true;
                                Game1.GotMenu = true;
                                finsihcraft = true;
                                Game1.havQ = false;
                                if (isDing == false)
                                {
                                    Game1.soundEffects[6].Play();
                                }
                                RemoveCraft(3);
                            }
                            if (QuestList[11].Menuname && Game1.ingredentList[9].istrue == true && Game1.ingredentList[17].istrue == true)
                            {
                                Game1.MenuList.Add(new Food(Bingsu  , new Vector2(100, 100)));
                                Console.WriteLine("getBingsu true");
                                getBingsu = true;
                                Game1.GotMenu = true;
                                finsihcraft = true;
                                Game1.havQ = false;
                                if (isDing == false)
                                {
                                    Game1.soundEffects[6].Play();
                                    isDing = true;
                                }
                                RemoveCraft(3);
                            }
                            if (QuestList[12].Menuname && Game1.ingredentList[54].istrue == true && Game1.ingredentList[7].istrue == true)
                            {
                                Game1.MenuList.Add(new Food(TangHuLu, new Vector2(100, 100)));
                                Console.WriteLine("getTangHuLu true");
                                getTangHuLu = true;
                                Game1.GotMenu = true;
                                finsihcraft = true;
                                Game1.havQ = false;
                                if (isDing == false)
                                {
                                    Game1.soundEffects[6].Play();
                                    isDing = true;
                                }
                                RemoveCraft(3);
                            }
                        }
                        if (Game1.CraftList.Count < 4)
                        {
                            if (QuestList[2].Menuname && Game1.ingredentList[0].istrue == true && Game1.ingredentList[6].istrue == true && Game1.ingredentList[22].istrue == true)
                            {
                                Game1.MenuList.Add(new Food(uni, new Vector2(100, 200)));
                                Console.WriteLine("getfood");
                                getUni = true;
                                Game1.GotMenu = true;
                                finsihcraft = true;
                                Game1.havQ = false;
                                if (isDing == false)
                                {
                                    Game1.soundEffects[6].Play();
                                    isDing = true;
                                }
                                RemoveCraft(4);
                            }
                            if (QuestList[13].Menuname && Game1.ingredentList[15].istrue == true && Game1.ingredentList[5].istrue == true && Game1.ingredentList[1].istrue == true)
                            {
                                Game1.MenuList.Add(new Food(DragonFish, new Vector2(100, 100)));
                                Console.WriteLine("getfood");
                                getDragonFish = true;
                                Game1.GotMenu = true;
                                finsihcraft = true;
                                Game1.havQ = false;
                                if (isDing == false)
                                {
                                    Game1.soundEffects[6].Play();
                                    isDing = true;
                                }
                                RemoveCraft(4);
                            }
                            if (QuestList[5].Menuname && Game1.ingredentList[8].istrue == true && Game1.ingredentList[0].istrue == true && Game1.ingredentList[1].istrue == true)
                            {
                                Game1.MenuList.Add(new Food(ThaiCrab, new Vector2(100, 100)));
                                Console.WriteLine("getfood");
                                getThaiCrab = true;
                                Game1.GotMenu = true;
                                finsihcraft = true;
                                Game1.havQ = false;
                                if (isDing == false)
                                {
                                    Game1.soundEffects[6].Play();
                                    isDing = true;
                                }
                                RemoveCraft(4);
                            }
                            if (QuestList[8].Menuname && Game1.ingredentList[44].istrue == true && Game1.ingredentList[7].istrue == true && Game1.ingredentList[12].istrue == true)
                            {
                                Game1.MenuList.Add(new Food(PumkimCheses, new Vector2(100, 100)));
                                Console.WriteLine("getPumkimCheses True");
                                getPumkimCheses = true;
                                Game1.GotMenu = true;
                                finsihcraft = true;
                                Game1.havQ = false;
                                if (isDing == false)
                                {
                                    Game1.soundEffects[6].Play();
                                    isDing = true;
                                }
                                RemoveCraft(4);
                            }
                            if (QuestList[9].Menuname && Game1.ingredentList[41].istrue == true && Game1.ingredentList[0].istrue == true && Game1.ingredentList[35].istrue == true)
                            {
                                Game1.MenuList.Add(new Food(CrunchPork, new Vector2(100, 100)));
                                Console.WriteLine("getCrunchPork True");
                                getCrunchPork = true;
                                Game1.GotMenu = true;
                                finsihcraft = true;
                                Game1.havQ = false;
                                if (isDing == false)
                                {
                                    Game1.soundEffects[6].Play();
                                    isDing = true;
                                }
                                RemoveCraft(4);
                            }
                            if (QuestList[14].Menuname && Game1.ingredentList[20].istrue == true && Game1.ingredentList[45].istrue == true && Game1.ingredentList[27].istrue == true)
                            {
                                Game1.MenuList.Add(new Food(Sasimi, new Vector2(100, 100)));
                                Console.WriteLine("getSasimi True");
                                getSasimi = true;
                                Game1.GotMenu = true;
                                finsihcraft = true;
                                Game1.havQ = false;
                                if (isDing == false)
                                {
                                    Game1.soundEffects[6].Play();
                                    isDing = true;
                                }
                                RemoveCraft(4);
                            }
                            if (QuestList[22].Menuname && Game1.ingredentList[49].istrue == true && Game1.ingredentList[51].istrue == true && Game1.ingredentList[7].istrue == true)
                            {
                                Game1.MenuList.Add(new Food(DungNgo, new Vector2(100, 100)));
                                Console.WriteLine("getDungNgo True");
                                getDungNgo = true;
                                Game1.GotMenu = true;
                                finsihcraft = true;
                                Game1.havQ = false;
                                if (isDing == false)
                                {
                                    Game1.soundEffects[6].Play();
                                    isDing = true;
                                }
                                RemoveCraft(4);
                            }

                        }
                        if (Game1.CraftList.Count < 5)
                        {
                            if (QuestList[23].Menuname && Game1.ingredentList[39].istrue == true && Game1.ingredentList[52].istrue == true && Game1.ingredentList[23].istrue == true && Game1.ingredentList[34].istrue == true)
                            {
                                Game1.MenuList.Add(new Food(Mukrata, new Vector2(100, 100)));
                                Console.WriteLine("getfood");
                                getMukrata = true;
                                Game1.GotMenu = true;
                                finsihcraft = true;
                                Game1.havQ = false;
                                if (isDing == false)
                                {
                                    Game1.soundEffects[6].Play();
                                    isDing = true;
                                }
                                RemoveCraft(23);
                            }
                            if (QuestList[15].Menuname && Game1.ingredentList[40].istrue == true && Game1.ingredentList[26].istrue == true && Game1.ingredentList[30].istrue == true && Game1.ingredentList[12].istrue == true)
                            {
                                Game1.MenuList.Add(new Food(Pizza, new Vector2(100, 100)));
                                Console.WriteLine("getPizza");
                                getPizza = true;
                                Game1.GotMenu = true;
                                finsihcraft = true;
                                Game1.havQ = false;
                                if (isDing == false)
                                {
                                    Game1.soundEffects[6].Play();
                                    isDing = true;
                                }
                                RemoveCraft(5);
                                
                            }
                            if (QuestList[16].Menuname && Game1.ingredentList[44].istrue == true && Game1.ingredentList[47].istrue == true && Game1.ingredentList[48].istrue == true && Game1.ingredentList[2].istrue == true)
                            {
                                Game1.MenuList.Add(new Food(Salad, new Vector2(100, 100)));
                                Console.WriteLine("getSalad");
                                getSalad = true;
                                Game1.GotMenu = true;
                                finsihcraft = true;
                                Game1.havQ = false;
                                if (isDing == false)
                                {
                                    Game1.soundEffects[6].Play();
                                    isDing = true;
                                }
                                RemoveCraft(5);
                            }
                            if (QuestList[17].Menuname && Game1.ingredentList[32].istrue == true && Game1.ingredentList[43].istrue == true && Game1.ingredentList[1].istrue == true && Game1.ingredentList[0].istrue == true)
                            {
                                Console.WriteLine("getStone");
                                getStone = true;
                                Game1.GotMenu = true;
                                finsihcraft = true;
                                Game1.havQ = false;
                                if (isDing == false)
                                {
                                    Game1.soundEffects[6].Play();
                                    isDing = true;
                                }
                                RemoveCraft(5);
           
                            }
                            if (QuestList[18].Menuname && Game1.ingredentList[49].istrue == true && Game1.ingredentList[49].istrue == true && Game1.ingredentList[49].istrue == true && Game1.ingredentList[35].istrue == true)
                            {
                                Game1.MenuList.Add(new Food(meatball, new Vector2(100, 100)));
                                Console.WriteLine("getmeatball_food");
                                getmeatball_food = true;
                                Game1.GotMenu = true;
                                finsihcraft = true;
                                Game1.havQ = false;
                                if (isDing == false)
                                {
                                    Game1.soundEffects[6].Play();
                                    isDing = true;
                                }
                                RemoveCraft(5);
                  
                            }
                            if (QuestList[19].Menuname && Game1.ingredentList[23].istrue == true && Game1.ingredentList[23].istrue == true && Game1.ingredentList[2].istrue == true && Game1.ingredentList[1].istrue == true)
                            {
                                Game1.MenuList.Add(new Food(Jellyfish_Salad, new Vector2(100, 100)));
                                Console.WriteLine("Jellyfish_Salad");
                                getJellyfish_Salad = true;
                                Game1.GotMenu = true;
                                finsihcraft = true;
                                Game1.havQ = false;
                                if (isDing == false)
                                {
                                    Game1.soundEffects[6].Play();
                                    isDing = true;
                                }
                                RemoveCraft(5);
                          
                            }
                            if (QuestList[21].Menuname && Game1.ingredentList[19].istrue == true && Game1.ingredentList[50].istrue == true && Game1.ingredentList[5].istrue == true && Game1.ingredentList[24].istrue == true)
                            {
                                Game1.MenuList.Add(new Food(GlamStew, new Vector2(100, 100)));
                                Console.WriteLine("GlamStew");
                                getGlamStew = true;
                                Game1.GotMenu = true;
                                finsihcraft = true;
                                RemoveCraft(5);
                                if (isDing == false)
                                {
                                    Game1.soundEffects[6].Play();
                                    isDing = true;
                                }
              
                            }
                            if (QuestList[20].Menuname && Game1.ingredentList[43].istrue == true && Game1.ingredentList[28].istrue == true && Game1.ingredentList[47].istrue == true && Game1.ingredentList[4].istrue == true)
                            {
                                Game1.MenuList.Add(new Food(SweetSteak, new Vector2(100, 100)));
                                Console.WriteLine("SweetSteak");
                                getSweetSteak = true;
                                Game1.GotMenu = true;
                                finsihcraft = true;
                                Game1.havQ = false;
                                if (isDing == false)
                                {
                                    Game1.soundEffects[6].Play();
                                    isDing = true;
                                }
                                RemoveCraft(5);
    
                            }
                            if (QuestList[24].Menuname && Game1.ingredentList[51].istrue == true && Game1.ingredentList[3].istrue == true && Game1.ingredentList[50].istrue == true && Game1.ingredentList[7].istrue == true)
                            {
                                Game1.MenuList.Add(new Food(Pudding, new Vector2(100, 100)));
                                Console.WriteLine("Pudding");
                                getPudding = true;
                                Game1.GotMenu = true;
                                finsihcraft = true;
                                Game1.havQ = false;
                                if (isDing == false)
                                {
                                    Game1.soundEffects[6].Play();
                                    isDing = true;
                                }
                                RemoveCraft(5);
              
                            }
                            if (Game1.ingredentList[20].istrue == true && Game1.ingredentList[45].istrue == true && Game1.ingredentList[15].istrue == true && Game1.ingredentList[16].istrue == true)
                            {
                                Game1.MenuList.Add(new Food(UltimateSasimi, new Vector2(100, 100)));
                                Console.WriteLine("UltimateSasimi");
                                getUltimateSasimi = true;
                                Game1.GotMenu = true;
                                finsihcraft = true;
                                Game1.havQ = false;
                                if (isDing == false)
                                {
                                    Game1.soundEffects[6].Play();
                                    isDing = true;
                                }
                                RemoveCraft(5);
            
                            }
                            if (QuestList[26].Menuname && Game1.ingredentList[10].istrue == true && Game1.ingredentList[53].istrue == true && Game1.ingredentList[29].istrue == true && Game1.ingredentList[2].istrue == true)
                            {
                                Game1.MenuList.Add(new Food(MoodengNoodle, new Vector2(100, 100)));
                                Console.WriteLine("MoodengNoodle");
                                getMoodengNoodle = true;
                                Game1.GotMenu = true;
                                finsihcraft = true;
                                Game1.havQ = false;
                                if (isDing == false)
                                {
                                    Game1.soundEffects[6].Play();
                                    isDing = true;
                                }
                                RemoveCraft(5);
               
                            }

                        }
                    }

                }
            }
            else isDing = false;
 
            if (rotationMenuBG < 360)
            {
                rotationMenuBG += 0.10f;
            }
            if (rotationMenuBG == 360)
            {
                rotationMenuBG = 0;
            }
            if (Game1.sendingMenu == true)
            {
                for(int i = 0; i < QuestList.Count; i++)
                {
                    QuestList[i].Menuname = false;
                }
            }

            foreach (IEntity entity in _entities)
            {
                entity.Update(theTime);
            }
            _collisionComponent.Update(theTime);
            _tiledMapRenderer.Update(theTime);
            msPre = ms;
            player.Update(theTime);
            base.Update(theTime);
        }

        public int _count;

        bool getUni = false;
        int MenuPopup;
        bool IsFrigeInterect = false;
        bool sendingMenu = false;
        public override void Draw(SpriteBatch _spriteBatch)
        {

            _tiledMapRenderer.Draw();//******//
            _spriteBatch.End();
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);//******//

            //foreach (IEntity entity in _entities)
            //{
            //    entity.Draw(_spriteBatch);
            //}
            //_spriteBatch.Draw(popup, new Rectangle((int)doorRec.X, (int)doorRec.Y, (int)doorRec.Width, (int)doorRec.Height), Color.White);
            if (IsInterect == true)
            {
                _spriteBatch.Draw(interact, new Rectangle(443, 148, 140, 44), Color.White);
            }
            if (IsFrigeInterect == true)
            {
                _spriteBatch.Draw(interact, new Rectangle(346, 116, 40, 80), Color.White);
            }
            if (IssendMenuInterect == true)
            {
                _spriteBatch.Draw(interact, new Rectangle(600, 240, 45, 33), Color.White);
            }
          

            player.Draw(_spriteBatch);
            if (getUni == true && Game1.sendingMenu == false)
            {
                _spriteBatch.Draw(uni, new Rectangle((int)player.Bounds.Position.X, (int)player.Bounds.Position.Y + 20, 32, 32), Color.White);
                CountC();
                //sendingMenu = true;
            }
            if (getPongneng == true && Game1.sendingMenu == false)
            {
                _spriteBatch.Draw(oct, new Rectangle((int)player.Bounds.Position.X, (int)player.Bounds.Position.Y + 20, 32, 32), Color.White);
                CountC( );
                //sendingMenu = true;

            }
            if (getIcecream_food == true && Game1.sendingMenu == false)
            {
                _spriteBatch.Draw(Icecream_food, new Rectangle((int)player.Bounds.Position.X, (int)player.Bounds.Position.Y + 20, 32, 32), Color.White);
                CountC();
                //alreadyDraw = true;
            }
            if (getTempura == true && Game1.sendingMenu == false)
            {
                _spriteBatch.Draw(Tempura, new Rectangle((int)player.Bounds.Position.X, (int)player.Bounds.Position.Y + 20, 32, 32), Color.White);
                CountC();
                //alreadyDraw = true;
            }
            if (getDumpling == true && Game1.sendingMenu == false)
            {
                _spriteBatch.Draw(Dumpling, new Rectangle((int)player.Bounds.Position.X, (int)player.Bounds.Position.Y + 20, 32, 32), Color.White);
                CountC();
                //alreadyDraw = true;
            }
            if (getGreenShrimp == true && Game1.sendingMenu == false)
            {
                _spriteBatch.Draw(GreenShrimp, new Rectangle((int)player.Bounds.Position.X, (int)player.Bounds.Position.Y + 20, 32, 32), Color.White);
                CountC();
                //alreadyDraw = true;
            }
            if (getGrilledChicken == true && Game1.sendingMenu == false)
            {
                _spriteBatch.Draw(GrilledChicken, new Rectangle((int)player.Bounds.Position.X, (int)player.Bounds.Position.Y + 20, 32, 32), Color.White);
                CountC();
                // alreadyDraw = true;
            }
            if (getBBQfood == true && Game1.sendingMenu == false)
            {
                _spriteBatch.Draw(BBQfood, new Rectangle((int)player.Bounds.Position.X, (int)player.Bounds.Position.Y + 20, 32, 32), Color.White);
                CountC();
                // alreadyDraw = true;
            }
            if (getMukrata == true && Game1.sendingMenu == false)
            {
                _spriteBatch.Draw(Mukrata, new Rectangle((int)player.Bounds.Position.X, (int)player.Bounds.Position.Y + 20, 32, 32), Color.White);
                CountC();
                // alreadyDraw = true;
            }
            if (getPizza == true && Game1.sendingMenu == false)
            {
                _spriteBatch.Draw(Pizza, new Rectangle((int)player.Bounds.Position.X, (int)player.Bounds.Position.Y + 20, 32, 32), Color.White);
                CountC();
                // alreadyDraw = true;
            }
            if (getDragonFish == true && Game1.sendingMenu == false)
            {
                _spriteBatch.Draw(DragonFish, new Rectangle((int)player.Bounds.Position.X, (int)player.Bounds.Position.Y + 20, 32, 32), Color.White);
                CountC();
                // alreadyDraw = true;
            }
            if (getBingsu == true && Game1.sendingMenu == false)
            {
                _spriteBatch.Draw(Bingsu, new Rectangle((int)player.Bounds.Position.X, (int)player.Bounds.Position.Y + 20, 32, 32), Color.White);
                CountC();
                //  alreadyDraw = true;
            }
            if (getPumkimCheses == true && Game1.sendingMenu == false)
            {
                _spriteBatch.Draw(PumkimCheses, new Rectangle((int)player.Bounds.Position.X, (int)player.Bounds.Position.Y + 20, 32, 32), Color.White);
                CountC();
                //  alreadyDraw = true;
            }
            if (getCrunchPork == true && Game1.sendingMenu == false)
            {
                _spriteBatch.Draw(CrunchPork, new Rectangle((int)player.Bounds.Position.X, (int)player.Bounds.Position.Y + 20, 32, 32), Color.White);
                CountC();
                // alreadyDraw = true;
            }
            if (getSasimi == true && Game1.sendingMenu == false)
            {
                _spriteBatch.Draw(Sasimi, new Rectangle((int)player.Bounds.Position.X, (int)player.Bounds.Position.Y + 20, 32, 32), Color.White);
                CountC();
                // alreadyDraw = true;
            }
            if (getSalad == true && Game1.sendingMenu == false)
            {
                _spriteBatch.Draw(Salad, new Rectangle((int)player.Bounds.Position.X, (int)player.Bounds.Position.Y + 20, 32, 32), Color.White);
                CountC();
                //  alreadyDraw = true;
            }
            if (getStone == true && Game1.sendingMenu == false)
            {
                _spriteBatch.Draw(Stone, new Rectangle((int)player.Bounds.Position.X, (int)player.Bounds.Position.Y + 20, 32, 32), Color.White);
                CountC();
                //alreadyDraw = true;
            }
            if (getmeatball_food == true && Game1.sendingMenu == false)
            {
                _spriteBatch.Draw(meatball_food, new Rectangle((int)player.Bounds.Position.X, (int)player.Bounds.Position.Y + 20, 32, 32), Color.White);
                CountC();
                // alreadyDraw = true;
            }
            if (getJellyfish_Salad == true && Game1.sendingMenu == false)
            {
                _spriteBatch.Draw(Jellyfish_Salad, new Rectangle((int)player.Bounds.Position.X, (int)player.Bounds.Position.Y + 20, 32, 32), Color.White);
                CountC();
                // alreadyDraw = true;
            }
            if (getGlamStew == true && Game1.sendingMenu == false)
            {
                _spriteBatch.Draw(GlamStew, new Rectangle((int)player.Bounds.Position.X, (int)player.Bounds.Position.Y + 20, 32, 32), Color.White);
                CountC();

            }
            if (getSweetSteak == true && Game1.sendingMenu == false)
            {
                _spriteBatch.Draw(SweetSteak, new Rectangle((int)player.Bounds.Position.X, (int)player.Bounds.Position.Y + 20, 32, 32), Color.White);
                CountC();
                // alreadyDraw = true;
            }
            if (getDungNgo == true && Game1.sendingMenu == false)
            {
                _spriteBatch.Draw(DungNgo, new Rectangle((int)player.Bounds.Position.X, (int)player.Bounds.Position.Y + 20, 32, 32), Color.White);
                CountC();
            }
            if (getPudding == true && Game1.sendingMenu == false)
            {
                _spriteBatch.Draw(Pudding, new Rectangle((int)player.Bounds.Position.X, (int)player.Bounds.Position.Y + 20, 32, 32), Color.White);
                CountC();
                //alreadyDraw = true;
            }
            if (getUltimateSasimi == true && Game1.sendingMenu == false)
            {
                _spriteBatch.Draw(UltimateSasimi, new Rectangle((int)player.Bounds.Position.X, (int)player.Bounds.Position.Y + 20, 32, 32), Color.White);
                CountC();
            }

            if (getMoodengNoodle == true && Game1.sendingMenu == false)
            {
                _spriteBatch.Draw(MoodengNoodle, new Rectangle((int)player.Bounds.Position.X, (int)player.Bounds.Position.Y + 20, 32, 32), Color.White);
                CountC();
            }
            if (getTangHuLu == true && Game1.sendingMenu == false)
            {
                _spriteBatch.Draw(TangHuLu, new Rectangle((int)player.Bounds.Position.X, (int)player.Bounds.Position.Y + 20, 32, 32), Color.White);
                CountC();
            }
            if (getThaiCrab == true && Game1.sendingMenu == false)
            {
                _spriteBatch.Draw(ThaiCrab, new Rectangle((int)player.Bounds.Position.X, (int)player.Bounds.Position.Y + 20, 32, 32), Color.White);
                CountC();
            }

            game.DrawUIRest(_spriteBatch);
                if (Game1.Ontable == true)
                {
                    _spriteBatch.Draw(craft, new Vector2(215, 60), Color.White);
                    _spriteBatch.Draw(inventory, new Vector2(129, 220), Color.White);
                    // _spriteBatch.Draw(popup, craftBox, Color.White);
                    for (int i = 0; i < Game1.CraftList.Count; i++)
                    {
                        _spriteBatch.Draw(Game1.CraftList[i].foodTexBag, new Vector2(287 + i * 69, 95), new Rectangle(0, 0, 32, 32), Color.White);
                    }
                    for (int i = 0; i < Game1.BagList.Count; i++)
                    {
                        _spriteBatch.Draw(Game1.BagList[i].foodTexBag, Game1.inventBox[i], new Rectangle(0, 0, 32, 32), Color.White);
                    }
                    if (getUni == true && finsihcraft == true)
                    {
                        _spriteBatch.Draw(newfood, new Vector2(400, 200), new Rectangle(0, 0, 800, 450), Color.White, rotationMenuBG, new Vector2(372, 211), 1f, 0, 0);
                        _spriteBatch.Draw(uni, new Rectangle(343, 120, 128, 128), Color.White);
                    }
                    if (getPongneng == true && finsihcraft == true)
                    {
                        _spriteBatch.Draw(newfood, new Vector2(400, 200), new Rectangle(0, 0, 800, 450), Color.White, rotationMenuBG, new Vector2(372, 211), 1f, 0, 0);
                        _spriteBatch.Draw(oct, new Rectangle(343 - 5, 120, 128, 128), Color.White);
                    }
                    if (getIcecream_food == true && finsihcraft == true)
                    {
                        _spriteBatch.Draw(newfood, new Vector2(400, 200), new Rectangle(0, 0, 800, 450), Color.White, rotationMenuBG, new Vector2(372, 211), 1f, 0, 0);
                        _spriteBatch.Draw(Icecream_food, new Rectangle(343, 120, 128, 128), Color.White);
                    }
                    if (getTempura == true && finsihcraft == true)
                    {
                        _spriteBatch.Draw(newfood, new Vector2(400, 200), new Rectangle(0, 0, 800, 450), Color.White, rotationMenuBG, new Vector2(372, 211), 1f, 0, 0);
                        _spriteBatch.Draw(Tempura, new Rectangle(343, 120, 128, 128), Color.White);
                    }
                    if (getDumpling == true && finsihcraft == true)
                    {
                        _spriteBatch.Draw(newfood, new Vector2(400, 200), new Rectangle(0, 0, 800, 450), Color.White, rotationMenuBG, new Vector2(372, 211), 1f, 0, 0);
                        _spriteBatch.Draw(Dumpling, new Rectangle(343, 120, 128, 128), Color.White);
                    }
                    if (getGreenShrimp == true && finsihcraft == true)
                    {
                        _spriteBatch.Draw(newfood, new Vector2(400, 200), new Rectangle(0, 0, 800, 450), Color.White, rotationMenuBG, new Vector2(372, 211), 1f, 0, 0);
                        _spriteBatch.Draw(GreenShrimp, new Rectangle(343, 120, 128, 128), Color.White);
                    }
                    if (getGrilledChicken == true && finsihcraft == true)
                    {
                        _spriteBatch.Draw(newfood, new Vector2(400, 200), new Rectangle(0, 0, 800, 450), Color.White, rotationMenuBG, new Vector2(372, 211), 1f, 0, 0);
                        _spriteBatch.Draw(GrilledChicken, new Rectangle(343, 120, 128, 128), Color.White);
                    }
                    if (getBBQfood == true && finsihcraft == true)
                    {
                        _spriteBatch.Draw(newfood, new Vector2(400, 200), new Rectangle(0, 0, 800, 450), Color.White, rotationMenuBG, new Vector2(372, 211), 1f, 0, 0);
                        _spriteBatch.Draw(BBQfood, new Rectangle(343, 120, 128, 128), Color.White);
                    }
                    if (getMukrata == true && finsihcraft == true)
                    {
                        _spriteBatch.Draw(newfood, new Vector2(400, 200), new Rectangle(0, 0, 800, 450), Color.White, rotationMenuBG, new Vector2(372, 211), 1f, 0, 0);
                        _spriteBatch.Draw(Mukrata, new Rectangle(343, 120, 128, 128), Color.White);
                    }
                    if (getPizza == true && finsihcraft == true)
                    {
                        _spriteBatch.Draw(newfood, new Vector2(400, 200), new Rectangle(0, 0, 800, 450), Color.White, rotationMenuBG, new Vector2(372, 211), 1f, 0, 0);
                        _spriteBatch.Draw(Pizza, new Rectangle(343, 120, 128, 128), Color.White);
                    }
                    if (getDragonFish == true && finsihcraft == true)
                    {
                        _spriteBatch.Draw(newfood, new Vector2(400, 200), new Rectangle(0, 0, 800, 450), Color.White, rotationMenuBG, new Vector2(372, 211), 1f, 0, 0);
                        _spriteBatch.Draw(DragonFish, new Rectangle(343, 120, 128, 128), Color.White);
                    }
                    if (getBingsu == true && finsihcraft == true)
                    {
                        _spriteBatch.Draw(newfood, new Vector2(400, 200), new Rectangle(0, 0, 800, 450), Color.White, rotationMenuBG, new Vector2(372, 211), 1f, 0, 0);
                        _spriteBatch.Draw(Bingsu, new Rectangle(343, 120, 128, 128), Color.White);
                    }
                    if (getPumkimCheses == true && finsihcraft == true)
                    {
                        _spriteBatch.Draw(newfood, new Vector2(400, 200), new Rectangle(0, 0, 800, 450), Color.White, rotationMenuBG, new Vector2(372, 211), 1f, 0, 0);
                        _spriteBatch.Draw(PumkimCheses, new Rectangle(343, 120, 128, 128), Color.White);
                    }
                    if (getCrunchPork == true && finsihcraft == true)
                    {
                        _spriteBatch.Draw(newfood, new Vector2(400, 200), new Rectangle(0, 0, 800, 450), Color.White, rotationMenuBG, new Vector2(372, 211), 1f, 0, 0);
                        _spriteBatch.Draw(CrunchPork, new Rectangle(343, 120, 128, 128), Color.White);
                    }
                    if (getSasimi == true && finsihcraft == true)
                    {
                        _spriteBatch.Draw(newfood, new Vector2(400, 200), new Rectangle(0, 0, 800, 450), Color.White, rotationMenuBG, new Vector2(372, 211), 1f, 0, 0);
                        _spriteBatch.Draw(Sasimi, new Rectangle(343, 120, 128, 128), Color.White);
                    }
                    if (getSalad == true && finsihcraft == true)
                    {
                        _spriteBatch.Draw(newfood, new Vector2(400, 200), new Rectangle(0, 0, 800, 450), Color.White, rotationMenuBG, new Vector2(372, 211), 1f, 0, 0);
                        _spriteBatch.Draw(Salad, new Rectangle(343, 120, 128, 128), Color.White);
                    }
                    if (getStone == true && finsihcraft == true)
                    {
                        _spriteBatch.Draw(newfood, new Vector2(400, 200), new Rectangle(0, 0, 800, 450), Color.White, rotationMenuBG, new Vector2(372, 211), 1f, 0, 0);
                        _spriteBatch.Draw(Stone, new Rectangle(343, 120, 128, 128), Color.White);
                    }
                    if (getmeatball_food == true && finsihcraft == true)
                    {
                        _spriteBatch.Draw(newfood, new Vector2(400, 200), new Rectangle(0, 0, 800, 450), Color.White, rotationMenuBG, new Vector2(372, 211), 1f, 0, 0);
                        _spriteBatch.Draw(meatball_food, new Rectangle(343, 120, 128, 128), Color.White);
                    }
                    if (getJellyfish_Salad == true && finsihcraft == true)
                    {
                        _spriteBatch.Draw(newfood, new Vector2(400, 200), new Rectangle(0, 0, 800, 450), Color.White, rotationMenuBG, new Vector2(372, 211), 1f, 0, 0);
                        _spriteBatch.Draw(Jellyfish_Salad, new Rectangle(343, 120, 128, 128), Color.White);
                    }
                    if (getGlamStew == true && finsihcraft == true)
                    {
                        _spriteBatch.Draw(newfood, new Vector2(400, 200), new Rectangle(0, 0, 800, 450), Color.White, rotationMenuBG, new Vector2(372, 211), 1f, 0, 0);
                        _spriteBatch.Draw(GlamStew, new Rectangle(343, 120, 128, 128), Color.White);
                    }
                    if (getSweetSteak == true && finsihcraft == true)
                    {
                        _spriteBatch.Draw(newfood, new Vector2(400, 200), new Rectangle(0, 0, 800, 450), Color.White, rotationMenuBG, new Vector2(372, 211), 1f, 0, 0);
                        _spriteBatch.Draw(SweetSteak, new Rectangle(343, 120, 128, 128), Color.White);
                    }
                    if (getDungNgo == true && finsihcraft == true)
                    {
                        _spriteBatch.Draw(newfood, new Vector2(400, 200), new Rectangle(0, 0, 800, 450), Color.White, rotationMenuBG, new Vector2(372, 211), 1f, 0, 0);
                        _spriteBatch.Draw(DungNgo, new Rectangle(343, 120, 128, 128), Color.White);
                    }
                    if (getPudding == true && finsihcraft == true)
                    {
                        _spriteBatch.Draw(newfood, new Vector2(400, 200), new Rectangle(0, 0, 800, 450), Color.White, rotationMenuBG, new Vector2(372, 211), 1f, 0, 0);
                        _spriteBatch.Draw(Pudding, new Rectangle(343, 120, 128, 128), Color.White);
                    }
                    if (getUltimateSasimi == true && finsihcraft == true)
                    {
                        _spriteBatch.Draw(newfood, new Vector2(400, 200), new Rectangle(0, 0, 800, 450), Color.White, rotationMenuBG, new Vector2(372, 211), 1f, 0, 0);
                        _spriteBatch.Draw(UltimateSasimi, new Rectangle(343, 120, 128, 128), Color.White);
                    }
                    if (getMoodengNoodle == true && finsihcraft == true)
                    {
                        _spriteBatch.Draw(newfood, new Vector2(400, 200), new Rectangle(0, 0, 800, 450), Color.White, rotationMenuBG, new Vector2(372, 211), 1f, 0, 0);
                        _spriteBatch.Draw(MoodengNoodle, new Rectangle(343, 120, 128, 128), Color.White);
                    }
                    if (getTangHuLu == true && finsihcraft == true)
                    {
                        _spriteBatch.Draw(newfood, new Vector2(400, 200), new Rectangle(0, 0, 800, 450), Color.White, rotationMenuBG, new Vector2(372, 211), 1f, 0, 0);
                        _spriteBatch.Draw(TangHuLu, new Rectangle(343, 120, 128, 128), Color.White);
                    }
                    if (getThaiCrab == true && finsihcraft == true)
                    {
                        _spriteBatch.Draw(newfood, new Vector2(400, 200), new Rectangle(0, 0, 800, 450), Color.White, rotationMenuBG, new Vector2(372, 211), 1f, 0, 0);
                        _spriteBatch.Draw(ThaiCrab, new Rectangle(343, 120, 128, 128), Color.White);
                    }

                    CountTime(200);
                }
            

        }
        int count;
        public void RemoveCraft(int amount)
        {
            count++;
            if (count > 100)
            {
                for (int i = 0; i < amount; i--)
                {
                    Game1.CraftList.RemoveAt(i);
                    break;
                }
            }

        }

        public int countPopUp;
        public void CountTime(int timePopup)
        {
            countPopUp += 1;
            {
                if (countPopUp > timePopup)
                {
                    countPopUp = 0;
                    MenuPopup = 0;
                   
                }
            }
        }

        public int countP;
        public void CountC()
        {
            countP += 1;
            {
                if (countP > 30)
                {
                    getUni = false;
                    getPongneng = false;
                    getBBQfood = false;
                    getDragonFish = false;
                    getGreenShrimp = false;
                    getDumpling = false;
                    getGrilledChicken = false;
                    getIcecream_food = false;
                    getMukrata = false;
                    getmeatball_food = false;
                    getPizza = false;
                    getSasimi = false;
                    getStone = false;
                    getTempura = false;
                    getThaiCrab = false;
                    getBingsu = false;
                    getPumkimCheses = false;
                    getCrunchPork = false;
                    getSalad = false;
                    getJellyfish_Salad = false;
                    getGlamStew = false;
                    getSweetSteak = false;
                    getDungNgo = false;
                    getPudding = false;
                    getUltimateSasimi = false;
                    getMoodengNoodle = false;
                    getTangHuLu = false;
                    getgetThaiCrab = false;
                    countP = 0;

                }
            }
        }

    }
}
