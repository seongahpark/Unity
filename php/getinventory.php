<?php

$servername = "localhost:3307";
$username = "root";
$password = "qwe123";
$dbname = "user_info";

$conn = new mysqli($servername, $username, $password, $dbname);

if($conn->connect_error) {
	die("connection failed: " . $conn->connect_error);
}

$sql = "SELECT * FROM inven";
$result = $conn->query($sql);

if($result->num_rows > 0) {
// [
//	{'id': + row['id'], 'pw': + row['pw'], ... },
//	{'id': + row['id'], 'pw': + row['pw'], ... }
// ]

/*
	echo "[";
	while($row = $result->fetch_assoc()) {
		echo "{'id': '" .$row['id']. "', 'pw': '" .$row['pw']. "', 'age': '" .$row['age']. "', 'name': '" .$row['name']. "'},";
	}
	echo "]";
*/
}

$conn->close();

?>