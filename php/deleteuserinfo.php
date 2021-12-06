<?php

// localhost == 127.0.0.1
$servername = "localhost:3307";
$username = "root";
$password = "qwe123";
$dbname = "user_info";

$id = $_POST["id"];

$conn = new mysqli($servername, $username, $password, $dbname);

if($conn->connect_error) {
	die ("connection failed: " . $conn->connect_error);
}

// select * from login where id = 'kch';
$sql = "DELETE FROM login WHERE id = '" . $id . "'";
$result = $conn->query($sql);

if($result) {
	echo "Successfully dropped out of the membership.";
}else echo "Failed to withdraw";

$conn->close();

?>