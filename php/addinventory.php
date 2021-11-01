<?php

// localhost == 127.0.0.1
$servername = "localhost:3307";
$username = "root";
$password = "qwe123";
$dbname = "user_info";

$name = $_POST["name"];
$type = $_POST["type"];

$conn = new mysqli($servername, $username, $password, $dbname);

if($conn->connect_error) {
	die ("connection failed: " . $conn->connect_error);
}

// select * from login where id = 'kch';
$sql = "SELECT * FROM inven WHERE name = '" . $name . "'";
$result = $conn->query($sql);

if($result->num_rows > 0) {
	//$update_sql = "UPDATE login SET score = '" . $score . "' WHERE id = '" . $id . "'";
	//$conn->query($update_sql);
}
else {
// insert into login (id, pw, age, name) values ('id', 'pw', 'age', 'name');
	$insert_sql = "INSERT INTO inven (name, type)
				   VALUES ('" . $name . "', '" . $type . "')";
	$conn->query($insert_sql);
}

$conn->close();

?>