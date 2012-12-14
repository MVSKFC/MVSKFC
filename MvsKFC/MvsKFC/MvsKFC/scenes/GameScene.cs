using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;
using MvsKFC.Classes;
using MvsKFC.sprites;
using Microsoft.Xna.Framework;
using Microsoft.Devices.Sensors;
namespace MvsKFC.scenes
{
    class GameScene : CCScene
    {
        // 加入麦当劳叔叔
        

        public GameScene()
        {
            CCSize size = CCDirector.sharedDirector().getWinSize();
            base.init();
            CCSprite background = CCSprite.spriteWithFile("background//background");
            background.position = new CCPoint(size.width / 2, size.height / 2);
            this.addChild(background);
            this.addChild(gameplay.node());
            
        }
    }

    class gameplay : CCLayer
    {
        CCSize size = CCDirector.sharedDirector().getWinSize();
        Uncle_sprite actor = new Uncle_sprite();
        public override bool init()
        {
            CCMenuItemImage back_button = CCMenuItemImage.itemFromNormalImage("CloseSelected", "CloseNormal", this, click_back);
            CCMenu backMenu = CCMenu.menuWithItems(back_button);
            backMenu.position = new CCPoint(size.width - 20, 40);
            this.addChild(backMenu);
            this.m_bIsTouchEnabled = true;
            this.addChild(actor);
            
            return true;
        }


        public static new CCLayer node()
        {
            
            gameplay screen = new gameplay(); 
            if (screen.init())  
            {  

                return screen;  
            }  
            else  
            {  
                screen = null;  
            }  
            return screen;  
        }


        public override void ccTouchesEnded(List<CCTouch> touches, CCEvent event_)
        {
            actor.actack();
            base.ccTouchesEnded(touches, event_);
            CCTouch touch = touches.FirstOrDefault();
            CCPoint location = touch.locationInView(touch.view());
            location = CCDirector.sharedDirector().convertToGL(location);

            //set up initial location of projectile  
            CCSize winSize = CCDirector.sharedDirector().getWinSize();
            CCSprite projectile = CCSprite.spriteWithFile(@"sprites/hamberger");
            projectile.position = new CCPoint(actor.position.x, actor.position.y + 20);

            this.addChild(projectile);

            float offX = location.x - projectile.position.x;
            float offY = location.y - projectile.position.y;
            offY -= 30;

            float realX = winSize.width + projectile.contentSize.width / 2;
            float ratio = offY / offX;
            float realY = realX * ratio + projectile.position.y;
            realY -= 30;
            CCPoint realDest = new CCPoint(realX, realY);

            //Determine the length of how far we're shooting  
            float offRealX = realX - projectile.position.x;
            float offRealY = realY - projectile.position.y;
            offRealY -= 30;
            float length = (float)Math.Sqrt(offRealX * offRealX + offRealY * offRealY);
            float velocity = 480 / 1;//480pixls/lsec  
            float realMoveDuration = length / velocity;

            //Move projectile to actual endpoint  
            projectile.runAction(CCSequence.actions(CCMoveTo.actionWithDuration(realMoveDuration, realDest),
                CCCallFuncN.actionWithTarget(this, spriteMoveFinished)));

        }


        void spriteMoveFinished(object sender)
        {
            CCSprite sprite = (CCSprite)sender;
            this.removeChild(sprite, true);
        }


        public void click_back(CCObject s)
        {
            CCDirector.sharedDirector().popScene();
        }
    }
}
