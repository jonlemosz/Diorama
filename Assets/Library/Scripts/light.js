#pragma strict
private var glow : Light;
var Intensity : float = 2.0;
var IntensityDefault : float = 4.0;
var time : float = 3;
private var down : boolean = false;
function Start () {
	glow = GetComponent.<Light>();


}

function Update () {
	if(glow.intensity <= Intensity  && down == false){
		glow.intensity += time * Time.deltaTime;
	}
	if(glow.intensity > Intensity && down == false){
		down = true;
	}

	if(down){
		glow.intensity -= time * Time.deltaTime;
		if(glow.intensity <= IntensityDefault){
			down = false;
		}
	}
}