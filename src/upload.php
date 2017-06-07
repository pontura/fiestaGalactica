<?php

if(isset($_FILES["fileToUpload"]["name"]))
{
	$target_dir = "photos/";
	$target_dir = $target_dir . basename( $_POST["imageName"]);
	$uploadOk=1;
	if (move_uploaded_file($_FILES["fileToUpload"]["tmp_name"], $target_dir));
}

?>