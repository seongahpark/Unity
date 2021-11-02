<?php

// localhost == 127.0.0.1
$servername = "localhost:3307";
$username = "root";
$password = "qwe123";
$dbname = "user_info";

$id = $_POST["id"];
$pw = $_POST["pw"];
$age = $_POST["age"];
$name = $_POST["name"];

$conn = new mysqli($servername, $username, $password, $dbname);

if($conn->connect_error) {
	die ("connection failed: " . $conn->connect_error);
}

// select * from login where id = 'kch';
$sql = "SELECT * FROM login WHERE id = '" . $id . "'";
$result = $conn->query($sql);

if($result->num_rows > 0) {
	echo "ID is already in use";
}
else {
// insert into login (id, pw, age, name) values ('id', 'pw', 'age', 'name');
	$insert_sql = "INSERT INTO login (id, pw, age, name)
				   VALUES ('" . $id . "', '" . $pw . "', '"
				   . $age . "', '" . $name . "')";
	$conn->query($insert_sql);
	echo "Register Success";
}

$conn->close();

?>