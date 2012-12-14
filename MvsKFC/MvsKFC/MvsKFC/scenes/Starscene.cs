using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using cocos2d;
using MvsKFC.Classes;
namespace MvsKFC.scenes
{
    /// <summary>
    /// 这是一个实现 IUpdateable 的游戏组件。
    /// </summary>
    public class Starscene : CCScene
    {
        public Starscene()
        {
            base.init();
            CCSpriteFrameCache.sharedSpriteFrameCache().addSpriteFramesWithFile(@"plist/allimage");
            //取得屏幕大小
            CCSize size = CCDirector.sharedDirector().getWinSize();
            //背景图
            CCSprite background = CCSprite.spriteWithFile("background//start");
            background.position = new CCPoint(size.width / 2, size.height / 2);
            
            this.addChild(background);
            //两个按钮
            CCMenuItemSprite btn_start = CCMenuItemSprite.itemFromNormalSprite(
                         CCSprite.spriteWithSpriteFrameName("playbutton01.png"),
                         CCSprite.spriteWithSpriteFrameName("playbutton03.png"),
                         this, click_start);
            CCMenuItemSprite btn_back = CCMenuItemSprite.itemFromNormalSprite(
                        CCSprite.spriteWithSpriteFrameName("quitbutton01.png"),
                        CCSprite.spriteWithSpriteFrameName("quitbutton03.png"),
                        this, click_people);
            //MenuItem需要通过CCMenu组合
            CCMenu menu_star = CCMenu.menuWithItems(btn_start);
            CCMenu menu_back = CCMenu.menuWithItems(btn_back);
            // 设置开始和结束按钮
            menu_star.position = new CCPoint(size.width / 4 * 3 - 60, 70);
            this.addChild(menu_star);
            menu_back.position = new CCPoint(size.width / 4 * 3 + 70, 150);
            this.addChild(menu_back);

        }

        private void click_start(CCObject sender)
        {
            var s = CCTransitionFade.transitionWithDuration(0.5f, GameRoot.pSelectScene);
            CCDirector.sharedDirector().pushScene(s);
        }
        private void click_people(CCObject sender)
        {
            CCDirector.sharedDirector().popScene();
        }
    }
}
