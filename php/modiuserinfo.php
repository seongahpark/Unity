<?php

// localhost == 127.0.0.1
$servername = "localhost:3307";
$username = "root";
$password = "qwe123";
$dbname = "user_info";

$id = $_POST["id"];
$pw = $_POST["pw"];

$conn = new mysqli($servername, $username, $password, $dbname);

if($conn->connect_error) {
	die ("connection failed: " . $conn->connect_error);
}

// select * from login where id = 'kch';
$sql = "UPDATE login SET pw = '".$pw."' WHERE id = '" . $id . "'";
$result = $conn->query($sql);

if($result) {
	echo "Password Modify Success";
}else echo "Password Modify Failed";

$conn->close();

?>