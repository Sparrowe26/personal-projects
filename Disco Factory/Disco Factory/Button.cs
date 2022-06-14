using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Disco_Factory
{
    /// <summary>
    /// If the client wants to be notified when a button is clicked, it must
    /// implement a method matching this delegate and then tie that method to
    /// the button's "OnButtonClick" event.
    /// </summary>
    public delegate void OnButtonClickDelegate();

    /// <summary>
    /// Builds, monitors, and draws a customized Button
    /// </summary>
    public class Button
    {
        // Button specific fields
        private MouseState prevMState;
        private Rectangle position; // Button position and size
        private Texture2D buttonImg;
        private Texture2D hoverImg; //when the mouse hovers over the button

        /// <summary>
        /// If the client wants to be notified when a button is clicked, it must
        /// implement a method matching OnButtonClickDelegate and then tie that method to
        /// the button's "OnButtonClick" event.
        /// 
        /// The delegate will be called with a reference to the clicked button.
        /// </summary>
        public event OnButtonClickDelegate OnButtonClick;

        /// <summary>
        /// Create a new custom button
        /// </summary>
        /// <param name="device"></param>
        /// <param name="texture"></param>
        /// <param name="position"></param>
        public Button(GraphicsDevice device, Texture2D texture, Texture2D hoverTexture, Rectangle position)
        {
            // Save copies/references to the info we'll need later
            this.position = position;

            // set the button's texture
            buttonImg = texture;
            hoverImg = hoverTexture;
        }

        /// <summary>
        /// Each frame, update its status if it's been clicked.
        /// </summary>
        public void Update()
        {
            // Check/capture the mouse state regardless of whether this button
            // if active so that it's up to date next time!
            MouseState mState = Mouse.GetState();

            if (mState.LeftButton == ButtonState.Released &&
                prevMState.LeftButton == ButtonState.Pressed &&
                position.Contains(mState.Position))
            {
                if (OnButtonClick != null)
                {
                    // Call ALL methods attached to this button
                    OnButtonClick();
                }
            }

            prevMState = mState;
        }

        /// <summary>
        /// Override the GameObject Draw() to draw the button and then
        /// overlay it with text.
        /// </summary>
        /// <param name="spriteBatch">The spriteBatch on which to draw this button. The button 
        /// assumes that Begin() has already been called and End() will be called later.</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            MouseState mState = Mouse.GetState();

            // Draw the button based on whether the mouse is hovering over it or not
            if (position.Contains(mState.Position))
            {
                spriteBatch.Draw(hoverImg, position, Color.White);
            }
            else
            {
                spriteBatch.Draw(buttonImg, position, Color.White);
            }
        }

    }
}
