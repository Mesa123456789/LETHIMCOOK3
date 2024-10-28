using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGame.Extended;
using LETHIMCOOK3.Sprite;

namespace LETHIMCOOK3.Screen
{
    public class screen
    {
        public OrthographicCamera _camera;
        public Vector2 _cameraPosition;
        public Vector2 _bgPosition;
        Food food;
        public List<Food> foodList = new();
        protected EventHandler ScreenEvent; public screen(EventHandler theScreenEvent)
        {
            ScreenEvent = theScreenEvent;
        }
        public virtual void Update(GameTime theTime)
        {
        }
        public virtual void Draw(SpriteBatch theBatch)
        {
        }
    }
}
