//and add them up top as a public variable.

public var rearCamera : Camera ;
public var whereCamera : Camera ;

private var map = false;

rearCamera.GetComponent.<Camera>().enabled = true;
whereCamera.GetComponent.<Camera>().enabled = false;

function Start() {
    rearCamera.GetComponent.<Camera>().enabled = true;
    whereCamera.GetComponent.<Camera>().enabled = false;
}

function Update() {
    //this is a hard wired connection to the "F2" Key on the keyboard, switch it any keyboard key if you like
    //this will disable the camera behind the car, and enable the camera inside of the vehicle
    if (Input.GetKeyDown(KeyCode.M))
    {
    	if(!map){
        	rearCamera.GetComponent.<Camera>().enabled = false;
        	whereCamera.GetComponent.<Camera>().enabled = true;
        	map = true;
    	}
    	else{
        	rearCamera.GetComponent.<Camera>().enabled = true;
	        whereCamera.GetComponent.<Camera>().enabled = false;
    	    map = false;
    	}
    }
}