/*
 * 玩家控制精灵代码
 * 1.0版本
 * 基本功能：左右移动
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AnimatedSprites
{
    class UserControlledSprite: Sprite
    {
        // Movement stuff

        // Get direction of sprite based on player input and speed
        public override Vector2 direction
        {
            get
            {
                Vector2 inputDirection = Vector2.Zero;

                // If player pressed arrow keys, move the sprite
                if (Keyboard.GetState(  ).IsKeyDown(Keys.Left))
                    inputDirection.X -= 1;
                if (Keyboard.GetState(  ).IsKeyDown(Keys.Right))
                    inputDirection.X += 1;

                return inputDirection * speed;
            }
        }

        public UserControlledSprite(Texture2D textureImage, Vector2 position,
            Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize,
            Vector2 speed)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame,
            sheetSize, speed)
        {
        }


        public UserControlledSprite(Texture2D textureImage, Vector2 position,
            Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize,
            Vector2 speed, int millisecondsPerFrame)
            : base(textureImage, position, frameSize, collisionOffset, currentFrame,
            sheetSize, speed, millisecondsPerFrame)
        {
        }

        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {

     
            position += direction;
            // If sprite is off the screen, move it back within the game window
            if (position.X < 70)
                position.X = 70;
            if (position.Y < 0)
                position.Y = 0;
            if (position.X > (clientBounds.Width - frameSize.X) / 2 - 40)
                position.X = (clientBounds.Width - frameSize.X) / 2 - 40;
            if (position.Y > clientBounds.Height - frameSize.Y)
                position.Y = clientBounds.Height - frameSize.Y;


            if(Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.Left))
                
                base.Update(gameTime, clientBounds);
        }
    }
}
