using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using MvsKFC.scenes;

namespace MvsKFC
{
    public class AppDelegate : CCApplication
    {
        public AppDelegate(Game game, GraphicsDeviceManager graphics)
            : base(game, graphics)
        {
            CCApplication.sm_pSharedApplication = this;
        }
        public override bool applicationDidFinishLaunching()
      {
        //初始化CCDirector
        CCDirector pDirector = CCDirector.sharedDirector();
        pDirector.setOpenGLView();
 
        //是否显示FPS（每秒帧速率）
        pDirector.DisplayFPS = true;
        // 在这里设置Updata的间隔
        pDirector.animationInterval = 1.0 / 60;
 
        // 创建一个场景
        CCScene pScene = new Starscene();
 
        // 运行这个场景
        pDirector.runWithScene(pScene);
 
        return true;
    }
    }
}
