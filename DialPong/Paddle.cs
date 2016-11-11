using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DialPong
{
    public class Paddle
    {
        public Sprite sprite;
        private GraphicsDeviceManager graphics;
        private float scale = 5.0f;

        public Paddle(GraphicsDeviceManager graphics)
        {
            this.graphics = graphics;
            sprite = new Sprite(graphics);
            sprite.position.X = 50;
            sprite.drawRect.Width = 50;
            sprite.drawRect.Height = 200;
        }

        public void Update()
        {
            sprite.Update();
        }

        public void ChangeSensitivity(float amount)
        {
            scale += amount;
            scale = MathHelper.Clamp(scale, 1, 100);
            System.Diagnostics.Debug.WriteLine(scale);
        }

        public void Move(float amount)
        {
            sprite.position.Y += amount * scale;
            if (sprite.position.Y <= 0)
            {
                sprite.position.Y = 0;
                Game1.dial.UseAutomaticHapticFeedback = false;
            }
            else if (sprite.position.Y >= graphics.GraphicsDevice.Viewport.Height - sprite.drawRect.Height)
            {
                sprite.position.Y = graphics.GraphicsDevice.Viewport.Height - sprite.drawRect.Height;
                Game1.dial.UseAutomaticHapticFeedback = false;
            }
            else
            {
                Game1.dial.UseAutomaticHapticFeedback = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.DrawRect(spriteBatch);
        }
    }
}
