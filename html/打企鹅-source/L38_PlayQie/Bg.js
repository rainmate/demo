/**
 * Created by wwtliu on 14/8/20.
 */
(function(){
    function MyImg(){
        var _this = new lib.Bg2();
        function removeAndClean(){
            _this.parent.removeChild(_this);
            _this.removeEventListener("tick",tickHandler);
        }
        function tickHandler(e){
            if(_this.getStage()){
                if(_this.localToGlobal(0,0).x >720+360){
                    removeAndClean();
                }
            }
        }
        function init(){
            _this.addEventListener("tick",tickHandler);
        }
        init();
        return _this;
    }
    function Bg(){
        var _this = new createjs.Container();
        var leftImg;
        function addNewImg(){
            leftImg = MyImg();
            leftImg.x = 360;
            leftImg.y = 475;
            _this.addChild(leftImg);
            return leftImg;
        }
        function TickHandler(e){
            if(fly_speed_y>=0){
                _this.x+=fly_speed_y;
            }

            if(leftImg.localToGlobal(0,0).x>0){
                var lodLeftImg = leftImg;
                leftImg = addNewImg();
                leftImg.x = lodLeftImg.x - leftImg.getBounds().width;
            }
        }

        function init(){
            addNewImg();
            _this.addEventListener("tick",TickHandler);
        }
        init();
        return _this;
    }
    window.Bg = Bg;
}());