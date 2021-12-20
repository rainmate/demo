/**
 * Created by wwtliu on 14/8/20.
 */

var canvas, stage, Root_bg,Root_Elment,qieRoot,bearRoot,bg1Root;
var qieRoot_location;
var fly_speed_x=30,fly_speed_y=300,g = 1;
var flag = true;

window.onload = function() {
    canvas = document.getElementById("canvas");
    images = images||{};

    var loader = new createjs.LoadQueue(false);
    loader.addEventListener("fileload", handleFileLoad);
    loader.addEventListener("complete", handleComplete);
    loader.loadManifest(lib.properties.manifest);
}
function handleFileLoad(evt) {
    if (evt.item.type == "image") { images[evt.item.id] = evt.result; }
}

function handleComplete() {
    Root_bg = new createjs.Container();
    Root_Elment = new createjs.Container();
    stage = new createjs.Stage(canvas);
    stage.addChild(Root_bg);
    stage.addChild(Root_Elment);

    bg1Root = new lib.Bg1();
    bg1Root.x = 360;
    bg1Root.y = 475;
    Root_bg.addChild(bg1Root);

    qieRoot = new lib.NewQie();
    qieRoot.x = 550;
    qieRoot.y = 90;
    Root_Elment.addChild(qieRoot);

    bearRoot = new lib.Bear();
    bearRoot.x = 550;
    bearRoot.y = 680;
    Root_Elment.addChild(bearRoot);
    bearRoot.addEventListener("click",bearClickHandler);


    stage.update();
    createjs.Ticker.setFPS(lib.properties.fps);
    createjs.Ticker.addEventListener("tick", stage);
}

function bearClickHandler(e){
    qieRoot.gotoAndPlay("startJump");
    qieRoot.addEventListener("tick",qieTickHandler);
    bearRoot.gotoAndPlay("look");
    bearRoot.addEventListener("click",bearClickHandlerPlay);
}

function qieTickHandler(e){
    qieRoot.y+=10;
}

function bearClickHandlerPlay(e){
    bearRoot.gotoAndPlay("startHit");
    qieRoot_location = qieRoot.y;
    qieRoot.addEventListener("tick",qieTickHandlerfly);
}

function qieTickHandlerfly(e){
    if(550<qieRoot_location && qieRoot_location<650){
//        console.log("play");
        qieRoot.gotoAndPlay("startFly");
        qieRoot.x = qieRoot.x - fly_speed_x;
        qieRoot.y = qieRoot.y - fly_speed_y;
        fly_speed_y -=g;
        if(qieRoot.x<0||qieRoot.y<0){
           gogo();
           flag = false;
           if(fly_speed_y == 0){
               qieRoot.x = 700;
               qieRoot.y = 400;
           }
        }
        if(qieRoot.y >=700){
            qieRoot.removeEventListener("tick",qieTickHandler);
            qieRoot.removeEventListener("tick",qieTickHandlerfly);
            qieRoot.gotoAndStop("stop2");
        }
    }
    function gogo(){
        if(flag!=false){
            Root_Elment.removeChild(bearRoot);
            Root_bg.addChild(Bg());
        }
    }
}