(function (lib, img, cjs) {

var p; // shortcut to reference prototypes

// library properties:
lib.properties = {
	width: 800,
	height: 600,
	fps: 30,
	color: "#FFFFFF",
	manifest: [
		{src:"images/png1.png", id:"png1"},
		{src:"images/png2.png", id:"png2"},
		{src:"images/png5.png", id:"png5"},
		{src:"images/png6.png", id:"png6"},
		{src:"images/png.png", id:"png"},
		{src:"images/qie.png", id:"qie"}
	]
};



// symbols:



(lib.png1 = function() {
	this.initialize(img.png1);
}).prototype = p = new cjs.Bitmap();
p.nominalBounds = new cjs.Rectangle(0,0,360,170);


(lib.png2 = function() {
	this.initialize(img.png2);
}).prototype = p = new cjs.Bitmap();
p.nominalBounds = new cjs.Rectangle(0,0,540,170);


(lib.png5 = function() {
	this.initialize(img.png5);
}).prototype = p = new cjs.Bitmap();
p.nominalBounds = new cjs.Rectangle(0,0,720,950);


(lib.png6 = function() {
	this.initialize(img.png6);
}).prototype = p = new cjs.Bitmap();
p.nominalBounds = new cjs.Rectangle(0,0,720,950);


(lib.png = function() {
	this.initialize(img.png);
}).prototype = p = new cjs.Bitmap();
p.nominalBounds = new cjs.Rectangle(0,0,1800,360);


(lib.qie = function() {
	this.initialize(img.qie);
}).prototype = p = new cjs.Bitmap();
p.nominalBounds = new cjs.Rectangle(0,0,1080,170);


(lib.NewQie = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{startStand:0,startJump:16,startFly:27,stop1:38,stop2:39});

	// timeline functions:
	this.frame_15 = function() {
		this.stop();
	}
	this.frame_26 = function() {
		this.stop();
	}
	this.frame_37 = function() {
		this.gotoAndPlay("startFly");
	}

	// actions tween:
	this.timeline.addTween(cjs.Tween.get(this).wait(15).call(this.frame_15).wait(11).call(this.frame_26).wait(11).call(this.frame_37).wait(3));

	// Layer 1
	this.shape = new cjs.Shape();
	this.shape.graphics.bf(img.qie, null, new cjs.Matrix2D(1,0,0,1,-90,-85)).s().p("AuDNRIAA6hIcHAAIAAahg");

	this.shape_1 = new cjs.Shape();
	this.shape_1.graphics.bf(img.qie, null, new cjs.Matrix2D(1,0,0,1,-270,-85)).s().p("AuDNRIAA6hIcHAAIAAahg");

	this.shape_2 = new cjs.Shape();
	this.shape_2.graphics.bf(img.qie, null, new cjs.Matrix2D(1,0,0,1,-450,-85)).s().p("AuDNRIAA6hIcHAAIAAahg");

	this.shape_3 = new cjs.Shape();
	this.shape_3.graphics.bf(img.qie, null, new cjs.Matrix2D(1,0,0,1,-630,-85)).s().p("AuDNRIAA6hIcHAAIAAahg");

	this.shape_4 = new cjs.Shape();
	this.shape_4.graphics.bf(img.qie, null, new cjs.Matrix2D(1,0,0,1,-810,-85)).s().p("AuDNRIAA6hIcHAAIAAahg");

	this.shape_5 = new cjs.Shape();
	this.shape_5.graphics.bf(img.qie, null, new cjs.Matrix2D(1,0,0,1,-990,-85)).s().p("AuDNRIAA6hIcHAAIAAahg");

	this.shape_6 = new cjs.Shape();
	this.shape_6.graphics.bf(img.png2, null, new cjs.Matrix2D(1,0,0,1,-90,-85)).s().p("AuDNRIAA6hIcHAAIAAahg");

	this.shape_7 = new cjs.Shape();
	this.shape_7.graphics.bf(img.png2, null, new cjs.Matrix2D(1,0,0,1,-270,-85)).s().p("AuDNRIAA6hIcHAAIAAahg");

	this.shape_8 = new cjs.Shape();
	this.shape_8.graphics.bf(img.png2, null, new cjs.Matrix2D(1,0,0,1,-450,-85)).s().p("AuDNRIAA6hIcHAAIAAahg");

	this.shape_9 = new cjs.Shape();
	this.shape_9.graphics.bf(img.png1, null, new cjs.Matrix2D(1,0,0,1,-90,-85)).s().p("AuDNRIAA6hIcHAAIAAahg");

	this.shape_10 = new cjs.Shape();
	this.shape_10.graphics.bf(img.png1, null, new cjs.Matrix2D(1,0,0,1,-270,-85)).s().p("AuDNRIAA6hIcHAAIAAahg");

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.shape}]}).to({state:[{t:this.shape_1}]},5).to({state:[{t:this.shape_2}]},5).to({state:[{t:this.shape_3}]},4).to({state:[{t:this.shape_3}]},2).to({state:[{t:this.shape_4}]},5).to({state:[{t:this.shape_5}]},5).to({state:[{t:this.shape_6}]},1).to({state:[{t:this.shape_7}]},4).to({state:[{t:this.shape_8}]},4).to({state:[{t:this.shape_9}]},3).to({state:[{t:this.shape_10}]},1).wait(1));

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-90,-85,180,170);


(lib.Bg2 = function() {
	this.initialize();

	// Layer 1
	this.instance = new lib.png5();
	this.instance.setTransform(-360,-475);

	this.addChild(this.instance);
}).prototype = p = new cjs.Container();
p.nominalBounds = new cjs.Rectangle(-360,-475,720,950);


(lib.Bg1 = function() {
	this.initialize();

	// Layer 1
	this.instance = new lib.png6();
	this.instance.setTransform(-360,-475);

	this.addChild(this.instance);
}).prototype = p = new cjs.Container();
p.nominalBounds = new cjs.Rectangle(-360,-475,720,950);


(lib.Bear = function(mode,startPosition,loop) {
	this.initialize(mode,startPosition,loop,{stop:0,startHit:1,look:5});

	// timeline functions:
	this.frame_0 = function() {
		this.stop();
	}
	this.frame_4 = function() {
		this.stop();
	}
	this.frame_15 = function() {
		this.stop();
	}

	// actions tween:
	this.timeline.addTween(cjs.Tween.get(this).call(this.frame_0).wait(4).call(this.frame_4).wait(11).call(this.frame_15).wait(1));

	// Layer 1
	this.shape = new cjs.Shape();
	this.shape.graphics.bf(img.png, null, new cjs.Matrix2D(1,0,0,1,-150,-180)).s().p("A3bcIMAAAg4PMAu3AAAMAAAA4Pg");

	this.shape_1 = new cjs.Shape();
	this.shape_1.graphics.bf(img.png, null, new cjs.Matrix2D(1,0,0,1,-450,-180)).s().p("A3bcIMAAAg4PMAu2AAAMAABA4Pg");

	this.shape_2 = new cjs.Shape();
	this.shape_2.graphics.bf(img.png, null, new cjs.Matrix2D(1,0,0,1,-1050,-180)).s().p("A3bcIMAAAg4PMAu3AAAMAAAA4Pg");

	this.shape_3 = new cjs.Shape();
	this.shape_3.graphics.bf(img.png, null, new cjs.Matrix2D(1,0,0,1,-750,-180)).s().p("A3acIMgABg4PMAu3AAAMAAAA4Pg");

	this.timeline.addTween(cjs.Tween.get({}).to({state:[{t:this.shape}]}).to({state:[{t:this.shape_1}]},1).to({state:[{t:this.shape_2}]},3).to({state:[{t:this.shape}]},1).to({state:[{t:this.shape_1}]},5).to({state:[{t:this.shape_3}]},5).wait(1));

}).prototype = p = new cjs.MovieClip();
p.nominalBounds = new cjs.Rectangle(-150,-180,300,360);


// stage content:
(lib.flashlib = function() {
	this.initialize();

}).prototype = p = new cjs.Container();
p.nominalBounds = null;

})(lib = lib||{}, images = images||{}, createjs = createjs||{});
var lib, images, createjs;