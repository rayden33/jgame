#pragma strict

private var theCollider : String;

function OnTriggerEnter (other : Collider)
{
	theCollider = other.tag;
	if (theCollider == "FPSController")
	{
		audio.Play();
		audio.loop = true;
	}
}

function OnTriggerExit (other : Collider)
{
	theCollider = other.tag;
	if (theCollider == "FPSController")
	{
		audio.Stop();
		audio.loop = false;
	}
}