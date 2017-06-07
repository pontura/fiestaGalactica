<?php
	$directory = 'photos';
	$scanned_directory = array_diff(scandir($directory), array('..', '.'));

	$result = "";
	foreach ($scanned_directory as $key => $value) 
	{ 
		$result .= "-" . $value;
	} 
	print($result);   
?>