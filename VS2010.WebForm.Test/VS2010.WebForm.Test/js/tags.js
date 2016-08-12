var carven;
var tags = [];
var cX;
var cY;
var distr = true;
var radius = 272;
var cop;
var size;

var debug;
var Mtop=10;
var Mbtm;
var time;

var current;

function init() {
	debug = $("#debug");
	carven=document.getElementById("tags");
	if(carven==null)
	{return false;}
	carven2=$("#tags")
	tag=$("#tags a")	
	cX=$("#tags").width()/2;
	cY=$("#tags").height()/2;
	Mbtm = cY*2-25;
	time = Mbtm-Mtop;
	for (i=0;i<$("#tags a").length;i++) {
			//$("#tags a:eq("+i+")").css("top",50*i+"px")			
			tags.push($("#tags a:eq("+i+")"))
			tH=tags[i].height();
			tW=tags[i].width();
			tags[i].css("top",cY-tH/2+"px")	
			tags[i].css("left",cX-tW/2+"px")
			tags[i].tp= i%2==0?1:0;
			
		
		}	
	
	
		
	positionAll();


	}
function positionAll() {
	 	var phi=0;
        var theta=0;
        var max=tags.length;
		
        var i=0;
        
        var aTmp=[];
        var oFragment=document.createDocumentFragment();
        
        //Ëæ»úÅÅÐò
		
        for(i=0;i<tag.length;i++)
        {
                aTmp.push(tag[i]);
				
        }
        
        aTmp.sort
        (
                function ()
                {
						
                        return Math.random()<0.5?1:-1;
					
						
                }
        );	
        for(i=0;i<aTmp.length;i++)
        {
			 
                oFragment.appendChild(aTmp[i]);		
				tag[i]=aTmp[i]
				
        }       
        carven.appendChild(oFragment);
        //alert (aTmp[1].innerHTML+"||"+tag[1].innerHTML)		
        for( var i=1; i<max+1; i++){
                if( distr )
                {
                        phi = Math.acos(-1+(2*i-2)/(max+5));						
                        theta = Math.sqrt(max*Math.PI)*phi;
						
                }
                else
                {
                        phi = Math.random()*(Math.PI);
                        theta = Math.random()*(2*Math.PI);
                }
                //×ø±ê±ä»»
                tags[i-1].cx = radius * Math.cos(theta)*Math.sin(phi);
                tags[i-1].cy = radius*1.5 * Math.sin(theta)*Math.sin(phi);
                tags[i-1].cz = radius * Math.cos(phi);
            	
				var tX =0;
				var tY =0;
				
				tX=tags[i-1].cx+carven.offsetWidth/2-tag[i-1].offsetWidth/2-25;
				tY=tags[i-1].cy+carven.offsetHeight/2-tag[i-1].offsetHeight/2;
				
				if (tags[i-1].tp==0) {
					$("#tags a:eq("+(i-1)+")").hide();
					//$("#tags a:eq("+(i-1)+")").css({"color":"red"});
					}				
				font = (1-Math.abs(tY-cY)/cY)*100+100+30
				alpha = (1-Math.abs(tY-cY)/cY)		
				if (i!=max) {
						
						$("#tags a:eq("+(i-1)+")").animate({left:tX+"px",top:tY+"px",fontSize:font+"%",opacity:alpha})	
					}
					else {
						$("#tags a:eq("+(i-1)+")").animate({left:tX+"px",top:tY+"px",fontSize:font+"%",opacity:alpha},function(){moveAll()})			
						
				 }
				
                /*tag[i-1].style.left=tags[i-1].cx+carven.offsetWidth/2-tag[i-1].offsetWidth/2+'px';
	
                tag[i-1].style.top=tags[i-1].cy+carven.offsetHeight/2-tag[i-1].offsetHeight/2+'px';*/
        }
		
	
	
	/*for (i=0;i<tags.length;i++){
		tags[i].animate({left:15*parseInt(Math.random()*20)+"px",top:17*parseInt(Math.random()*20)+"px"})
		}*/
	}
function moveAll() {
	
	var tX =[];
	var tY =[];
	var cop;
	
	for (i=0;i<$("#tags a").length;i++) {
		//alert (tags[i].css("top"))
		tY.push (parseInt(tags[i].css("top")))
		//alert (tY)
		//alert (tY+"!!"+i);
		$("#debug").html(tY[i])
		//alert ("color:"+tags[i].tp)
			if (tags[i].css("display")!="none")				
			//if (tags[i].css("color")!="rgb(255, 0, 0)")				
		{	
				if(tY[i]>cY){
					tags[i].animate({fontSize:"150%",opacity:1},tY[i]-cY*50)
					tags[i].animate({fontSize:"100%",opacity:0},tY[i]*50,function(){$(this).hide();/*$(this).css({"color":"red"});*/loop($(this))})	
					tags[i].animate({top:Mtop+"px"},{queue:false, duration: tY[i]*50})
					}
				else {
				tags[i].animate({top:Mtop+"px",fontSize:"100%",opacity:0},tY[i]*50,function(){$(this).hide();/*$(this).css({"color":"red"});*/loop($(this))})	
				}
				//tags[i].animate({top:"310px"},(340-tY[i])*50)
				//tags[i].animate({opacity:100},{queue:true, duration: 1000})
				//ags[i].animate({top:"10px"},tY[i]*50)				
				/*tags[i].animate({opacity:100},2)
				tags[i].animate({top:"10px"},340*50)*/
					
		}
		else {
				//tags[i].animate({top:Mbtm+"px",fontSize:"100%",opacity:0},(time-tY[i])*50,function(){$(this).show();/*$(this).css({"color":"black"});*/loop($(this))})
				tags[i].animate({top:"310px",fontSize:"100%",opacity:0},(340-tY[i])*50,function(){$(this).show();loop($(this))})
			}
			
			tags[i].hover(function(){
							if ($(this).css("display")!="none")			
							//if ($(this).css("color")!="rgb(255, 0, 0)")
							{
								
							  $(this).stop();
							   $(this).stop();
							  current = parseInt($(this).css("top"));
							  
							  cop =  $(this).css("opacity");
							  size =   $(this).css("fontSize");
							 
							  $(this).css({opacity:1})
							   $(this).css({"z-index":999})
							   debug.html($(this).css("z-index")); 
							   }
							   },function(){
								  if ($(this).css("display")!="none")	
								  // if ($(this).css("color")!="rgb(255, 0, 0)")	
								   {
								   $(this).css({opacity:cop})
								   $(this).css({fontSize:size})
								   $(this).css({"z-index":"auto"})
								   if(current>cY){	
								   		
										$(this).animate({fontSize:"150%",opacity:1},(current-160)*50)
										$(this).animate({fontSize:"100%",opacity:0},current*50,function(){$(this).hide();/*$(this).css({"color":"red"});*/loop($(this))})	
										$(this).animate({top:Mtop+"px"},{queue:false, duration: current*50})
									   }
								   else {									
									 $(this).animate({top:Mtop+"px",fontSize:"100%",opacity:0},current*50,function(){$(this).hide();/*$(this).css({"color":"red"});*/loop($(this))})
									   }
								
								   
								   }
								   })
		
		}
	

		
	
		
		
		
				
	}
function loop(the){	
	 
	
	if (the.css("display")!="none")
	//if (the.css("color")!="rgb(255, 0, 0)")
	{	
		
		the.animate({opacity:1,fontSize:"150%"},160*50)
		the.animate({opacity:0,fontSize:"100%"},160*50,function(){the.hide();/*$(this).css({"color":"red"});*/loop($(this))})
		the.animate({top:"10px"},{queue:false, duration: 320*50})

		
	
		
		//the.animate({top:"10px"},340*50,function(){the.hide();loop($(this))	})	
	}
	else {	
		the.animate({top:"310px"},320*50,function(){the.show();/*$(this).css({"color":"black"});*/loop($(this))})	
		}
	
	//the.animate({top:"310px"},(340-the.css("top"))*50)
				//tags[i].animate({opacity:100},{queue:true, duration: 1000})
				//the.animate({top:"10px"},the.css("top")*50)	
			
			
	}


$(function(){
	init();
});